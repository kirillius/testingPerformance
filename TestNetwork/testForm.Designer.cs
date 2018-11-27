namespace TestNetwork
{
    partial class testForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queryNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allTimeSql = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeExecuteRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeNetwork = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeNetworkCalculate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parsingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStartParsing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество пользователей:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(213, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество запросов:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(213, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(207, 22);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Начать тест";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userId,
            this.queryNum,
            this.timeAll,
            this.allTimeSql,
            this.timeExecuteRequest,
            this.timeNetwork,
            this.timeNetworkCalculate,
            this.parsingTime,
            this.sizeData,
            this.timeStartParsing,
            this.CountItems});
            this.dataGridView1.Location = new System.Drawing.Point(12, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1428, 278);
            this.dataGridView1.TabIndex = 5;
            // 
            // userId
            // 
            this.userId.HeaderText = "id пользователя";
            this.userId.Name = "userId";
            this.userId.ReadOnly = true;
            // 
            // queryNum
            // 
            this.queryNum.HeaderText = "Количество запросов";
            this.queryNum.Name = "queryNum";
            this.queryNum.ReadOnly = true;
            // 
            // timeAll
            // 
            this.timeAll.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeAll.HeaderText = "Общее время";
            this.timeAll.Name = "timeAll";
            this.timeAll.ReadOnly = true;
            // 
            // allTimeSql
            // 
            this.allTimeSql.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.allTimeSql.HeaderText = "Общее время (от шарпа)";
            this.allTimeSql.Name = "allTimeSql";
            this.allTimeSql.ReadOnly = true;
            // 
            // timeExecuteRequest
            // 
            this.timeExecuteRequest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeExecuteRequest.HeaderText = "Время выполнения запроса";
            this.timeExecuteRequest.Name = "timeExecuteRequest";
            this.timeExecuteRequest.ReadOnly = true;
            // 
            // timeNetwork
            // 
            this.timeNetwork.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeNetwork.HeaderText = "Время работы сети";
            this.timeNetwork.Name = "timeNetwork";
            this.timeNetwork.ReadOnly = true;
            // 
            // timeNetworkCalculate
            // 
            this.timeNetworkCalculate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeNetworkCalculate.HeaderText = "Время сети, рассчитанное";
            this.timeNetworkCalculate.Name = "timeNetworkCalculate";
            this.timeNetworkCalculate.ReadOnly = true;
            // 
            // parsingTime
            // 
            this.parsingTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.parsingTime.HeaderText = "Время парсинга ответа";
            this.parsingTime.Name = "parsingTime";
            this.parsingTime.ReadOnly = true;
            // 
            // sizeData
            // 
            this.sizeData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sizeData.HeaderText = "Объем данных";
            this.sizeData.Name = "sizeData";
            this.sizeData.ReadOnly = true;
            // 
            // timeStartParsing
            // 
            this.timeStartParsing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeStartParsing.HeaderText = "Время старта парсинга";
            this.timeStartParsing.Name = "timeStartParsing";
            this.timeStartParsing.ReadOnly = true;
            // 
            // CountItems
            // 
            this.CountItems.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CountItems.HeaderText = "Кол-во элементов";
            this.CountItems.Name = "CountItems";
            this.CountItems.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(139, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 33);
            this.button2.TabIndex = 6;
            this.button2.Text = "Получить результат";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 121);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "testForm";
            this.Text = "Тест сети";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn userId;
        private System.Windows.Forms.DataGridViewTextBoxColumn queryNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn allTimeSql;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeExecuteRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeNetwork;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeNetworkCalculate;
        private System.Windows.Forms.DataGridViewTextBoxColumn parsingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeData;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStartParsing;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountItems;
    }
}