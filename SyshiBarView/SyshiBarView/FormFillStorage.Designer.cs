namespace SyshiBarView
{
    partial class FormFillStorage
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxStorage = new System.Windows.Forms.ComboBox();
            this.comboBoxSeafood = new System.Windows.Forms.ComboBox();
            this.labelStorage = new System.Windows.Forms.Label();
            this.labelSeafood = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(224, 160);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(92, 28);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxStorage
            // 
            this.comboBoxStorage.FormattingEnabled = true;
            this.comboBoxStorage.Location = new System.Drawing.Point(123, 12);
            this.comboBoxStorage.Name = "comboBoxStorage";
            this.comboBoxStorage.Size = new System.Drawing.Size(296, 21);
            this.comboBoxStorage.TabIndex = 1;
            // 
            // comboBoxSeafood
            // 
            this.comboBoxSeafood.FormattingEnabled = true;
            this.comboBoxSeafood.Location = new System.Drawing.Point(123, 58);
            this.comboBoxSeafood.Name = "comboBoxSeafood";
            this.comboBoxSeafood.Size = new System.Drawing.Size(296, 21);
            this.comboBoxSeafood.TabIndex = 2;
            // 
            // labelStorage
            // 
            this.labelStorage.AutoSize = true;
            this.labelStorage.Location = new System.Drawing.Point(14, 18);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(38, 13);
            this.labelStorage.TabIndex = 3;
            this.labelStorage.Text = "Склад";
            // 
            // labelSeafood
            // 
            this.labelSeafood.AutoSize = true;
            this.labelSeafood.Location = new System.Drawing.Point(14, 61);
            this.labelSeafood.Name = "labelSeafood";
            this.labelSeafood.Size = new System.Drawing.Size(82, 13);
            this.labelSeafood.TabIndex = 4;
            this.labelSeafood.Text = "Морепродукты";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(123, 101);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(295, 20);
            this.textBoxCount.TabIndex = 5;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(19, 104);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(71, 13);
            this.labelCount.TabIndex = 6;
            this.labelCount.Text = "количевство";
            // 
            // buttonCansel
            // 
            this.buttonCansel.Location = new System.Drawing.Point(357, 160);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(92, 28);
            this.buttonCansel.TabIndex = 7;
            this.buttonCansel.Text = "Отмена";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormFillStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 223);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelSeafood);
            this.Controls.Add(this.labelStorage);
            this.Controls.Add(this.comboBoxSeafood);
            this.Controls.Add(this.comboBoxStorage);
            this.Controls.Add(this.buttonSave);
            this.Name = "FormFillStorage";
            this.Text = "Пополнить Склад";
            this.Load += new System.EventHandler(this.FormFillStorage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxStorage;
        private System.Windows.Forms.ComboBox comboBoxSeafood;
        private System.Windows.Forms.Label labelStorage;
        private System.Windows.Forms.Label labelSeafood;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonCansel;
    }
}