using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormShieldDetails : Form
    {
        public ShieldData Shield { get; set; }

        public FormShieldDetails()
        {
            InitializeComponent();

            Load += FormShieldDetails_Load;
            FormClosing += FormShieldDetails_FormClosing;

            btnMoveAllowed.Click += btnMoveAllowed_Click;
            btnRemoveAllowed.Click += btnRemoveAllowed_Click;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void FormShieldDetails_Load(object sender, EventArgs e)
        {
            foreach (var s in FormDetails.EntityDataManager.EntityData.Keys)
                lbClasses.Items.Add(s);

            if (Shield == null) return;

            tbName.Text = Shield.Name;
            tbType.Text = Shield.Type;
            mtbPrice.Text = Shield.Price.ToString();
            nudWeight.Value = (decimal) Shield.Weight;
            mtbDefenseValue.Text = Shield.DefenseValue.ToString();
            mtbDefenseModifier.Text = Shield.DefenseModifier.ToString();

            foreach (var s in Shield.AllowableClasses)
            {
                if (lbClasses.Items.Contains(s))
                    lbClasses.Items.Remove(s);

                lbAllowedClasses.Items.Add(s);
            }
        }

        private static void FormShieldDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        private void btnMoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbClasses.SelectedItem == null) return;

            lbAllowedClasses.Items.Add(lbClasses.SelectedItem);
            lbClasses.Items.RemoveAt(lbClasses.SelectedIndex);
        }

        private void btnRemoveAllowed_Click(object sender, EventArgs e)
        {
            if (lbAllowedClasses.SelectedItem == null) return;

            lbClasses.Items.Add(lbAllowedClasses.SelectedItem);
            lbAllowedClasses.Items.RemoveAt(lbAllowedClasses.SelectedIndex);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must enter a name for the item.");
                return;
            }

            if (!int.TryParse(mtbPrice.Text, out int price))
            {
                MessageBox.Show("Price must be an integer value.");
                return;
            }

            var weight = (float) nudWeight.Value;

            if (!int.TryParse(mtbDefenseValue.Text, out int defVal))
            {
                MessageBox.Show("Defense valule must be an interger value.");
                return;
            }

            if (!int.TryParse(mtbDefenseModifier.Text, out int defMod))
            {
                MessageBox.Show("Defense valule must be an interger value.");
                return;
            }

            Shield = new ShieldData
            {
                Name = tbName.Text,
                Type = tbType.Text,
                Price = price,
                Weight = weight,
                DefenseValue = defVal,
                DefenseModifier = defMod,
                AllowableClasses = (from object o in lbAllowedClasses.Items select o.ToString()).ToArray()
            };

            FormClosing -= FormShieldDetails_FormClosing;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Shield = null;
            FormClosing -= FormShieldDetails_FormClosing;
            Close();
        }
    }
}
