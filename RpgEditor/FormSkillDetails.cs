using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.Skills;

namespace RpgEditor
{
    public partial class FormSkillDetails : Form
    {
        public SkillData Skill { get; set; }

        public FormSkillDetails()
        {
            InitializeComponent();

            Load += FormSkillDetails_Load;
            FormClosing += FormSkillDetails_FormClosing;

            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void FormSkillDetails_Load(object sender, EventArgs e)
        {
            if (Skill == null) return;

            tbName.Text = Skill.Name;
            switch (Skill.PrimaryAttribute.ToLower())
            {
                case "strength":
                    rbStrength.Checked = true;
                    break;
                case "dexterity":
                    rbDexterity.Checked = true;
                    break;
                case "cunning":
                    rbCunning.Checked = true;
                    break;
                case "willpower":
                    rbWillpower.Checked = true;
                    break;
                case "magic":
                    rbMagic.Checked = true;
                    break;
                case "constitution":
                    rbConstitution.Checked = true;
                    break;
            }

            foreach (var s in Skill.ClassModifiers.Keys)
            {
                var data = s + ", " + Skill.ClassModifiers[s];
                lbModifiers.Items.Add(data);
            }
        }

        private static void FormSkillDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You must provide a name for the skill.");
                return;
            }

            var newSkill = new SkillData { Name = tbName.Text };

            if (rbStrength.Checked)
                newSkill.PrimaryAttribute = "Strength";
            else if (rbDexterity.Checked)
                newSkill.PrimaryAttribute = "Dexterity";
            else if (rbCunning.Checked)
                newSkill.PrimaryAttribute = "Cunning";
            else if (rbWillpower.Checked)
                newSkill.PrimaryAttribute = "Willpower";
            else if (rbMagic.Checked)
                newSkill.PrimaryAttribute = "Magic";
            else if (rbConstitution.Checked)
                newSkill.PrimaryAttribute = "Constitution";

            Skill = newSkill;
            FormClosing -= FormSkillDetails_FormClosing;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Skill = null;
            FormClosing -= FormSkillDetails_FormClosing;
            Close();
        }
    }
}
