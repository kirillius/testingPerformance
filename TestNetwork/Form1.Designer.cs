namespace TestNetwork
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестКлиентскихЗапросовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестыToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестКлиентскихЗапросовToolStripMenuItem,
            this.тестConnectionToolStripMenuItem});
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.тестыToolStripMenuItem.Text = "Тесты";
            // 
            // тестКлиентскихЗапросовToolStripMenuItem
            // 
            this.тестКлиентскихЗапросовToolStripMenuItem.Name = "тестКлиентскихЗапросовToolStripMenuItem";
            this.тестКлиентскихЗапросовToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.тестКлиентскихЗапросовToolStripMenuItem.Text = "Тест клиентских запросов";
            // 
            // тестConnectionToolStripMenuItem
            // 
            this.тестConnectionToolStripMenuItem.Name = "тестConnectionToolStripMenuItem";
            this.тестConnectionToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.тестConnectionToolStripMenuItem.Text = "Тест connection";
            this.тестConnectionToolStripMenuItem.Click += new System.EventHandler(this.тестConnectionToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 370);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Тестирование производительности";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem тестыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестКлиентскихЗапросовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестConnectionToolStripMenuItem;
    }
}

