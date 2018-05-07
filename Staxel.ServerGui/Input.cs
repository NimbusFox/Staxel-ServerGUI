using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimbusFox.ServerGui {
    public partial class Input : Form {

        private readonly Func<string, bool> _onConfirm;

        private readonly Action _onCancel;

        public Input(string title, string message, Func<string, bool> onConfirm, Action onCancel = null, string defaultValue = "", string confirm = "Confirm", string cancel = "Cancel") {
            InitializeComponent();

            Text = title;

            lblText.Text = message;

            txtInput.Text = defaultValue;

            btnConfirm.Text = confirm;

            btnCancel.Text = cancel;

            _onConfirm = onConfirm;

            _onCancel = onCancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            if (_onConfirm(txtInput.Text)) {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            _onCancel?.Invoke();
            Close();
        }
    }
}
