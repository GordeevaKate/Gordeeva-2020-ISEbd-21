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
            this.comboBoxStorage = new System.Windows.Forms.ComboBox();
            this.comboBoxSeafood = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.labelseafood = new System.Windows.Forms.Label();
            this.labelstorage = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelcount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxStorage
            // 
            this.comboBoxStorage.FormattingEnabled = true;
            this.comboBoxStorage.Location = new System.Drawing.Point(224, 12);
            this.comboBoxStorage.Name = "comboBoxStorage";
            this.comboBoxStorage.Size = new System.Drawing.Size(332, 21);
            this.comboBoxStorage.TabIndex = 0;
            // 
            // comboBoxSeafood
            // 
            this.comboBoxSeafood.FormattingEnabled = true;
            this.comboBoxSeafood.Location = new System.Drawing.Point(224, 53);
            this.comboBoxSeafood.Name = "comboBoxSeafood";
            this.comboBoxSeafood.Size = new System.Drawing.Size(332, 21);
            this.comboBoxSeafood.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(351, 140);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(92, 21);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCansel
            // 
            this.buttonCansel.Location = new System.Drawing.Point(463, 140);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(92, 21);
            this.buttonCansel.TabIndex = 3;
            this.buttonCansel.Text = "Cansel";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelseafood
            // 
            this.labelseafood.AutoSize = true;
            this.labelseafood.Location = new System.Drawing.Point(12, 53);
            this.labelseafood.Name = "labelseafood";
            this.labelseafood.Size = new System.Drawing.Size(73, 13);
            this.labelseafood.TabIndex = 4;
            this.labelseafood.Text = "морепродукт";
            // 
            // labelstorage
            // 
            this.labelstorage.AutoSize = true;
            this.labelstorage.Location = new System.Drawing.Point(12, 15);
            this.labelstorage.Name = "labelstorage";
            this.labelstorage.Size = new System.Drawing.Size(45, 13);
            this.labelstorage.TabIndex = 5;
            this.labelstorage.Text = "склады";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(225, 93);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(329, 20);
            this.textBoxCount.TabIndex = 6;
            // 
            // labelcount
            // 
            this.labelcount.AutoSize = true;
            this.labelcount.Location = new System.Drawing.Point(12, 100);
            this.labelcount.Name = "labelcount";
            this.labelcount.Size = new System.Drawing.Size(65, 13);
            this.labelcount.TabIndex = 7;
            this.labelcount.Text = "количество";
            // 
            // FormFillStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 173);
            this.Controls.Add(this.labelcount);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelstorage);
            this.Controls.Add(this.labelseafood);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxSeafood);
            this.Controls.Add(this.comboBoxStorage);
            this.Name = "FormFillStorage";
            this.Text = "Берем из Склада";
            this.Load += new System.EventHandler(this.FormFillStorage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStorage;
        private System.Windows.Forms.ComboBox comboBoxSeafood;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Label labelseafood;
        private System.Windows.Forms.Label labelstorage;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelcount;
    }
}