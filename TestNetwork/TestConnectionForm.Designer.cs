namespace TestNetwork
{
    partial class TestConnectionForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.successQueries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorQueries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queriesTimeSuccess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queriesTimeWrong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countNotStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgWaiting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.numQuery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timePlanStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeFactStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waitingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDelta = new System.Windows.Forms.CheckBox();
            this.rbStored = new System.Windows.Forms.RadioButton();
            this.rbQuery = new System.Windows.Forms.RadioButton();
            this.cbPooling = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lCountSuccessQueries = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Интенсивность:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "50000000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Начать тест";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Время (мин):";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(211, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "60";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.successQueries,
            this.errorQueries,
            this.queriesTimeSuccess,
            this.queriesTimeWrong,
            this.countNotStart,
            this.avgDuration,
            this.avgWaiting});
            this.dataGridView1.Location = new System.Drawing.Point(7, 276);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(925, 89);
            this.dataGridView1.TabIndex = 5;
            // 
            // successQueries
            // 
            this.successQueries.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.successQueries.HeaderText = "Успешных запросов";
            this.successQueries.Name = "successQueries";
            this.successQueries.ReadOnly = true;
            // 
            // errorQueries
            // 
            this.errorQueries.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.errorQueries.HeaderText = "Запросов с ошибками";
            this.errorQueries.Name = "errorQueries";
            this.errorQueries.ReadOnly = true;
            // 
            // queriesTimeSuccess
            // 
            this.queriesTimeSuccess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.queriesTimeSuccess.HeaderText = "Запросов, стартовавших вовремя";
            this.queriesTimeSuccess.Name = "queriesTimeSuccess";
            this.queriesTimeSuccess.ReadOnly = true;
            // 
            // queriesTimeWrong
            // 
            this.queriesTimeWrong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.queriesTimeWrong.HeaderText = "Запросов, стартовавших невовремя";
            this.queriesTimeWrong.Name = "queriesTimeWrong";
            this.queriesTimeWrong.ReadOnly = true;
            // 
            // countNotStart
            // 
            this.countNotStart.HeaderText = "Запросов, еще не стартовавших";
            this.countNotStart.Name = "countNotStart";
            this.countNotStart.ReadOnly = true;
            // 
            // avgDuration
            // 
            this.avgDuration.HeaderText = "Среднее время выполнения";
            this.avgDuration.Name = "avgDuration";
            this.avgDuration.ReadOnly = true;
            // 
            // avgWaiting
            // 
            this.avgWaiting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.avgWaiting.HeaderText = "Средняя погрешность старта";
            this.avgWaiting.Name = "avgWaiting";
            this.avgWaiting.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 36);
            this.button2.TabIndex = 7;
            this.button2.Text = "Получить результат";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(363, 225);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 33);
            this.button3.TabIndex = 8;
            this.button3.Text = "Анализ результата";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numQuery,
            this.timePlanStart,
            this.timeFactStart,
            this.waitingTime,
            this.duration,
            this.errorText});
            this.dataGridView2.Location = new System.Drawing.Point(7, 371);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(925, 232);
            this.dataGridView2.TabIndex = 9;
            // 
            // numQuery
            // 
            this.numQuery.HeaderText = "Порядковый номер";
            this.numQuery.Name = "numQuery";
            // 
            // timePlanStart
            // 
            this.timePlanStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timePlanStart.HeaderText = "Плановое время старта";
            this.timePlanStart.Name = "timePlanStart";
            // 
            // timeFactStart
            // 
            this.timeFactStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeFactStart.HeaderText = "Фактическое время старта";
            this.timeFactStart.Name = "timeFactStart";
            // 
            // waitingTime
            // 
            this.waitingTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.waitingTime.HeaderText = "Погрешность старта";
            this.waitingTime.Name = "waitingTime";
            // 
            // duration
            // 
            this.duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.duration.HeaderText = "Время выполнения";
            this.duration.Name = "duration";
            // 
            // errorText
            // 
            this.errorText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.errorText.HeaderText = "Текст ошибки";
            this.errorText.Name = "errorText";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDelta);
            this.groupBox1.Controls.Add(this.rbStored);
            this.groupBox1.Controls.Add(this.rbQuery);
            this.groupBox1.Controls.Add(this.cbPooling);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Опции";
            // 
            // cbDelta
            // 
            this.cbDelta.AutoSize = true;
            this.cbDelta.Location = new System.Drawing.Point(184, 31);
            this.cbDelta.Name = "cbDelta";
            this.cbDelta.Size = new System.Drawing.Size(167, 21);
            this.cbDelta.TabIndex = 3;
            this.cbDelta.Text = "Учитывать задержку";
            this.cbDelta.UseVisualStyleBackColor = true;
            // 
            // rbStored
            // 
            this.rbStored.AutoSize = true;
            this.rbStored.Location = new System.Drawing.Point(111, 58);
            this.rbStored.Name = "rbStored";
            this.rbStored.Size = new System.Drawing.Size(174, 21);
            this.rbStored.TabIndex = 2;
            this.rbStored.TabStop = true;
            this.rbStored.Text = "Хранимые процедуры";
            this.rbStored.UseVisualStyleBackColor = true;
            // 
            // rbQuery
            // 
            this.rbQuery.AutoSize = true;
            this.rbQuery.Checked = true;
            this.rbQuery.Location = new System.Drawing.Point(6, 58);
            this.rbQuery.Name = "rbQuery";
            this.rbQuery.Size = new System.Drawing.Size(87, 21);
            this.rbQuery.TabIndex = 1;
            this.rbQuery.TabStop = true;
            this.rbQuery.Text = "Запросы";
            this.rbQuery.UseVisualStyleBackColor = true;
            // 
            // cbPooling
            // 
            this.cbPooling.AutoSize = true;
            this.cbPooling.Location = new System.Drawing.Point(6, 31);
            this.cbPooling.Name = "cbPooling";
            this.cbPooling.Size = new System.Drawing.Size(172, 21);
            this.cbPooling.TabIndex = 0;
            this.cbPooling.Text = "Использовать pooling";
            this.cbPooling.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 100);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры эксперимента";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lCountSuccessQueries);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(479, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(458, 100);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Сообщения";
            // 
            // lCountSuccessQueries
            // 
            this.lCountSuccessQueries.AutoSize = true;
            this.lCountSuccessQueries.Location = new System.Drawing.Point(9, 61);
            this.lCountSuccessQueries.Name = "lCountSuccessQueries";
            this.lCountSuccessQueries.Size = new System.Drawing.Size(46, 17);
            this.lCountSuccessQueries.TabIndex = 7;
            this.lCountSuccessQueries.Text = "label4";
            this.lCountSuccessQueries.Visible = false;
            // 
            // TestConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 265);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TestConnectionForm";
            this.Text = "Тест времени connection";
            this.Load += new System.EventHandler(this.TestConnectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn successQueries;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorQueries;
        private System.Windows.Forms.DataGridViewTextBoxColumn queriesTimeSuccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn queriesTimeWrong;
        private System.Windows.Forms.DataGridViewTextBoxColumn countNotStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgWaiting;
        private System.Windows.Forms.DataGridViewTextBoxColumn numQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn timePlanStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeFactStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn waitingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbStored;
        private System.Windows.Forms.RadioButton rbQuery;
        private System.Windows.Forms.CheckBox cbPooling;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lCountSuccessQueries;
        private System.Windows.Forms.CheckBox cbDelta;
    }
}