namespace SyshiBarView
{
    partial class FormSushiSeafood
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
            this.buttonCansel = new System.Windows.Forms.Button();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSeafood = new System.Windows.Forms.Label();
            this.comboBoxSeafood = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(233, 81);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(86, 32);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCansel
            // 
            this.buttonCansel.Location = new System.Drawing.Point(344, 81);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(75, 32);
            this.buttonCansel.TabIndex = 1;
            this.buttonCansel.Text = "Отмена";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(169, 36);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(250, 20);
            this.textBoxCount.TabIndex = 2;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 39);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(75, 13);
            this.labelCount.TabIndex = 3;
            this.labelCount.Text = "Количевство:";
            // 
            // labelSeafood
            // 
            this.labelSeafood.AutoSize = true;
            this.labelSeafood.Location = new System.Drawing.Point(12, 9);
            this.labelSeafood.Name = "labelSeafood";
            this.labelSeafood.Size = new System.Drawing.Size(85, 13);
            this.labelSeafood.TabIndex = 4;
            this.labelSeafood.Text = "Морепродукты:";

            // 
            // comboBoxSeafood
            // 
            this.comboBoxSeafood.FormattingEnabled = true;
            this.comboBoxSeafood.Location = new System.Drawing.Point(169, 6);
            this.comboBoxSeafood.Name = "comboBoxSeafood";
            this.comboBoxSeafood.Size = new System.Drawing.Size(250, 21);
            this.comboBoxSeafood.TabIndex = 5;
            // 
            // FormSushiSeafood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 122);
            this.Controls.Add(this.comboBoxSeafood);
            this.Controls.Add(this.labelSeafood);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonSave);
            this.Name = "FormSushiSeafood";
            this.Text = "Компонент изделия";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelSeafood;
        private System.Windows.Forms.ComboBox comboBoxSeafood;
    }
}