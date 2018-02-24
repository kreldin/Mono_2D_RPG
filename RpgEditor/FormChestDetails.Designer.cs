namespace RpgEditor
{
    partial class FormChestDetails
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDifficulty = new System.Windows.Forms.ComboBox();
            this.cbLock = new System.Windows.Forms.CheckBox();
            this.cbTrap = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTrap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbKeyName = new System.Windows.Forms.TextBox();
            this.tbKeyType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudKeys = new System.Windows.Forms.NumericUpDown();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nudMinGold = new System.Windows.Forms.NumericUpDown();
            this.nudMaxGold = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGold)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(85, 14);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(128, 20);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chest Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lock Difficulty:";
            // 
            // cboDifficulty
            // 
            this.cboDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDifficulty.Enabled = false;
            this.cboDifficulty.FormattingEnabled = true;
            this.cboDifficulty.Location = new System.Drawing.Point(88, 33);
            this.cboDifficulty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboDifficulty.Name = "cboDifficulty";
            this.cboDifficulty.Size = new System.Drawing.Size(100, 21);
            this.cboDifficulty.TabIndex = 2;
            // 
            // cbLock
            // 
            this.cbLock.AutoSize = true;
            this.cbLock.Location = new System.Drawing.Point(22, 16);
            this.cbLock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbLock.Name = "cbLock";
            this.cbLock.Size = new System.Drawing.Size(62, 17);
            this.cbLock.TabIndex = 0;
            this.cbLock.Text = "Locked";
            this.cbLock.UseVisualStyleBackColor = true;
            // 
            // cbTrap
            // 
            this.cbTrap.AutoSize = true;
            this.cbTrap.Location = new System.Drawing.Point(7, 16);
            this.cbTrap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTrap.Name = "cbTrap";
            this.cbTrap.Size = new System.Drawing.Size(66, 17);
            this.cbTrap.TabIndex = 0;
            this.cbTrap.Text = "Trapped";
            this.cbTrap.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Trap Name:";
            // 
            // tbTrap
            // 
            this.tbTrap.Enabled = false;
            this.tbTrap.Location = new System.Drawing.Point(75, 33);
            this.tbTrap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbTrap.Name = "tbTrap";
            this.tbTrap.Size = new System.Drawing.Size(100, 20);
            this.tbTrap.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Key Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Key Type:";
            // 
            // tbKeyName
            // 
            this.tbKeyName.Enabled = false;
            this.tbKeyName.Location = new System.Drawing.Point(88, 59);
            this.tbKeyName.Name = "tbKeyName";
            this.tbKeyName.Size = new System.Drawing.Size(100, 20);
            this.tbKeyName.TabIndex = 4;
            // 
            // tbKeyType
            // 
            this.tbKeyType.Enabled = false;
            this.tbKeyType.Location = new System.Drawing.Point(88, 84);
            this.tbKeyType.Name = "tbKeyType";
            this.tbKeyType.Size = new System.Drawing.Size(100, 20);
            this.tbKeyType.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Keys Needed:";
            // 
            // nudKeys
            // 
            this.nudKeys.Enabled = false;
            this.nudKeys.Location = new System.Drawing.Point(88, 107);
            this.nudKeys.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudKeys.Name = "nudKeys";
            this.nudKeys.Size = new System.Drawing.Size(99, 20);
            this.nudKeys.TabIndex = 8;
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(4, 17);
            this.lbItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(270, 264);
            this.lbItems.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(76, 285);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 19);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(151, 285);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(56, 19);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Minimum Gold:";
            // 
            // nudMinGold
            // 
            this.nudMinGold.Location = new System.Drawing.Point(88, 17);
            this.nudMinGold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudMinGold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinGold.Name = "nudMinGold";
            this.nudMinGold.Size = new System.Drawing.Size(99, 20);
            this.nudMinGold.TabIndex = 0;
            // 
            // nudMaxGold
            // 
            this.nudMaxGold.Location = new System.Drawing.Point(88, 40);
            this.nudMaxGold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudMaxGold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxGold.Name = "nudMaxGold";
            this.nudMaxGold.Size = new System.Drawing.Size(99, 20);
            this.nudMaxGold.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 41);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Maximum Gold:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDifficulty);
            this.groupBox1.Controls.Add(this.tbKeyName);
            this.groupBox1.Controls.Add(this.tbKeyType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbLock);
            this.groupBox1.Controls.Add(this.nudKeys);
            this.groupBox1.Location = new System.Drawing.Point(9, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(202, 132);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lock Properties";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTrap);
            this.groupBox2.Controls.Add(this.tbTrap);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(9, 179);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(202, 67);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trap Properties";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudMinGold);
            this.groupBox3.Controls.Add(this.nudMaxGold);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(9, 250);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(202, 71);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gold Properties";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbItems);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.btnRemove);
            this.groupBox4.Location = new System.Drawing.Point(226, 13);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(282, 308);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Item Properties";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(196, 337);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 19);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(267, 337);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormChestDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 468);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormChestDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chest";
            ((System.ComponentModel.ISupportInitialize)(this.nudKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDifficulty;
        private System.Windows.Forms.CheckBox cbLock;
        private System.Windows.Forms.CheckBox cbTrap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTrap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbKeyName;
        private System.Windows.Forms.TextBox tbKeyType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudKeys;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudMinGold;
        private System.Windows.Forms.NumericUpDown nudMaxGold;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}