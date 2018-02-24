using System;
using System.Windows.Forms;
using System.IO;
using RpgLibrary.Skills;

namespace RpgEditor
{
    public partial class FormSkill : FormDetails
    {

        public FormSkill()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frmSkillDetails = new FormSkillDetails())
            {
                frmSkillDetails.ShowDialog();

                if (frmSkillDetails.Skill != null)
                    AddSkill(frmSkillDetails.Skill);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbDetails.SelectedItem == null) return;

            var detail = lbDetails.SelectedItem.ToString();
            var parts = detail.Split(',');
            var entity = parts[0].Trim();

            var data = SkillDataManager.SkillData[entity];
            SkillData newData;

            using (var frmSkillData = new FormSkillDetails())
            {
                frmSkillData.Skill = data;
                frmSkillData.ShowDialog();

                if (frmSkillData.Skill == null)
                    return;

                if (frmSkillData.Skill.Name == entity)
                {
                    SkillDataManager.SkillData[entity] = frmSkillData.Skill;
                    FillListBox();
                    return;
                }
                
                newData = frmSkillData.Skill;
            }

            var result = MessageBox.Show(
                "Name has changed. Do you want to add a new entry?",
                "New Entry",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            if (SkillDataManager.SkillData.ContainsKey(newData.Name))
            {
                MessageBox.Show("Entry already exists. Use Edit to modify the entry.");
                return;
            }

            lbDetails.Items.Add(newData);
            SkillDataManager.SkillData.Add(newData.Name, newData);
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
            SkillDataManager.SkillData.Remove(entity);

            if (File.Exists(FormMain.SkillPath + @"\" + entity + ".xml"))
                File.Delete(FormMain.SkillPath + @"\" + entity + ".xml");
        }

        public void FillListBox()
        {
            lbDetails.Items.Clear();

            foreach (var s in SkillDataManager.SkillData.Keys)
                lbDetails.Items.Add(SkillDataManager.SkillData[s]);
        }

        private void AddSkill(SkillData skillData)
        {
            if (SkillDataManager.SkillData.ContainsKey(skillData.Name))
            {
                var result = MessageBox.Show(
                    skillData.Name + " already exists. Overwrite it?",
                    "Existing skill",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                SkillDataManager.SkillData[skillData.Name] = skillData;
                FillListBox();
                return;
            }

            SkillDataManager.SkillData.Add(skillData.Name, skillData);
            lbDetails.Items.Add(skillData);
        } 
    }
}
