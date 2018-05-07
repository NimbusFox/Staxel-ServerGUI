namespace NimbusFox.ServerGui {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.wbLog = new System.Windows.Forms.WebBrowser();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtServerMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.cntxtMnUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlStripUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpUserKick = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpUserBan = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpUserMute = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpUnMute = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpUserWhisper = new System.Windows.Forms.ToolStripMenuItem();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.btnUnban = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.cntxtMnUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbLog
            // 
            this.wbLog.AllowNavigation = false;
            this.wbLog.AllowWebBrowserDrop = false;
            this.wbLog.IsWebBrowserContextMenuEnabled = false;
            this.wbLog.Location = new System.Drawing.Point(3, 2);
            this.wbLog.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbLog.Name = "wbLog";
            this.wbLog.Size = new System.Drawing.Size(640, 407);
            this.wbLog.TabIndex = 0;
            this.wbLog.TabStop = false;
            this.wbLog.WebBrowserShortcutsEnabled = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(649, 417);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtServerMessage
            // 
            this.txtServerMessage.Location = new System.Drawing.Point(3, 418);
            this.txtServerMessage.Name = "txtServerMessage";
            this.txtServerMessage.Size = new System.Drawing.Size(579, 20);
            this.txtServerMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(588, 417);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(55, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(730, 417);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(58, 23);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // cntxtMnUser
            // 
            this.cntxtMnUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlStripUser,
            this.tlstrpUserKick,
            this.tlstrpUserBan,
            this.tlstrpUserMute,
            this.tlstrpUnMute,
            this.tlstrpUserWhisper});
            this.cntxtMnUser.Name = "cntxtMnUser";
            this.cntxtMnUser.Size = new System.Drawing.Size(181, 158);
            this.cntxtMnUser.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtMnUser_Opening);
            // 
            // tlStripUser
            // 
            this.tlStripUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlStripUser.Enabled = false;
            this.tlStripUser.Name = "tlStripUser";
            this.tlStripUser.Size = new System.Drawing.Size(180, 22);
            this.tlStripUser.Text = "User";
            // 
            // tlstrpUserKick
            // 
            this.tlstrpUserKick.Name = "tlstrpUserKick";
            this.tlstrpUserKick.Size = new System.Drawing.Size(180, 22);
            this.tlstrpUserKick.Text = "Kick";
            this.tlstrpUserKick.Click += new System.EventHandler(this.tlstrpUserKick_Click);
            // 
            // tlstrpUserBan
            // 
            this.tlstrpUserBan.Name = "tlstrpUserBan";
            this.tlstrpUserBan.Size = new System.Drawing.Size(180, 22);
            this.tlstrpUserBan.Text = "Ban";
            this.tlstrpUserBan.Click += new System.EventHandler(this.tlstrpUserBan_Click);
            // 
            // tlstrpUserMute
            // 
            this.tlstrpUserMute.Name = "tlstrpUserMute";
            this.tlstrpUserMute.Size = new System.Drawing.Size(180, 22);
            this.tlstrpUserMute.Text = "Mute";
            this.tlstrpUserMute.Click += new System.EventHandler(this.tlstrpUserMute_Click);
            // 
            // tlstrpUnMute
            // 
            this.tlstrpUnMute.Name = "tlstrpUnMute";
            this.tlstrpUnMute.Size = new System.Drawing.Size(180, 22);
            this.tlstrpUnMute.Text = "Unmute";
            this.tlstrpUnMute.Click += new System.EventHandler(this.tlstrpUnMute_Click);
            // 
            // tlstrpUserWhisper
            // 
            this.tlstrpUserWhisper.Name = "tlstrpUserWhisper";
            this.tlstrpUserWhisper.Size = new System.Drawing.Size(180, 22);
            this.tlstrpUserWhisper.Text = "Whisper";
            this.tlstrpUserWhisper.Click += new System.EventHandler(this.tlstrpUserWhisper_Click);
            // 
            // lstUsers
            // 
            this.lstUsers.ContextMenuStrip = this.cntxtMnUser;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(649, 2);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.ScrollAlwaysVisible = true;
            this.lstUsers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstUsers.Size = new System.Drawing.Size(149, 381);
            this.lstUsers.Sorted = true;
            this.lstUsers.TabIndex = 7;
            this.lstUsers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstUsers_MouseDown);
            // 
            // btnUnban
            // 
            this.btnUnban.Location = new System.Drawing.Point(730, 389);
            this.btnUnban.Name = "btnUnban";
            this.btnUnban.Size = new System.Drawing.Size(58, 23);
            this.btnUnban.TabIndex = 8;
            this.btnUnban.Text = "Unban";
            this.btnUnban.UseVisualStyleBackColor = true;
            this.btnUnban.Click += new System.EventHandler(this.btnUnban_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(650, 390);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(74, 23);
            this.btnRestart.TabIndex = 9;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // Main
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnUnban);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtServerMessage);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.wbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staxel Server GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.cntxtMnUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbLog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtServerMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ContextMenuStrip cntxtMnUser;
        private System.Windows.Forms.ToolStripMenuItem tlstrpUserKick;
        private System.Windows.Forms.ToolStripMenuItem tlstrpUserBan;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.ToolStripMenuItem tlstrpUserMute;
        private System.Windows.Forms.ToolStripMenuItem tlstrpUserWhisper;
        private System.Windows.Forms.ToolStripMenuItem tlstrpUnMute;
        private System.Windows.Forms.Button btnUnban;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.ToolStripMenuItem tlStripUser;
    }
}

