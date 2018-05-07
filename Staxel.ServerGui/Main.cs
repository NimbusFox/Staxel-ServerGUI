using NimbusFox.ServerGui.Classes;
using Plukit.Base;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO.Pipes;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NamedPipeWrapper;
using NimbusFox.ServerGUI.Hook.Classes.Pipe;
using System.Collections.Generic;
using System.Drawing;

namespace NimbusFox.ServerGui {
    public partial class Main : Form {
        private readonly Process _staxelProcess;

        private bool _requestExit = false;

        private readonly NamedPipeClient<PipeClass> _pipeServer = new NamedPipeClient<PipeClass>("ServerGUI");

        private NamedPipeConnection<PipeClass, PipeClass> _connection;

        private readonly string _titleStart;

        public Main() {
            InitializeComponent();

            _titleStart = Text;

            Settings.ReadSettings();

            _staxelProcess = new Process { StartInfo = new ProcessStartInfo() };

            _staxelProcess.StartInfo.FileName = "Staxel.Server.exe";

            _staxelProcess.StartInfo.Arguments = Settings.settings.CommandArgs;

            _staxelProcess.StartInfo.CreateNoWindow = true;

            _staxelProcess.StartInfo.RedirectStandardOutput = true;

            _staxelProcess.StartInfo.RedirectStandardError = true;

            _staxelProcess.StartInfo.RedirectStandardInput = true;

            _staxelProcess.StartInfo.UseShellExecute = false;

            _staxelProcess.EnableRaisingEvents = true;

            _staxelProcess.Exited += _staxelProcess_Exited;

            _staxelProcess.OutputDataReceived += _staxelProcess_OutputDataReceived;

            _staxelProcess.ErrorDataReceived += _staxelProcess_OutputDataReceived;

            _pipeServer.ServerMessage += _pipeServer_ServerMessage;

            UpdateUserList(new List<string>());

            wbLog.DocumentText = $@"<!DOCTYPE html>
<head>
<meta http-equiv='X-UA-Compatible' content='IE=edge' />
    <style>
        body {{
            background-color: black;
            color: white;
            margin: 0 !important;
            padding: 0 !important;
            font-size: 14px;
        }}
    </style>
    <script>
        {JSScripts.Jquery}
    </script>
    <script>
        var scroll = true;
        function printText(time, text, gui, client) {{
            var output = $('<span>');
            output.append(time)
            if (gui) {{
                output.css('color', '#FFD700');
                output.append('[GUI] ');
            }}
            if (!client && !gui) {{
                output.append('[Staxel] ');
            }}
            output.append(document.createTextNode(text));
            $('body').append(output);
            $('body').append('<br/>');
            if (scroll) {{
                scroll = false;
                $('html, body').animate({{scrollTop:$(document).height()}}, 'slow', function () {{ scroll = true; $('html, body').animate({{scrollTop:$(document).height()}}, 'slow'); }});
            }}
        }}
    </script>
</head>
<body>
</body>
</html>";
        }

        private void _pipeServer_ServerMessage(NamedPipeConnection<PipeClass, PipeClass> connection, PipeClass message) {
            if (message.Current == KeyEnum.Intergrated) {
                PrintText("Server hooked in successfully", true);
                _connection = connection;
            } else if (message.Current == KeyEnum.OnlineUsers) {
                UpdateUserList((List<string>)message.Data);
            }
        }

        private void _staxelProcess_Exited(object sender, EventArgs e) {

        }

        private delegate void PrintTextHandler(string text, bool gui);

        private void PrintText(string text, bool gui = false) {
            if (InvokeRequired) {
                Invoke(new PrintTextHandler(PrintText), text, gui);
            } else {
                wbLog.Document.InvokeScript("printText", new object[] { $"[{DateTime.Now.ToString()}] ", text, gui });
                if (text == "Server ready.") {
                    PrintText("Hooking into the server", true);
                    _pipeServer.Start();
                }
            }
        }

        private void _staxelProcess_OutputDataReceived(object sender, DataReceivedEventArgs e) {
            if (!e.Data.IsNullOrEmpty()) {
                var text = e.Data;

                if (text[0] == '(') {
                    text = text.Substring(text.IndexOf(')') + 1);
                }

                PrintText(text);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            StopServer();
            try {
                while (!_staxelProcess.HasExited) {
                    Application.DoEvents();
                }
            } catch {
                // ignore
            }
        }

        private void StopServer() {
            _requestExit = true;
            if (ClrDetection.IsMono()) {
                Process.Start("kill", "-SIGTERM " + _staxelProcess.Id);
            } else {
                try {
                    WindowsNative.AttachConsole((uint)_staxelProcess.Id);
                    WindowsNative.SetConsoleCtrlHandler(null, true);

                    WindowsNative.GenerateConsoleCtrlEvent(WindowsNative.CTRL_C_EVENT, 0);

                    WindowsNative.FreeConsole();
                    WindowsNative.SetConsoleCtrlHandler(null, false);
                } catch {
                    // ignore
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e) {
            _requestExit = false;
            if (btnStart.Text == "Start") {
                if (!_staxelProcess.Start()) {
                    MessageBox.Show(@"The server shutdown unexpectedly. Please check the logs for the error");
                } else {
                    _staxelProcess.BeginErrorReadLine();
                    _staxelProcess.BeginOutputReadLine();
                    _staxelProcess.StandardInput.AutoFlush = true;
                }
                btnStart.Text = "Stop";
            } else {
                StopServer();
                btnStart.Text = "Start";
            }
        }

        private void btnSend_Click(object sender, EventArgs e) {
            _pipeServer.PushMessage(new PipeClass {
                Current = KeyEnum.Message,
                Data = txtServerMessage.Text
            });

            txtServerMessage.Text = "";
        }

        private void btnSettings_Click(object sender, EventArgs e) {
            Global.Settings.ShowDialog();
        }

        private string GetUserFromMousePos(out bool isMuted) {
            var index = lstUsers.IndexFromPoint(MousePos);
            isMuted = false;

            if (index < 0 || index >= lstUsers.Items.Count) {
                return null;
            }

            var current = lstUsers.Items[index].ToString();

            if (current.Contains(" (Muted)")) {
                isMuted = true;
                current = current.Replace(" (Muted)", "");
            }

            return current;
        }

        private void tlstrpUserKick_Click(object sender, EventArgs e) {
            var current = GetUserFromMousePos(out _);

            if (current == null) {
                return;
            }

            var msgbx = MessageBox.Show("Are you sure you want to Kick " + current + "?",
                "Kick " + current, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (msgbx == DialogResult.Yes) {
                _pipeServer.PushMessage(new PipeClass {
                    Current = KeyEnum.Kick,
                    Data = current
                });
            }
        }

        private void tlstrpUserBan_Click(object sender, EventArgs e) {
            var current = GetUserFromMousePos(out _);

            if (current == null) {
                return;
            }

            bool BanUser(string reason) {
                if (reason.IsNullOrEmpty()) {
                    MessageBox.Show("Please enter a reason to why this user is to be banned", "Reason cannot be empty",
                        MessageBoxButtons.OK);
                    return false;
                }

                _pipeServer.PushMessage(new PipeClass {
                    Current = KeyEnum.Ban,
                    Data = new NameReason {
                        Name = current,
                        Reason = reason
                    }
                });

                return true;
            }

            var inputDiag = new Input("Ban " + current, "Please enter a reason why '" + current + "' is to be banned for", BanUser);

            inputDiag.ShowDialog();
        }

        private void tlstrpUserMute_Click(object sender, EventArgs e) {
            var current = GetUserFromMousePos(out _);

            if (current == null) {
                return;
            }

            bool MuteUser(string input) {
                if (!int.TryParse(input, out var output)) {
                    MessageBox.Show("Please enter a valid number", "Invalid input", MessageBoxButtons.OK);

                    return false;
                }

                if (output <= 0 || output >= 10080) {
                    MessageBox.Show("Please enter a number higher than 0 and less than 10,080 (7 days)",
                        "Invalid value", MessageBoxButtons.OK);

                    return false;
                }

                _pipeServer.PushMessage(new PipeClass {
                    Current = KeyEnum.Mute,
                    Data = new NameMinutes {
                        Name = current,
                        Minutes = output
                    }
                });

                return true;
            }

            var inputDiag = new Input("Mute " + current,
                "Please enter how long in minutes '" + current + "' will be muted for", MuteUser);

            inputDiag.ShowDialog();
        }

        private void tlstrpUnMute_Click(object sender, EventArgs e) {
            var current = GetUserFromMousePos(out _);

            if (current == null) {
                return;
            }

            var msgbx = MessageBox.Show("Are you sure you want to UnMute " + current + "?",
                "UnMute " + current, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (msgbx == DialogResult.Yes) {
                _pipeServer.PushMessage(new PipeClass {
                    Current = KeyEnum.UnMute,
                    Data = current
                });
            }
        }

        private void tlstrpUserWhisper_Click(object sender, EventArgs e) {
            var current = GetUserFromMousePos(out _);

            if (current == null) {
                return;
            }
        }

        private void UpdateUserList(List<string> users) {
            lstUsers.Items.Clear();

            foreach (var user in users) {

                lstUsers.Items.Add(user);
            }

            Text = _titleStart + " - " + lstUsers.Items.Count + " Users Online";
        }

        private void cntxtMnUser_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            var current = GetUserFromMousePos(out var muted);

            if (current == null) {
                e.Cancel = true;
                return;
            }

            tlStripUser.Text = current;

            if (muted) {
                tlstrpUnMute.Visible = true;
                tlstrpUserMute.Visible = false;
            } else {
                tlstrpUserMute.Visible = true;
                tlstrpUnMute.Visible = false;
            }
        }

        private void btnUnban_Click(object sender, EventArgs e) {

        }

        private void btnRestart_Click(object sender, EventArgs e) {

        }

        private Point MousePos;

        private void lstUsers_MouseDown(object sender, MouseEventArgs e) {
            MousePos = e.Location;
        }
    }
}
