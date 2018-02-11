using System;
using System.IO;
using System.Windows.Forms;
using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormShield
    {
        public FormShield()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frmShieldDetails = new FormShieldDetails())
            {
                frmShieldDetails.ShowDialog();

                if (frmShieldDetails.Shield != null)
                    AddShield(frmShieldDetails.Shield);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem == null) return;

            var detail = lbDetails.SelectedItem.ToString();
            var parts = detail.Split(',');
            var entity = parts[0].Trim();

            var data = ItemDataManager.ShieldData[entity];
            ShieldData newData;

            using (var frmShieldData = new FormShieldDetails())
            {
                frmShieldData.Shield = data;
                frmShieldData.ShowDialog();

                if (frmShieldData.Shield == null)
                    return;

                if (frmShieldData.Shield.Name == entity)
                {
                    ItemDataManager.ShieldData[entity] = frmShieldData.Shield;
                    FillListBox();
                    return;
                }

                newData = frmShieldData.Shield;
            }

            var result = MessageBox.Show(
                "Name has changed. Do you want to add a new entry?",
                "New Entry",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            if (ItemDataManager.ShieldData.ContainsKey(newData.Name))
            {
                MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                return;
            }

            lbDetails.Items.Add(newData);
            ItemDataManager.ShieldData.Add(newData.Name, newData);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem == null) return;

            var detail = (string) lbDetails.SelectedItem;
            var parts = detail.Split(',');
            var entity = parts[0].Trim();

            var result = MessageBox.Show(
                "Are you sure you want to delete " + entity + "?",
                "Delete",
                MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes) return;

            lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
            ItemDataManager.ShieldData.Remove(entity);

            if (File.Exists(FormMain.ItemPath + @"\Shield\" + entity + ".xml"))
                File.Delete(FormMain.ItemPath + @"\Shield\" + entity + ".xml");
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (var s in ItemDataManager.ShieldData.Keys)
                lbDetails.Items.Add(ItemDataManager.ShieldData[s]);
        }

        private void AddShield(ShieldData shieldData)
        {
            if (ItemDataManager.ShieldData.ContainsKey(shieldData.Name))
            {
                var result = MessageBox.Show(
                    shieldData.Name + " already exists. Overwrite it?",
                    "Existing shield",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                ItemDataManager.ShieldData[shieldData.Name] = shieldData;
                FillListBox();
                return;
            }

            ItemDataManager.ShieldData.Add(shieldData.Name, shieldData);
            lbDetails.Items.Add(shieldData);
        }
    }
}
