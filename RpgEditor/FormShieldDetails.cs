using System;
using System.Windows.Forms;

using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormShieldDetails : Form
    {

        public Shield Shield { get; set; }

        public FormShieldDetails()
        {
            InitializeComponent();

            Load +=  FormShieldDetails_Load;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        #region Event Handler Region

        private void FormShieldDetails_Load(object sender, EventArgs e)
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

        #endregion
    }
}
