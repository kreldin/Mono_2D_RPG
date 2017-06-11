using System;
using System.Windows.Forms;
using RpgLibrary.Characters;

namespace RpgEditor
{
    public partial class FormEntityData : Form
    {
        public EntityData Entity { get; set; }

        public FormEntityData()
        {
            InitializeComponent();

            Load += FormEntityData_Load;
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void FormEntityData_Load(object sender, EventArgs e)
        {
            if (Entity == null)
                return;

            tbName.Text = Entity.Name;
            mtbStrength.Text = Entity.Strength.ToString();
            mtbDexterity.Text = Entity.Dexterity.ToString();
            mtbCunning.Text = Entity.Cunning.ToString();
            mtbWillpower.Text = Entity.Willpower.ToString();
            mtbConstitution.Text = Entity.Constitution.ToString();
            tbHealth.Text = Entity.HealthFormula;
            tbStamina.Text = Entity.StaminaFormula;
            tbMana.Text = Entity.MagicFormula;
        }

        private bool IsInvalidForm()
        {
            return string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbHealth.Text) ||
                   string.IsNullOrEmpty(tbStamina.Text) || string.IsNullOrEmpty(tbMana.Text);
        }

        private static bool ConvertTextToVal(string text, out int val, string label)
        {
            if (int.TryParse(text, out val))
                return true;

            MessageBox.Show(label + @" must be numeric.");
            return false;
        }

        private bool CreateEntity()
        {
            if (!ConvertTextToVal(mtbStrength.Text, out int str, "Strength"))
                return false;

            if (!ConvertTextToVal(mtbDexterity.Text, out int dex, "Dexterity"))
                return false;

            if (!ConvertTextToVal(mtbCunning.Text, out int cunn, "Cunning"))
                return false;

            if (!ConvertTextToVal(mtbWillpower.Text, out int will, "Willpower"))
                return false;

            if (!ConvertTextToVal(mtbMagic.Text, out int mag, "Magic"))
                return false;

            if (!ConvertTextToVal(mtbConstitution.Text, out int con, "Constitution"))
                return false;

            Entity = new EntityData(
                tbName.Text,
                str,
                dex,
                cunn,
                will,
                mag,
                con,
                tbHealth.Text,
                tbStamina.Text,
                tbMana.Text);

            return true;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (IsInvalidForm())
            {
                MessageBox.Show(@"Name, Health Formula, Stamina Formula and Mana Formula must have values.");
                return;
            }

            if (CreateEntity())
                Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Entity = null;
            Close();
        }
    }
}
