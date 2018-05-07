namespace NimbusFox.ServerGui {
    partial class Settings {
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
            this.cmbxIP = new System.Windows.Forms.ComboBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.chckPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblWorldName = new System.Windows.Forms.Label();
            this.txtWorldName = new System.Windows.Forms.TextBox();
            this.lblPlayerLimit = new System.Windows.Forms.Label();
            this.numPlayerLimit = new System.Windows.Forms.NumericUpDown();
            this.grpExtras = new System.Windows.Forms.GroupBox();
            this.chckWeakAuthentication = new System.Windows.Forms.CheckBox();
            this.chckUPNP = new System.Windows.Forms.CheckBox();
            this.chckCreative = new System.Windows.Forms.CheckBox();
            this.chckPublic = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerLimit)).BeginInit();
            this.grpExtras.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbxIP
            // 
            this.cmbxIP.FormattingEnabled = true;
            this.cmbxIP.Location = new System.Drawing.Point(92, 10);
            this.cmbxIP.Name = "cmbxIP";
            this.cmbxIP.Size = new System.Drawing.Size(151, 21);
            this.cmbxIP.TabIndex = 0;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(12, 13);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(17, 13);
            this.lblIP.TabIndex = 1;
            this.lblIP.Text = "IP";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 51);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(92, 49);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(151, 20);
            this.numPort.TabIndex = 3;
            this.numPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chckPassword
            // 
            this.chckPassword.AutoSize = true;
            this.chckPassword.Location = new System.Drawing.Point(12, 87);
            this.chckPassword.Name = "chckPassword";
            this.chckPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chckPassword.Size = new System.Drawing.Size(72, 17);
            this.chckPassword.TabIndex = 5;
            this.chckPassword.Text = "Password";
            this.chckPassword.UseVisualStyleBackColor = true;
            this.chckPassword.CheckedChanged += new System.EventHandler(this.chckPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(92, 85);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(151, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(12, 127);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(69, 13);
            this.lblServerName.TabIndex = 7;
            this.lblServerName.Text = "Server Name";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(92, 124);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(151, 20);
            this.txtServerName.TabIndex = 8;
            // 
            // lblWorldName
            // 
            this.lblWorldName.AutoSize = true;
            this.lblWorldName.Location = new System.Drawing.Point(13, 168);
            this.lblWorldName.Name = "lblWorldName";
            this.lblWorldName.Size = new System.Drawing.Size(66, 13);
            this.lblWorldName.TabIndex = 9;
            this.lblWorldName.Text = "World Name";
            // 
            // txtWorldName
            // 
            this.txtWorldName.Location = new System.Drawing.Point(92, 165);
            this.txtWorldName.Name = "txtWorldName";
            this.txtWorldName.Size = new System.Drawing.Size(151, 20);
            this.txtWorldName.TabIndex = 10;
            // 
            // lblPlayerLimit
            // 
            this.lblPlayerLimit.AutoSize = true;
            this.lblPlayerLimit.Location = new System.Drawing.Point(13, 210);
            this.lblPlayerLimit.Name = "lblPlayerLimit";
            this.lblPlayerLimit.Size = new System.Drawing.Size(60, 13);
            this.lblPlayerLimit.TabIndex = 11;
            this.lblPlayerLimit.Text = "Player Limit";
            // 
            // numPlayerLimit
            // 
            this.numPlayerLimit.Location = new System.Drawing.Point(92, 208);
            this.numPlayerLimit.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPlayerLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPlayerLimit.Name = "numPlayerLimit";
            this.numPlayerLimit.Size = new System.Drawing.Size(151, 20);
            this.numPlayerLimit.TabIndex = 12;
            this.numPlayerLimit.ThousandsSeparator = true;
            this.numPlayerLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grpExtras
            // 
            this.grpExtras.Controls.Add(this.chckWeakAuthentication);
            this.grpExtras.Controls.Add(this.chckUPNP);
            this.grpExtras.Controls.Add(this.chckCreative);
            this.grpExtras.Controls.Add(this.chckPublic);
            this.grpExtras.Location = new System.Drawing.Point(13, 242);
            this.grpExtras.Name = "grpExtras";
            this.grpExtras.Size = new System.Drawing.Size(230, 85);
            this.grpExtras.TabIndex = 13;
            this.grpExtras.TabStop = false;
            this.grpExtras.Text = "Extras";
            // 
            // chckWeakAuthentication
            // 
            this.chckWeakAuthentication.AutoSize = true;
            this.chckWeakAuthentication.Location = new System.Drawing.Point(6, 43);
            this.chckWeakAuthentication.Name = "chckWeakAuthentication";
            this.chckWeakAuthentication.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chckWeakAuthentication.Size = new System.Drawing.Size(126, 17);
            this.chckWeakAuthentication.TabIndex = 3;
            this.chckWeakAuthentication.Text = "Weak Authentication";
            this.chckWeakAuthentication.UseVisualStyleBackColor = true;
            // 
            // chckUPNP
            // 
            this.chckUPNP.AutoSize = true;
            this.chckUPNP.Location = new System.Drawing.Point(139, 19);
            this.chckUPNP.Name = "chckUPNP";
            this.chckUPNP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chckUPNP.Size = new System.Drawing.Size(56, 17);
            this.chckUPNP.TabIndex = 2;
            this.chckUPNP.Text = "UPNP";
            this.chckUPNP.UseVisualStyleBackColor = true;
            // 
            // chckCreative
            // 
            this.chckCreative.AutoSize = true;
            this.chckCreative.Location = new System.Drawing.Point(68, 19);
            this.chckCreative.Name = "chckCreative";
            this.chckCreative.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chckCreative.Size = new System.Drawing.Size(65, 17);
            this.chckCreative.TabIndex = 1;
            this.chckCreative.Text = "Creative";
            this.chckCreative.UseVisualStyleBackColor = true;
            // 
            // chckPublic
            // 
            this.chckPublic.AutoSize = true;
            this.chckPublic.Location = new System.Drawing.Point(7, 20);
            this.chckPublic.Name = "chckPublic";
            this.chckPublic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chckPublic.Size = new System.Drawing.Size(55, 17);
            this.chckPublic.TabIndex = 0;
            this.chckPublic.Text = "Public";
            this.chckPublic.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 333);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(168, 333);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 363);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpExtras);
            this.Controls.Add(this.numPlayerLimit);
            this.Controls.Add(this.lblPlayerLimit);
            this.Controls.Add(this.txtWorldName);
            this.Controls.Add(this.lblWorldName);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chckPassword);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.cmbxIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerLimit)).EndInit();
            this.grpExtras.ResumeLayout(false);
            this.grpExtras.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.CheckBox chckPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblWorldName;
        private System.Windows.Forms.TextBox txtWorldName;
        private System.Windows.Forms.Label lblPlayerLimit;
        private System.Windows.Forms.NumericUpDown numPlayerLimit;
        private System.Windows.Forms.GroupBox grpExtras;
        private System.Windows.Forms.CheckBox chckPublic;
        private System.Windows.Forms.CheckBox chckCreative;
        private System.Windows.Forms.CheckBox chckUPNP;
        private System.Windows.Forms.CheckBox chckWeakAuthentication;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}