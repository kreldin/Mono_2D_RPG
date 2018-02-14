using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormKey : FormDetails
    {
        public FormKey()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frmKeyDetails = new FormKeyDetails())
            {
                frmKeyDetails.ShowDialog();

                if (frmKeyDetails.Key != null)
                    AddKey(frmKeyDetails.Key);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem == null) return;

            var detail = lbDetails.SelectedItem.ToString();
            var parts = detail.Split(',');
            var entity = parts[0].Trim();

            var data = ItemDataManager.KeyData[entity];

            using (var frmKeyDetails = new FormKeyDetails())
            {
                frmKeyDetails.Key = data;
                frmKeyDetails.ShowDialog();

                if (frmKeyDetails.Key == null) return;

                if (frmKeyDetails.Key.Name == entity)
                {
                    ItemDataManager.KeyData[entity] = frmKeyDetails.Key;
                    FillListBox();
                    return;
                }

                var newData = frmKeyDetails.Key;

                var result = MessageBox.Show(
                    "Name has changed. Do you want to add a new entry?",
                    "New Entry",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No) return;

                if (ItemDataManager.KeyData.ContainsKey(newData.Name))
                {
                    MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                    return;
                }

                lbDetails.Items.Add(newData);
                ItemDataManager.KeyData.Add(newData.Name, newData);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem == null) return;

            var detail = lbDetails.SelectedItem.ToString();
            var parts = detail.Split(',');
            var entity = parts[0].Trim();

            var result = MessageBox.Show(
                "Are you sure you want to delete " + entity + "?",
                "Delete",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;

            lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
            ItemDataManager.KeyData.Remove(entity);

            if (File.Exists(FormMain.ItemPath + @"\Key\" + entity + ".xml"))
                File.Delete(FormMain.ItemPath + @"\Key" + entity + ".xml");
        }

        private void AddKey(KeyData keyData)
        {
            if (ItemDataManager.KeyData.ContainsKey(keyData.Name))
            {
                var result = MessageBox.Show(
                    keyData.Name + " already exists. Overwrite it?",
                    "Existing key",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No) return;

                ItemDataManager.KeyData[keyData.Name] = keyData;
                FillListBox();
                return;
            }

            ItemDataManager.KeyData.Add(keyData.Name, keyData);
            lbDetails.Items.Add(keyData);
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (var s in ItemDataManager.KeyData.Keys)
                lbDetails.Items.Add(ItemDataManager.KeyData[s]);
        }
    }
}
