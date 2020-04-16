namespace SyshiBarView
{
    partial class FormReportushSushiSeafoods
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
            this.buttonSaveToExel = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Компонент = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Изделие = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Количевство = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveToExel
            // 
            this.buttonSaveToExel.Location = new System.Drawing.Point(12, 12);
            this.buttonSaveToExel.Name = "buttonSaveToExel";
            this.buttonSaveToExel.Size = new System.Drawing.Size(164, 28);
            this.buttonSaveToExel.TabIndex = 0;
            this.buttonSaveToExel.Text = "Сохранить в Exel";
            this.buttonSaveToExel.UseVisualStyleBackColor = true;
            this.buttonSaveToExel.Click += new System.EventHandler(this.ButtonSaveToExel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Компонент,
            this.Изделие,
            this.Количевство});
            this.dataGridView.Location = new System.Drawing.Point(11, 62);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(485, 389);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // Компонент
            // 
            this.Компонент.HeaderText = "Компонент";
            this.Компонент.Name = "Компонент";
            // 
            // Изделие
            // 
            this.Изделие.HeaderText = "Изделие";
            this.Изделие.Name = "Изделие";
            // 
            // Количевство
            // 
            this.Количевство.HeaderText = "Количевство";
            this.Количевство.Name = "Количевство";
            // 
            // FormReportushSushiSeafoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonSaveToExel);
            this.Name = "FormReportushSushiSeafoods";
            this.Text = "FormReportushSushiSeafoods";
            this.Load += new System.EventHandler(this.FormReportSushiSeafoods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveToExel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Компонент;
        private System.Windows.Forms.DataGridViewTextBoxColumn Изделие;
        private System.Windows.Forms.DataGridViewTextBoxColumn Количевство;
    }
}