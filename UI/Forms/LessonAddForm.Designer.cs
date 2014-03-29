namespace Susie
{
    partial class LessonAddForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.listBox9 = new System.Windows.Forms.ListBox();
            this.listBox10 = new System.Windows.Forms.ListBox();
            this.listBox7 = new System.Windows.Forms.ListBox();
            this.semesterListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.mapOfLoad1 = new Susie.MapOfLoad();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mapOfLoad2 = new Susie.MapOfLoad();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox8 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mapOfLoad3 = new Susie.MapOfLoad();
            this.listBox11 = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.listBox2.Location = new System.Drawing.Point(256, 52);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(70, 56);
            this.listBox2.TabIndex = 0;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(332, 52);
            this.listBox3.Name = "listBox3";
            this.listBox3.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox3.Size = new System.Drawing.Size(125, 56);
            this.listBox3.TabIndex = 0;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox5_SelectedIndexChanged);
            this.listBox3.Click += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(256, 23);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(201, 95);
            this.listBox4.TabIndex = 0;
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox10_SelectedIndexChanged);
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.Location = new System.Drawing.Point(224, 17);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(136, 147);
            this.listBox5.TabIndex = 0;
            this.listBox5.SelectedIndexChanged += new System.EventHandler(this.listBox5_SelectedIndexChanged);
            // 
            // listBox6
            // 
            this.listBox6.FormattingEnabled = true;
            this.listBox6.Items.AddRange(new object[] {
            "1-2",
            "3-4",
            "5-6",
            "7-8"});
            this.listBox6.Location = new System.Drawing.Point(151, 108);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(58, 56);
            this.listBox6.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(650, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Додати заняття";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(98, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 92);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(82, 17);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Знаменник";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(81, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Чисельник";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Повне";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(256, 153);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(83, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Кілька груп";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.Click += new System.EventHandler(this.radioButton4_Click);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(256, 147);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(116, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "Кілька викладачів";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.Click += new System.EventHandler(this.radioButton5_Click_1);
            // 
            // listBox9
            // 
            this.listBox9.FormattingEnabled = true;
            this.listBox9.Items.AddRange(new object[] {
            "Понеділок",
            "Вівторок",
            "Середа",
            "Четвер",
            "П\'ятниця"});
            this.listBox9.Location = new System.Drawing.Point(3, 20);
            this.listBox9.Name = "listBox9";
            this.listBox9.Size = new System.Drawing.Size(89, 82);
            this.listBox9.TabIndex = 6;
            // 
            // listBox10
            // 
            this.listBox10.FormattingEnabled = true;
            this.listBox10.Location = new System.Drawing.Point(332, 23);
            this.listBox10.Name = "listBox10";
            this.listBox10.Size = new System.Drawing.Size(33, 147);
            this.listBox10.TabIndex = 8;
            this.listBox10.SelectedIndexChanged += new System.EventHandler(this.listBox10_SelectedIndexChanged);
            // 
            // listBox7
            // 
            this.listBox7.FormattingEnabled = true;
            this.listBox7.Items.AddRange(new object[] {
            "Лекція",
            "Практична/Лабораторні"});
            this.listBox7.Location = new System.Drawing.Point(3, 108);
            this.listBox7.Name = "listBox7";
            this.listBox7.Size = new System.Drawing.Size(139, 56);
            this.listBox7.TabIndex = 9;
            this.listBox7.SelectedIndexChanged += new System.EventHandler(this.listBox5_SelectedIndexChanged);
            // 
            // semesterListBox
            // 
            this.semesterListBox.FormattingEnabled = true;
            this.semesterListBox.Items.AddRange(new object[] {
            "Осінній",
            "Весняний"});
            this.semesterListBox.Location = new System.Drawing.Point(784, 22);
            this.semesterListBox.Name = "semesterListBox";
            this.semesterListBox.Size = new System.Drawing.Size(70, 43);
            this.semesterListBox.TabIndex = 10;
            this.semesterListBox.SelectedIndexChanged += new System.EventHandler(this.listBox8_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(781, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Семестр";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(224, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Групи";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(212, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Викладачі";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.mapOfLoad1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.listBox3);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Location = new System.Drawing.Point(12, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 177);
            this.panel1.TabIndex = 16;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(256, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.listBox5_SelectedIndexChanged);
            // 
            // mapOfLoad1
            // 
            this.mapOfLoad1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapOfLoad1.Location = new System.Drawing.Point(3, 25);
            this.mapOfLoad1.Name = "mapOfLoad1";
            this.mapOfLoad1.Size = new System.Drawing.Size(247, 145);
            this.mapOfLoad1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.mapOfLoad2);
            this.panel2.Controls.Add(this.listBox4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.radioButton5);
            this.panel2.Location = new System.Drawing.Point(12, 189);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 179);
            this.panel2.TabIndex = 17;
            // 
            // mapOfLoad2
            // 
            this.mapOfLoad2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapOfLoad2.Location = new System.Drawing.Point(3, 23);
            this.mapOfLoad2.Name = "mapOfLoad2";
            this.mapOfLoad2.Size = new System.Drawing.Size(247, 145);
            this.mapOfLoad2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.listBox8);
            this.panel3.Controls.Add(this.listBox1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.mapOfLoad3);
            this.panel3.Controls.Add(this.listBox11);
            this.panel3.Controls.Add(this.listBox10);
            this.panel3.Location = new System.Drawing.Point(12, 374);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(471, 178);
            this.panel3.TabIndex = 18;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(295, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 32);
            this.button3.TabIndex = 19;
            this.button3.Text = "<<";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(295, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 32);
            this.button2.TabIndex = 19;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Тип";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Корпус";
            // 
            // listBox8
            // 
            this.listBox8.FormattingEnabled = true;
            this.listBox8.Items.AddRange(new object[] {
            "Лекційні",
            "Загальні",
            "Лабораторії",
            "Комп\'ютерні класи",
            "Майстрені",
            "Спортивні"});
            this.listBox8.Location = new System.Drawing.Point(371, 88);
            this.listBox8.Name = "listBox8";
            this.listBox8.Size = new System.Drawing.Size(93, 82);
            this.listBox8.TabIndex = 17;
            this.listBox8.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.listBox1.Location = new System.Drawing.Point(371, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(93, 30);
            this.listBox1.TabIndex = 17;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(215, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Аудиторії";
            // 
            // mapOfLoad3
            // 
            this.mapOfLoad3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapOfLoad3.Location = new System.Drawing.Point(3, 23);
            this.mapOfLoad3.Name = "mapOfLoad3";
            this.mapOfLoad3.Size = new System.Drawing.Size(247, 145);
            this.mapOfLoad3.TabIndex = 14;
            // 
            // listBox11
            // 
            this.listBox11.FormattingEnabled = true;
            this.listBox11.Location = new System.Drawing.Point(256, 23);
            this.listBox11.Name = "listBox11";
            this.listBox11.Size = new System.Drawing.Size(33, 147);
            this.listBox11.TabIndex = 8;
            this.listBox11.SelectedIndexChanged += new System.EventHandler(this.listBox10_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.listBox9);
            this.panel4.Controls.Add(this.listBox5);
            this.panel4.Controls.Add(this.listBox6);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.listBox7);
            this.panel4.Location = new System.Drawing.Point(489, 189);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(365, 179);
            this.panel4.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(221, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Предмети";
            // 
            // LessonAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 559);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.semesterListBox);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LessonAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Susie";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.ListBox listBox6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.ListBox listBox9;
        private System.Windows.Forms.ListBox listBox10;
        private System.Windows.Forms.ListBox listBox7;
        private System.Windows.Forms.ListBox semesterListBox;
        private System.Windows.Forms.Label label1;
        private MapOfLoad mapOfLoad1;
        private MapOfLoad mapOfLoad2;
        private MapOfLoad mapOfLoad3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox11;
    }
}

