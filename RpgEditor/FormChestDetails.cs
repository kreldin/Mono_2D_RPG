using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RpgLibrary.Items;
using RpgLibrary.Skills;

namespace RpgEditor
{
    public partial class FormChestDetails : Form
    {
        public ChestData ChestData { get; set; }

        public FormChestDetails()
        {
            InitializeComponent();

            Load += FormChestDetails_Load;
            FormClosing += FormChestDetails_FormClosing;

            foreach (var s in Enum.GetNames(typeof(DifficultyLevel)))
                cboDifficulty.Items.Add(s);

            cboDifficulty.SelectedIndex = 0;

            cbLock.CheckedChanged += cbLock_CheckedChanged;
            cbTrap.CheckedChanged += cbTrap_CheckedChanged;

            btnAdd.Click += btnAdd_Click;
            btnRemove.Click += btnRemove_Click;

            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void FormChestDetails_Load(object sender, EventArgs e)
        {
            if (ChestData == null) return;

            tbName.Text = ChestData.Name;
            
            cbLock.Checked = ChestData.IsLocked;
            tbKeyName.Text = ChestData.KeyName;
            tbKeyType.Text = ChestData.KeyType;
            nudKeys.Value = ChestData.KeysRequired;

            tbKeyName.Enabled = ChestData.IsLocked;
            tbKeyType.Enabled = ChestData.IsLocked;
            nudKeys.Enabled = ChestData.IsLocked;

            cbTrap.Checked = ChestData.IsTrapped;
            tbTrap.Text = ChestData.TrapName;

            tbTrap.Enabled = ChestData.IsTrapped;

            nudMinGold.Value = ChestData.MinGold;
            nudMaxGold.Value = ChestData.MaxGold;
        }

        private static void FormChestDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        private void cbLock_CheckedChanged(object sender, EventArgs e)
        {
            cboDifficulty.Enabled = cbLock.Checked;
            tbKeyName.Enabled = cbLock.Checked;
            tbKeyType.Enabled = cbLock.Checked;
            nudKeys.Enabled = cbLock.Checked;
        }

        private void cbTrap_CheckedChanged(object sender, EventArgs e)
        {
            tbTrap.Enabled = cbTrap.Checked;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the ChestData.");
                return;
            }

            if (cbTrap.Checked && string.IsNullOrEmpty(tbTrap.Text))
            {
                MessageBox.Show("You must supply a name for the trap on the ChestData.");
                return;
            }

            if (nudMaxGold.Value < nudMinGold.Value)
            {
                MessageBox.Show("Maximum gold in ChestData must be greater or equal to minimum gold.");
                return;
            }

            var data = new ChestData
            {
                Name = tbName.Text,
                IsLocked = cbLock.Checked
            };


            if (cbLock.Checked)
            {
                data.DifficultyLevel = (DifficultyLevel)cboDifficulty.SelectedIndex;
                data.KeyName = tbKeyName.Text;
                data.KeyType = tbKeyType.Text;
                data.KeysRequired = (int)nudKeys.Value;
            }

            data.IsTrapped = cbTrap.Checked;

            if (cbTrap.Checked)
                data.TrapName = tbTrap.Text;

            data.MinGold = (int)nudMinGold.Value;
            data.MaxGold = (int)nudMaxGold.Value;

            ChestData = data;
            FormClosing -= FormChestDetails_FormClosing;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChestData = null;
            FormClosing -= FormChestDetails_FormClosing;
            Close();
        }
    }
}
