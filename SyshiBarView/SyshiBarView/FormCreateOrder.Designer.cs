namespace SyshiBarView
{
    partial class FormCreateOrder
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
            this.buttonCansel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelСуши = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxSushi = new System.Windows.Forms.ComboBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCansel
            // 
            this.buttonCansel.Location = new System.Drawing.Point(203, 114);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(93, 25);
            this.buttonCansel.TabIndex = 0;
            this.buttonCansel.Text = "Отмена";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(104, 114);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(93, 25);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelСуши
            // 
            this.labelСуши.AutoSize = true;
            this.labelСуши.Location = new System.Drawing.Point(22, 22);
            this.labelСуши.Name = "labelСуши";
            this.labelСуши.Size = new System.Drawing.Size(36, 13);
            this.labelСуши.TabIndex = 2;
            this.labelСуши.Text = "Суши:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(22, 77);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(44, 13);
            this.labelPrice.TabIndex = 3;
            this.labelPrice.Text = "Сумма:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(22, 49);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(75, 13);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "Количевство:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(102, 46);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(194, 20);
            this.textBoxCount.TabIndex = 5;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // comboBoxSushi
            // 
            this.comboBoxSushi.FormattingEnabled = true;
            this.comboBoxSushi.Location = new System.Drawing.Point(102, 19);
            this.comboBoxSushi.Name = "comboBoxSushi";
            this.comboBoxSushi.Size = new System.Drawing.Size(194, 21);
            this.comboBoxSushi.TabIndex = 6;
            this.comboBoxSushi.SelectedIndexChanged += new System.EventHandler(this.comboBoxProduct_SelectedIndexChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBoxSum.Location = new System.Drawing.Point(104, 72);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(194, 20);
            this.textBoxSum.TabIndex = 7;
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(437, 19);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(194, 21);
            this.comboBoxClient.TabIndex = 8;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(357, 27);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(46, 13);
            this.labelClient.TabIndex = 9;
            this.labelClient.Text = "Клиент:";
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 315);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.comboBoxSushi);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelСуши);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCansel);
            this.Name = "FormCreateOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelСуши;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxSushi;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Label labelClient;
    }
}