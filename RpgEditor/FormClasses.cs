using System;

namespace RpgEditor
{
    public partial class FormClasses
    {
        public FormClasses()
        {
            InitializeComponent();

            loadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var entityDataForm = new FormEntityData())
            {
                entityDataForm.ShowDialog();

                if (entityDataForm.Entity != null)
                    lbDetails.Items.Add(entityDataForm.Entity.ToString());
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
