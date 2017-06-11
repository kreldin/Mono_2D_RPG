namespace RpgEditor
{
    partial class FormEntityData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.strengthLabel = new System.Windows.Forms.Label();
            this.dexterityLabel = new System.Windows.Forms.Label();
            this.cunningLabel = new System.Windows.Forms.Label();
            this.willpowerLabel = new System.Windows.Forms.Label();
            this.magicLabel = new System.Windows.Forms.Label();
            this.constitutionLabel = new System.Windows.Forms.Label();
            this.healthLabel = new System.Windows.Forms.Label();
            this.staminaLabel = new System.Windows.Forms.Label();
            this.manaLabel = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.mtbStrength = new System.Windows.Forms.MaskedTextBox();
            this.mtbDexterity = new System.Windows.Forms.MaskedTextBox();
            this.mtbCunning = new System.Windows.Forms.MaskedTextBox();
            this.mtbWillpower = new System.Windows.Forms.MaskedTextBox();
            this.mtbMagic = new System.Windows.Forms.MaskedTextBox();
            this.mtbConstitution = new System.Windows.Forms.MaskedTextBox();
            this.tbHealth = new System.Windows.Forms.TextBox();
            this.tbStamina = new System.Windows.Forms.TextBox();
            this.tbMana = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(61, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // strengthLabel
            // 
            this.strengthLabel.AutoSize = true;
            this.strengthLabel.Location = new System.Drawing.Point(49, 40);
            this.strengthLabel.Name = "strengthLabel";
            this.strengthLabel.Size = new System.Drawing.Size(50, 13);
            this.strengthLabel.TabIndex = 1;
            this.strengthLabel.Text = "Strength:";
            // 
            // dexterityLabel
            // 
            this.dexterityLabel.AutoSize = true;
            this.dexterityLabel.Location = new System.Drawing.Point(48, 66);
            this.dexterityLabel.Name = "dexterityLabel";
            this.dexterityLabel.Size = new System.Drawing.Size(51, 13);
            this.dexterityLabel.TabIndex = 2;
            this.dexterityLabel.Text = "Dexterity:";
            // 
            // cunningLabel
            // 
            this.cunningLabel.AutoSize = true;
            this.cunningLabel.Location = new System.Drawing.Point(50, 92);
            this.cunningLabel.Name = "cunningLabel";
            this.cunningLabel.Size = new System.Drawing.Size(49, 13);
            this.cunningLabel.TabIndex = 3;
            this.cunningLabel.Text = "Cunning:";
            // 
            // willpowerLabel
            // 
            this.willpowerLabel.AutoSize = true;
            this.willpowerLabel.Location = new System.Drawing.Point(43, 118);
            this.willpowerLabel.Name = "willpowerLabel";
            this.willpowerLabel.Size = new System.Drawing.Size(56, 13);
            this.willpowerLabel.TabIndex = 4;
            this.willpowerLabel.Text = "Willpower:";
            // 
            // magicLabel
            // 
            this.magicLabel.AutoSize = true;
            this.magicLabel.Location = new System.Drawing.Point(60, 144);
            this.magicLabel.Name = "magicLabel";
            this.magicLabel.Size = new System.Drawing.Size(39, 13);
            this.magicLabel.TabIndex = 5;
            this.magicLabel.Text = "Magic:";
            // 
            // constitutionLabel
            // 
            this.constitutionLabel.AutoSize = true;
            this.constitutionLabel.Location = new System.Drawing.Point(34, 170);
            this.constitutionLabel.Name = "constitutionLabel";
            this.constitutionLabel.Size = new System.Drawing.Size(65, 13);
            this.constitutionLabel.TabIndex = 6;
            this.constitutionLabel.Text = "Constitution:";
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Location = new System.Drawing.Point(18, 196);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(81, 13);
            this.healthLabel.TabIndex = 7;
            this.healthLabel.Text = "Health Formula:";
            // 
            // staminaLabel
            // 
            this.staminaLabel.AutoSize = true;
            this.staminaLabel.Location = new System.Drawing.Point(11, 222);
            this.staminaLabel.Name = "staminaLabel";
            this.staminaLabel.Size = new System.Drawing.Size(88, 13);
            this.staminaLabel.TabIndex = 8;
            this.staminaLabel.Text = "Stamina Formula:";
            // 
            // manaLabel
            // 
            this.manaLabel.AutoSize = true;
            this.manaLabel.Location = new System.Drawing.Point(22, 248);
            this.manaLabel.Name = "manaLabel";
            this.manaLabel.Size = new System.Drawing.Size(77, 13);
            this.manaLabel.TabIndex = 9;
            this.manaLabel.Text = "Mana Formula:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(105, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 10;
            // 
            // mtbStrength
            // 
            this.mtbStrength.Location = new System.Drawing.Point(105, 37);
            this.mtbStrength.Mask = "00";
            this.mtbStrength.Name = "mtbStrength";
            this.mtbStrength.Size = new System.Drawing.Size(100, 20);
            this.mtbStrength.TabIndex = 11;
            this.mtbStrength.Text = "10";
            // 
            // mtbDexterity
            // 
            this.mtbDexterity.Location = new System.Drawing.Point(105, 63);
            this.mtbDexterity.Mask = "00";
            this.mtbDexterity.Name = "mtbDexterity";
            this.mtbDexterity.Size = new System.Drawing.Size(100, 20);
            this.mtbDexterity.TabIndex = 11;
            this.mtbDexterity.Text = "10";
            // 
            // mtbCunning
            // 
            this.mtbCunning.Location = new System.Drawing.Point(105, 89);
            this.mtbCunning.Mask = "00";
            this.mtbCunning.Name = "mtbCunning";
            this.mtbCunning.Size = new System.Drawing.Size(100, 20);
            this.mtbCunning.TabIndex = 11;
            this.mtbCunning.Text = "10";
            // 
            // mtbWillpower
            // 
            this.mtbWillpower.Location = new System.Drawing.Point(105, 115);
            this.mtbWillpower.Mask = "00";
            this.mtbWillpower.Name = "mtbWillpower";
            this.mtbWillpower.Size = new System.Drawing.Size(100, 20);
            this.mtbWillpower.TabIndex = 11;
            this.mtbWillpower.Text = "10";
            // 
            // mtbMagic
            // 
            this.mtbMagic.Location = new System.Drawing.Point(105, 141);
            this.mtbMagic.Mask = "00";
            this.mtbMagic.Name = "mtbMagic";
            this.mtbMagic.Size = new System.Drawing.Size(100, 20);
            this.mtbMagic.TabIndex = 11;
            this.mtbMagic.Text = "10";
            // 
            // mtbConstitution
            // 
            this.mtbConstitution.Location = new System.Drawing.Point(105, 167);
            this.mtbConstitution.Mask = "00";
            this.mtbConstitution.Name = "mtbConstitution";
            this.mtbConstitution.Size = new System.Drawing.Size(100, 20);
            this.mtbConstitution.TabIndex = 11;
            this.mtbConstitution.Text = "10";
            // 
            // tbHealth
            // 
            this.tbHealth.Location = new System.Drawing.Point(105, 193);
            this.tbHealth.Name = "tbHealth";
            this.tbHealth.Size = new System.Drawing.Size(240, 20);
            this.tbHealth.TabIndex = 12;
            // 
            // tbStamina
            // 
            this.tbStamina.Location = new System.Drawing.Point(105, 219);
            this.tbStamina.Name = "tbStamina";
            this.tbStamina.Size = new System.Drawing.Size(240, 20);
            this.tbStamina.TabIndex = 13;
            // 
            // tbMana
            // 
            this.tbMana.Location = new System.Drawing.Point(105, 245);
            this.tbMana.Name = "tbMana";
            this.tbMana.Size = new System.Drawing.Size(240, 20);
            this.tbMana.TabIndex = 14;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(81, 282);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(162, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormEntityData
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(357, 317);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbMana);
            this.Controls.Add(this.tbStamina);
            this.Controls.Add(this.tbHealth);
            this.Controls.Add(this.mtbConstitution);
            this.Controls.Add(this.mtbMagic);
            this.Controls.Add(this.mtbWillpower);
            this.Controls.Add(this.mtbCunning);
            this.Controls.Add(this.mtbDexterity);
            this.Controls.Add(this.mtbStrength);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.manaLabel);
            this.Controls.Add(this.staminaLabel);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.constitutionLabel);
            this.Controls.Add(this.magicLabel);
            this.Controls.Add(this.willpowerLabel);
            this.Controls.Add(this.cunningLabel);
            this.Controls.Add(this.dexterityLabel);
            this.Controls.Add(this.strengthLabel);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormEntityData";
            this.Text = "Character Class";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label strengthLabel;
        private System.Windows.Forms.Label dexterityLabel;
        private System.Windows.Forms.Label cunningLabel;
        private System.Windows.Forms.Label willpowerLabel;
        private System.Windows.Forms.Label magicLabel;
        private System.Windows.Forms.Label constitutionLabel;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.Label staminaLabel;
        private System.Windows.Forms.Label manaLabel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.MaskedTextBox mtbStrength;
        private System.Windows.Forms.MaskedTextBox mtbDexterity;
        private System.Windows.Forms.MaskedTextBox mtbCunning;
        private System.Windows.Forms.MaskedTextBox mtbWillpower;
        private System.Windows.Forms.MaskedTextBox mtbMagic;
        private System.Windows.Forms.MaskedTextBox mtbConstitution;
        private System.Windows.Forms.TextBox tbHealth;
        private System.Windows.Forms.TextBox tbStamina;
        private System.Windows.Forms.TextBox tbMana;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}