using System;
using System.Windows.Forms;
using RpgLibrary;

namespace RpgEditor
{
    public partial class FormNewGame : Form
    {
        public RolePlayingGame Game { get; private set; }

        public FormNewGame()
        {
            InitializeComponent();
            btnOK.Click += BtnOK_Click;
        }

        private bool IsValidGame()
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbDescription.Text))
                return true;

            MessageBox.Show(@"You must enter a name and a description.", @"Error");
            return false;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!IsValidGame())
                return;

            Game = new RolePlayingGame(tbName.Text, tbDescription.Text);

            Close();
        }
    }
}
