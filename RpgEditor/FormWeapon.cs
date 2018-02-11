using System;
using System.IO;
using System.Windows.Forms;
using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormWeapon
    {
        public FormWeapon()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frmWeaponDetails = new FormWeaponDetails())
            {
                frmWeaponDetails.ShowDialog();

                if (frmWeaponDetails.Weapon != null)
                    AddWeapon(frmWeaponDetails.Weapon);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem == null) return;

            var detail = lbDetails.SelectedItem.ToString();
            var parts = detail.Split(',');
            var entity = parts[0].Trim();

            var data = ItemDataManager.WeaponData[entity];
            WeaponData newData;

            using (var frmWeaponData = new FormWeaponDetails())
            {
                frmWeaponData.Weapon = data;
                frmWeaponData.ShowDialog();

                if (frmWeaponData.Weapon == null)
                    return;

                if (frmWeaponData.Weapon.Name == entity)
                {
                    ItemDataManager.WeaponData[entity] = frmWeaponData.Weapon;
                    FillListBox();
                    return;
                }

                newData = frmWeaponData.Weapon;
            }

            var result = MessageBox.Show(
                "Name has changed. Do you want to add a new entry?",
                "New Entry",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            if (ItemDataManager.WeaponData.ContainsKey(newData.Name))
            {
                MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                return;
            }

            lbDetails.Items.Add(newData);
            ItemDataManager.WeaponData.Add(newData.Name, newData);
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
            ItemDataManager.WeaponData.Remove(entity);

            if (File.Exists(FormMain.ItemPath + @"\Weapon\" + entity + ".xml"))
                File.Delete(FormMain.ItemPath + @"\Weapon\" + entity + ".xml");
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (var s in ItemDataManager.WeaponData.Keys)
                lbDetails.Items.Add(ItemDataManager.WeaponData[s]);
        }

        private void AddWeapon(WeaponData weaponData)
        {
            if (ItemDataManager.WeaponData.ContainsKey(weaponData.Name))
            {
                var result = MessageBox.Show(
                    weaponData.Name + " already exists. Overwrite it?",
                    "Existing weapon",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                ItemDataManager.WeaponData[weaponData.Name] = weaponData;
                FillListBox();
                return;
            }

            ItemDataManager.WeaponData.Add(weaponData.Name, weaponData);
            lbDetails.Items.Add(weaponData);
        }
    }
}
