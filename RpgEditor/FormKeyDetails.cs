using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormKeyDetails : Form
    {
        public KeyData Key { get; set; }


        public FormKeyDetails()
        {
            InitializeComponent();

            Load += FormKeyDetails_Load;
            FormClosing += FormKeyDetails_FormClosing;

            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void FormKeyDetails_Load(object sender, EventArgs e)
        {
            if (Key == null) return;

            tbName.Text = Key.Name;
            tbType.Text = Key.Type;
        }

        private static void FormKeyDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                 e.Cancel = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item.");
                return;
            }

            Key = new KeyData
            {
                Name = tbName.Text,
                Type = tbType.Text
            };

            FormClosing -= FormKeyDetails_FormClosing;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Key = null;
            FormClosing -= FormKeyDetails_FormClosing;
            Close();
        }
    }
}
