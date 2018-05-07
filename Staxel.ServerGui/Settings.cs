using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NimbusFox.ServerGui.Classes;
using Plukit.Base;

namespace NimbusFox.ServerGui {
    public partial class Settings : Form {
        public Settings() {
            InitializeComponent();
        }

        internal static Classes.Settings settings;

        internal static bool InitSettings => !File.Exists("./Settings.json");

        internal static void ReadSettings() {
            settings = new Classes.Settings();

            if (!InitSettings) {
                var blob = BlobAllocator.AcquireAllocator().NewBlob(false);

                blob.ReadJson(File.ReadAllText("./Settings.json"));

                settings.FromBlob(blob);
            }
        }

        internal static void WriteSettings() {
            var stream = new MemoryStream();

            settings.ToBlob().SaveJsonStream(stream);

            stream.Seek(0, SeekOrigin.Begin);

            File.WriteAllBytes("./Settings.json", stream.ReadAllBytes());
        }

        private void Settings_Load(object sender, EventArgs e) {
            ReadSettings();

            cmbxIP.Items.Add("Any IP");
            cmbxIP.SelectedText = settings.IP;

            var host = Dns.GetHostEntry(Dns.GetHostName());

            var ip6 = new List<string>();
            var ip4 = new List<string>();

            foreach (var ip in host.AddressList) {
                if (ip.IsIPv6LinkLocal || ip.IsIPv6Multicast || ip.IsIPv6SiteLocal || ip.IsIPv6Teredo) {
                    ip6.Add(ip.ToString());
                } else {
                    ip4.Add(ip.ToString());
                }
            }

            //cmbxIP.Items.Add("[IPV4]");

            foreach (var ip in ip4) {
                cmbxIP.Items.Add(ip);
            }

            //cmbxIP.Items.Add("[IPV6]");

            //foreach (var ip in ip6) {
            //    cmbxIP.Items.Add(ip);
            //}

            if (settings.Port > numPort.Maximum || settings.Port < numPort.Minimum) {
                settings.Port = 38465;
                WriteSettings();
            } else {
                numPort.Value = settings.Port;
            }

            chckPassword.Checked = settings.UsePassword;

            txtPassword.Text = settings.Password;

            chckPassword_CheckedChanged(sender, e);

            txtServerName.Text = settings.Name;

            txtWorldName.Text = settings.WorldName;

            numPlayerLimit.Value = settings.PlayerLimit;

            chckPublic.Checked = settings.Public;

            chckCreative.Checked = settings.Creative;

            chckUPNP.Checked = settings.Upnp;

            chckWeakAuthentication.Checked = settings.WeakAuthentication;

            if (InitSettings) {
                btnCancel.Enabled = false;
            }
        }

        private void chckPassword_CheckedChanged(object sender, EventArgs e) {
            txtPassword.Enabled = chckPassword.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            var ip6 = new List<string>();
            var ip4 = new List<string>();

            foreach (var ip in host.AddressList) {
                if (ip.IsIPv6LinkLocal || ip.IsIPv6Multicast || ip.IsIPv6SiteLocal || ip.IsIPv6Teredo) {
                    ip6.Add(ip.ToString());
                } else {
                    ip4.Add(ip.ToString());
                }
            }

            if (ip6.Contains(cmbxIP.Text) || ip4.Contains(cmbxIP.Text)) {
                settings.IP = cmbxIP.Text;
            } else {
                settings.IP = "0.0.0.0";
            }

            if (ushort.TryParse(numPort.Value.ToString(CultureInfo.InvariantCulture), out _)) {
                settings.Port = (long) numPort.Value;
            } else {
                settings.Port = 38465;
            }

            settings.UsePassword = chckPassword.Checked;

            settings.Password = txtPassword.Text;

            settings.Name = txtServerName.Text;

            settings.WorldName = txtWorldName.Text;

            if (long.TryParse(numPlayerLimit.Value.ToString(CultureInfo.InvariantCulture), out var output)) {
                settings.PlayerLimit = output;
            }

            settings.Public = chckPublic.Checked;
            settings.Creative = chckCreative.Checked;
            settings.Upnp = chckUPNP.Checked;
            settings.WeakAuthentication = chckWeakAuthentication.Checked;

            WriteSettings();

            Process.Start("NimbusFox.ServerGui.exe");

            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Global.Settings.Close();
            Global.Settings = new Settings();
            Global.Settings.Hide();
        }
    }
}
