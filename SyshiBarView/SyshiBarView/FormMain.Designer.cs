namespace SyshiBarView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonTakeOrderlnWork = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.морепродуктыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сушиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокМорепродуктовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоСушиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(2, 25);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(723, 423);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(744, 47);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(133, 20);
            this.buttonCreateOrder.TabIndex = 1;
            this.buttonCreateOrder.Text = "Своздать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(744, 151);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(133, 20);
            this.buttonRef.TabIndex = 2;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(744, 125);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(133, 20);
            this.buttonPayOrder.TabIndex = 3;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(744, 99);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(133, 20);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // buttonTakeOrderlnWork
            // 
            this.buttonTakeOrderlnWork.Location = new System.Drawing.Point(744, 73);
            this.buttonTakeOrderlnWork.Name = "buttonTakeOrderlnWork";
            this.buttonTakeOrderlnWork.Size = new System.Drawing.Size(133, 20);
            this.buttonTakeOrderlnWork.TabIndex = 5;
            this.buttonTakeOrderlnWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderlnWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderlnWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(889, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.морепродуктыToolStripMenuItem,
            this.сушиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // морепродуктыToolStripMenuItem
            // 
            this.морепродуктыToolStripMenuItem.Name = "морепродуктыToolStripMenuItem";
            this.морепродуктыToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.морепродуктыToolStripMenuItem.Text = "Морепродукты";
            this.морепродуктыToolStripMenuItem.Click += new System.EventHandler(this.SeafoodToolStripMenuItem_Click);
            // 
            // сушиToolStripMenuItem
            // 
            this.сушиToolStripMenuItem.Name = "сушиToolStripMenuItem";
            this.сушиToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.сушиToolStripMenuItem.Text = "Суши";
            this.сушиToolStripMenuItem.Click += new System.EventHandler(this.SushiToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокМорепродуктовToolStripMenuItem,
            this.компонентыПоСушиToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокМорепродуктовToolStripMenuItem
            // 
            this.списокМорепродуктовToolStripMenuItem.Name = "списокМорепродуктовToolStripMenuItem";
            this.списокМорепродуктовToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.списокМорепродуктовToolStripMenuItem.Text = "список морепродуктов";
            this.списокМорепродуктовToolStripMenuItem.Click += new System.EventHandler(this.SeafoodsToolStripMenuItem_Click);
            // 
            // компонентыПоСушиToolStripMenuItem
            // 
            this.компонентыПоСушиToolStripMenuItem.Name = "компонентыПоСушиToolStripMenuItem";
            this.компонентыПоСушиToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.компонентыПоСушиToolStripMenuItem.Text = "Компоненты по суши";
            this.компонентыПоСушиToolStripMenuItem.Click += new System.EventHandler(this.SeafoodSushisToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.списокЗаказовToolStripMenuItem.Text = "список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 448);
            this.Controls.Add(this.buttonTakeOrderlnWork);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Суши-Бар";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonTakeOrderlnWork;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem морепродуктыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сушиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокМорепродуктовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоСушиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
    }
}

