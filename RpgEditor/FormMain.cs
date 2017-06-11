using System;
using System.Windows.Forms;

namespace RpgEditor
{
    public partial class FormMain : Form
    {
        private RolePlayingGame Game { get; set; }
        private FormClasses ClassesForm { get; set;  }
        private FormArmor ArmorForm { get; set; }
        private FormShield ShieldForm { get; set; }
        private FormWeapon WeaponForm { get; set; }

        public FormMain()
        {
            InitializeComponent();

            newGameToolStripMenuItem.Click += NewGameToolStripMenuItem_Click;
            openGameToolStripMenuItem.Click += OpenGameToolStripMenuItem_Click;
            saveGameToolStripMenuItem.Click += SaveGameToolStripMenuItem_Click;
            exitGameToolStripMenuItem.Click += ExitGameToolStripMenuItem_Click;

            classesToolStripMenuItem.Click += ClassesToolStripMenuItem_Click;
            armorToolStripMenuItem.Click += ArmorToolStripMenuItem_Click;
            shieldToolStripMenuItem.Click += ShieldToolStripMenuItem_Click;
            weaponToolStripMenuItem.Click += WeaponToolStripMenuItem_Click;
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var newGameForm = new FormNewGame())
            {
                var result = newGameForm.ShowDialog();

                if ((result != DialogResult.OK) || (newGameForm.Game == null))
                    return;

                classesToolStripMenuItem.Enabled = true;
                itemsToolStripMenuItem.Enabled = true;
                Game = newGameForm.Game;
            }
        }

        private void OpenGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClassesForm == null)
                ClassesForm = new FormClasses { MdiParent = this };

            ClassesForm.Show();
        }

        private void ArmorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ArmorForm == null)
                ArmorForm = new FormArmor { MdiParent = this };

            ArmorForm.Show();
        }

        private void ShieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShieldForm == null)
                ShieldForm = new FormShield { MdiParent = this };

            ShieldForm.Show();
        }


        private void WeaponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WeaponForm == null)
                WeaponForm = new FormWeapon { MdiParent = this };

            WeaponForm.Show();
        }
    }
}
