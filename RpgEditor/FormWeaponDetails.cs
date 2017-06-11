using System;
using System.Windows.Forms;

using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormWeaponDetails : Form
    {
        public Weapon Weapon { get; set; }

        public FormWeaponDetails()
        {
            InitializeComponent();

            Load += FormWeaponDetails_Load;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void FormWeaponDetails_Load(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
