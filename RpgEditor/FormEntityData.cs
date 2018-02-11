using System;
using System.Windows.Forms;
using RpgLibrary.Characters;

namespace RpgEditor
{
    public partial class FormEntityData : Form
    {
        public EntityData EntityData { get; set; }

        public FormEntityData()
        {
            InitializeComponent();

            Load += FormEntityData_Load;
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void FormEntityData_Load(object sender, EventArgs e)
        {
            if (EntityData == null)
                return;

            tbName.Text = EntityData.Name;
            mtbStrength.Text = EntityData.Strength.ToString();
            mtbDexterity.Text = EntityData.Dexterity.ToString();
            mtbCunning.Text = EntityData.Cunning.ToString();
            mtbWillpower.Text = EntityData.Willpower.ToString();
            mtbConstitution.Text = EntityData.Constitution.ToString();
            tbHealth.Text = EntityData.HealthFormula;
            tbStamina.Text = EntityData.StaminaFormula;
            tbMana.Text = EntityData.MagicFormula;
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

        private bool CreateEntityData()
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

            EntityData = new EntityData(
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

            if (CreateEntityData())
                Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            EntityData = null;
            Close();
        }
    }
}
