using System;
using System.Windows.Forms;

using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormArmorDetails : Form
    {
        public Armor Armor { get; set; }

        public FormArmorDetails()
        {
            InitializeComponent();

            Load += FormArmorDetails_Load;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void FormArmorDetails_Load(object sender, EventArgs e)
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
