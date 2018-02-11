using System;
using System.IO;
using System.Windows.Forms;
using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormArmor
    {
        public FormArmor()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frmArmorDetails = new FormArmorDetails())
            {
                frmArmorDetails.ShowDialog();

                if (frmArmorDetails.Armor != null)
                    AddArmor(frmArmorDetails.Armor);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem != null)
            {
                var detail = lbDetails.SelectedItem.ToString();
                var parts = detail.Split(',');
                var entity = parts[0].Trim();

                var data = ItemDataManager.ArmorData[entity];
                ArmorData newData;

                using (var frmArmorData = new FormArmorDetails())
                {
                    frmArmorData.Armor = data;
                    frmArmorData.ShowDialog();

                    if (frmArmorData.Armor == null)
                        return;

                    if (frmArmorData.Armor.Name == entity)
                    {
                        ItemDataManager.ArmorData[entity] = frmArmorData.Armor;
                        FillListBox();
                        return;
                    }

                    newData = frmArmorData.Armor;
                }

                var result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                if (ItemDataManager.ArmorData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                ItemDataManager.ArmorData.Add(newData.Name, newData);
            }
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
            ItemDataManager.ArmorData.Remove(entity);

            if (File.Exists(FormMain.ItemPath + @"\Armor\" + entity + ".xml"))
                File.Delete(FormMain.ItemPath + @"\Armor\" + entity + ".xml");
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (var s in ItemDataManager.ArmorData.Keys)
                lbDetails.Items.Add(ItemDataManager.ArmorData[s]);
        }

        private void AddArmor(ArmorData armorData)
        {
            if (ItemDataManager.ArmorData.ContainsKey(armorData.Name))
            {
                var result = MessageBox.Show(
                    armorData.Name + " already exists. Overwrite it?",
                    "Existing armor",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                ItemDataManager.ArmorData[armorData.Name] = armorData;
                FillListBox();
                return;
            }

            ItemDataManager.ArmorData.Add(armorData.Name, armorData);
            lbDetails.Items.Add(armorData);
        }
    }
}
