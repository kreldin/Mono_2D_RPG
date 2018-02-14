using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormChest : FormDetails
    {
        public FormChest()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frmChestDetails = new FormChestDetails())
            {
                frmChestDetails.ShowDialog();

                if (frmChestDetails.ChestData != null)
                {
                    AddChest(frmChestDetails.ChestData);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem == null) return;

            var detail = lbDetails.SelectedItem.ToString();
            var parts = detail.Split(',');
            var entity = parts[0].Trim();

            var data = ItemDataManager.ChestData[entity];
            ChestData newData;

            using (var frmChestData = new FormChestDetails())
            {
                frmChestData.ChestData = data;
                frmChestData.ShowDialog();

                if (frmChestData.ChestData == null)
                    return;

                if (frmChestData.ChestData.Name == entity)
                {
                    ItemDataManager.ChestData[entity] = frmChestData.ChestData;
                    FillListBox();
                    return;
                }

                newData = frmChestData.ChestData;
            }

            var result = MessageBox.Show(
                "Name has changed. Do you want to add a new entry?",
                "New Entry",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            if (ItemDataManager.ChestData.ContainsKey(newData.Name))
            {
                MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                return;
            }

            lbDetails.Items.Add(newData);
            ItemDataManager.ChestData.Add(newData.Name, newData);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem == null) return;

            var detail = (string)lbDetails.SelectedItem;
            var parts = detail.Split(',');
            var entity = parts[0].Trim();

            var result = MessageBox.Show(
                "Are you sure you want to delete " + entity + "?",
                "Delete",
                MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes) return;

            lbDetails.Items.RemoveAt(lbDetails.SelectedIndex);
            ItemDataManager.ChestData.Remove(entity);

            if (File.Exists(FormMain.ItemPath + @"\Chest\" + entity + ".xml"))
                File.Delete(FormMain.ItemPath + @"\Chest\" + entity + ".xml");
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (string s in FormDetails.ItemDataManager.ChestData.Keys)
                lbDetails.Items.Add(FormDetails.ItemDataManager.ChestData[s]);
        }

        private void AddChest(ChestData ChestData)
        {
            if (FormDetails.ItemDataManager.ChestData.ContainsKey(ChestData.Name))
            {
                var result = MessageBox.Show(
                    ChestData.Name + " already exists. Overwrite it?",
                    "Existing Chest",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                ItemDataManager.ChestData[ChestData.Name] = ChestData;
                FillListBox();
                return;
            }

            ItemDataManager.ChestData.Add(ChestData.Name, ChestData);
            lbDetails.Items.Add(ChestData);
        }
    }
}
