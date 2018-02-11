using System;
using System.IO;
using System.Windows.Forms;
using RpgLibrary.Characters;

namespace RpgEditor
{
    public partial class FormClasses
    {
        public FormClasses()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frmEntityData = new FormEntityData())
            {
                frmEntityData.ShowDialog();

                if (frmEntityData.EntityData != null)
                    AddEntity(frmEntityData.EntityData);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem == null) return;

            var detail = lbDetails.SelectedItem.ToString();
            var parts = detail.Split(',');
            var entity = parts[0].Trim();

            var data = EntityDataManager.EntityData[entity];
            EntityData newData;

            using (var frmEntityData = new FormEntityData())
            {
                frmEntityData.EntityData = data;
                frmEntityData.ShowDialog();

                if (frmEntityData.EntityData == null)
                    return;

                if (frmEntityData.EntityData.Name == entity)
                {
                    EntityDataManager.EntityData[entity] = frmEntityData.EntityData;
                    FillListBox();
                    return;
                }

                newData = frmEntityData.EntityData;
            }

            var result = MessageBox.Show(
                "Name has changed. Do you want to add a new entry?",
                "New Entry",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            if (EntityDataManager.EntityData.ContainsKey(newData.Name))
            {
                MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                return;
            }

            lbDetails.Items.Add(newData);
            EntityDataManager.EntityData.Add(newData.Name, newData);
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
            EntityDataManager.EntityData.Remove(entity);

            if (File.Exists(FormMain.ClassPath + @"\" + entity + ".xml"))
                File.Delete(FormMain.ClassPath + @"\" + entity + ".xml");
        }

        private void AddEntity(EntityData entityData)
        {
            if (EntityDataManager.EntityData.ContainsKey(entityData.Name))
            {
                var result = MessageBox.Show(
                    entityData.Name + " already exists. Do you want to overwrite it?",
                    "Existing Character Class",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                EntityDataManager.EntityData[entityData.Name] = entityData;

                FillListBox();
                return;
            }

            lbDetails.Items.Add(entityData.ToString());

            EntityDataManager.EntityData.Add(
                entityData.Name,
                entityData);
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (var s in EntityDataManager.EntityData.Keys)
                lbDetails.Items.Add(EntityDataManager.EntityData[s]);
        }
    }
}
