using System;
using System.IO;
using System.Windows.Forms;
using RpgLibrary;

namespace RpgEditor
{
    public partial class FormMain : Form
    {
        private RolePlayingGame Game { get; set; }
        private FormClasses ClassesForm { get; set; }
        private FormArmor ArmorForm { get; set; }
        private FormShield ShieldForm { get; set; }
        private FormWeapon WeaponForm { get; set; }
        private FormChest ChestForm { get; set; }
        private FormKey KeyForm { get; set; }

        public static string GamePath  { get; private set; }
        public static string ClassPath { get; private set; }
        public static string ItemPath { get; private set; }
        public static string ChestPath { get; private set; }
        public static string KeyPath { get; private set; }

        public FormMain()
        {
            InitializeComponent();

            FormClosing += FormMain_FormClosing;

            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            openGameToolStripMenuItem.Click += openGameToolStripMenuItem_Click;
            saveGameToolStripMenuItem.Click += saveGameToolStripMenuItem_Click;
            exitGameToolStripMenuItem.Click += exitGameToolStripMenuItem_Click;

            classesToolStripMenuItem.Click += classesToolStripMenuItem_Click;
            armorToolStripMenuItem.Click += armorToolStripMenuItem_Click;
            shieldToolStripMenuItem.Click += shieldToolStripMenuItem_Click;
            weaponToolStripMenuItem.Click += weaponToolStripMenuItem_Click;

            keysToolStripMenuItem.Click += keysToolStripMenuItem_Click;
            chestsToolStripMenuItem.Click += chestsToolStripMenuItem_Click;
        }

        private static void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Unsaved changes will be lost. Are you sure you want to exit?",
                "Exit?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frmNewGame = new FormNewGame())
            {
                var result = frmNewGame.ShowDialog();

                if ((result != DialogResult.OK) || (frmNewGame.Game == null)) return;

                var folderDialog = new FolderBrowserDialog
                {
                    Description = "Select folder to create game in.",
                    SelectedPath = Application.StartupPath
                };


                var folderResult = folderDialog.ShowDialog();

                if (folderResult != DialogResult.OK) return;

                try
                {

                    GamePath = Path.Combine(folderDialog.SelectedPath, "Game");
                    ClassPath = Path.Combine(GamePath, "Classes");
                    ItemPath = Path.Combine(GamePath, "Items");
                    KeyPath = Path.Combine(GamePath, "Keys");
                    ChestPath = Path.Combine(GamePath, "Chests");

                    if (Directory.Exists(GamePath))
                        throw new Exception("Selected directory already exists.");

                    Directory.CreateDirectory(GamePath);
                    Directory.CreateDirectory(ClassPath);
                    Directory.CreateDirectory(ItemPath + @"\Armor");
                    Directory.CreateDirectory(ItemPath + @"\Shield");
                    Directory.CreateDirectory(ItemPath + @"\Weapon");
                    Directory.CreateDirectory(KeyPath);
                    Directory.CreateDirectory(ChestPath);

                    Game = frmNewGame.Game;
                    XmlSerializer.Serialize(GamePath + @"\Game.xml", Game);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }

                classesToolStripMenuItem.Enabled = true;
                itemsToolStripMenuItem.Enabled = true;
                keysToolStripMenuItem.Enabled = true;
                chestsToolStripMenuItem.Enabled = true;
            }
        }

        private void openGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog
            {
                Description = "Select Game folder",
                SelectedPath = Application.StartupPath
            };


            var tryAgain = false;

            do
            {
                var folderResult = folderDialog.ShowDialog();

                if (folderResult != DialogResult.OK) continue;

                DialogResult msgBoxResult;

                if (File.Exists(folderDialog.SelectedPath + @"\Game\Game.xml"))
                {
                    try
                    {
                        OpenGame(folderDialog.SelectedPath);
                        tryAgain = false;
                    }
                    catch (Exception ex)
                    {
                        msgBoxResult = MessageBox.Show(
                            ex.ToString(),
                            "Error opening game.",
                            MessageBoxButtons.RetryCancel);

                        if (msgBoxResult == DialogResult.Cancel)
                            tryAgain = false;
                        else if (msgBoxResult == DialogResult.Retry)
                            tryAgain = true;
                    }
                }
                else
                {
                    msgBoxResult = MessageBox.Show(
                        "Game not found, try again?",
                        "Game does not exist",
                        MessageBoxButtons.RetryCancel);

                    switch (msgBoxResult)
                    {
                        case DialogResult.Cancel:
                            tryAgain = false;
                            break;
                        case DialogResult.Retry:
                            tryAgain = true;
                            break;
                    }
                }
            } while (tryAgain);
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Game == null) return;

            try
            {
                XmlSerializer.Serialize<RolePlayingGame>(GamePath + @"\Game.xml", Game);
                FormDetails.WriteEntityData();
                FormDetails.WriteItemData();
                FormDetails.WriteChestData();
                FormDetails.WriteKeyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error saving game.");
            }
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClassesForm == null)
                ClassesForm = new FormClasses { MdiParent = this };

            ClassesForm.Show();
            ClassesForm.BringToFront();
        }

        private void armorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ArmorForm == null)
                ArmorForm = new FormArmor { MdiParent = this };

            ArmorForm.Show();
            ArmorForm.BringToFront();
        }

        private void shieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShieldForm == null)
            {
                ShieldForm = new FormShield { MdiParent = this };
            }

            ShieldForm.Show();
            ShieldForm.BringToFront();
        }

        private void weaponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WeaponForm == null)
            {
                WeaponForm = new FormWeapon { MdiParent = this };
            }

            WeaponForm.Show();
            WeaponForm.BringToFront();
        }

        private void keysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KeyForm == null)
                KeyForm = new FormKey
                {
                    MdiParent = this
                };

            KeyForm.Show();
            KeyForm.BringToFront();
        }

        private void chestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChestForm == null)
                ChestForm = new FormChest
                {
                    MdiParent = this
                };

            ChestForm.Show();
            ChestForm.BringToFront();
        }

        private void OpenGame(string path)
        {
            GamePath = Path.Combine(path, "Game");
            ClassPath = Path.Combine(GamePath, "Classes");
            ItemPath = Path.Combine(GamePath, "Items");
            KeyPath = Path.Combine(GamePath, "Keys");
            ChestPath = Path.Combine(GamePath, "Chests");

            Game = XmlSerializer.Deserialize<RolePlayingGame>(
                GamePath + @"\Game.xml");

            FormDetails.ReadEntityData();
            FormDetails.ReadItemData();
            FormDetails.ReadKeyData();
            FormDetails.ReadChestData();

            PrepareForms();
        }

        private void PrepareForms()
        {
            if (ClassesForm == null)
            {
                ClassesForm = new FormClasses { MdiParent = this };
            }

            ClassesForm.FillListBox();

            if (ArmorForm == null)
            {
                ArmorForm = new FormArmor { MdiParent = this };
            }

            ArmorForm.FillListBox();

            if (ShieldForm == null)
            {
                ShieldForm = new FormShield { MdiParent = this };
            }

            ShieldForm.FillListBox();

            if (WeaponForm == null)
            {
                WeaponForm = new FormWeapon { MdiParent = this };
            }

            WeaponForm.FillListBox();

            if (KeyForm == null)
            {
                KeyForm = new FormKey { MdiParent = this };
            }

            KeyForm.FillListBox();

            if (ChestForm == null)
            {
                ChestForm = new FormChest { MdiParent = this };
            }

            ChestForm.FillListBox();

            classesToolStripMenuItem.Enabled = true;
            itemsToolStripMenuItem.Enabled = true;
            keysToolStripMenuItem.Enabled = true;
            chestsToolStripMenuItem.Enabled = true;
        }
    }
}
