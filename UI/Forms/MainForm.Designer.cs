namespace Susie
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перезавантажитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переглядРозкладуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.групаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.аудиторіяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.викладачToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заміниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фактичнаВичиткаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.навантаженняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semesterListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(7, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(867, 361);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Викладачі";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Групи";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Аудиторії";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Предмет";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "День";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Number";
            this.Column6.HeaderText = "Пара";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Видалити";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(77, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 47);
            this.button2.TabIndex = 2;
            this.button2.Text = "Додати";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.переглядРозкладуToolStripMenuItem,
            this.заміниToolStripMenuItem,
            this.фактичнаВичиткаToolStripMenuItem,
            this.навантаженняToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(886, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перезавантажитиToolStripMenuItem,
            this.вихідToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.файлToolStripMenuItem.Text = "Програма";
            // 
            // перезавантажитиToolStripMenuItem
            // 
            this.перезавантажитиToolStripMenuItem.Name = "перезавантажитиToolStripMenuItem";
            this.перезавантажитиToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.перезавантажитиToolStripMenuItem.Text = "Перезавантажити";
            this.перезавантажитиToolStripMenuItem.Click += new System.EventHandler(this.перезавантажитиToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // переглядРозкладуToolStripMenuItem
            // 
            this.переглядРозкладуToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.групаToolStripMenuItem,
            this.аудиторіяToolStripMenuItem,
            this.викладачToolStripMenuItem});
            this.переглядРозкладуToolStripMenuItem.Name = "переглядРозкладуToolStripMenuItem";
            this.переглядРозкладуToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.переглядРозкладуToolStripMenuItem.Text = "Перегляд розкладу";
            // 
            // групаToolStripMenuItem
            // 
            this.групаToolStripMenuItem.Name = "групаToolStripMenuItem";
            this.групаToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.групаToolStripMenuItem.Text = "Група";
            this.групаToolStripMenuItem.Click += new System.EventHandler(this.групаToolStripMenuItem_Click);
            // 
            // аудиторіяToolStripMenuItem
            // 
            this.аудиторіяToolStripMenuItem.Name = "аудиторіяToolStripMenuItem";
            this.аудиторіяToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.аудиторіяToolStripMenuItem.Text = "Аудиторія";
            this.аудиторіяToolStripMenuItem.Click += new System.EventHandler(this.аудиторіяToolStripMenuItem_Click);
            // 
            // викладачToolStripMenuItem
            // 
            this.викладачToolStripMenuItem.Name = "викладачToolStripMenuItem";
            this.викладачToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.викладачToolStripMenuItem.Text = "Викладач";
            this.викладачToolStripMenuItem.Click += new System.EventHandler(this.викладачToolStripMenuItem_Click);
            // 
            // заміниToolStripMenuItem
            // 
            this.заміниToolStripMenuItem.Name = "заміниToolStripMenuItem";
            this.заміниToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.заміниToolStripMenuItem.Text = "Заміни";
            this.заміниToolStripMenuItem.Click += new System.EventHandler(this.заміниToolStripMenuItem_Click);
            // 
            // фактичнаВичиткаToolStripMenuItem
            // 
            this.фактичнаВичиткаToolStripMenuItem.Name = "фактичнаВичиткаToolStripMenuItem";
            this.фактичнаВичиткаToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.фактичнаВичиткаToolStripMenuItem.Text = "Фактична вичитка";
            this.фактичнаВичиткаToolStripMenuItem.Click += new System.EventHandler(this.фактичнаВичиткаToolStripMenuItem_Click);
            // 
            // навантаженняToolStripMenuItem
            // 
            this.навантаженняToolStripMenuItem.Name = "навантаженняToolStripMenuItem";
            this.навантаженняToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.навантаженняToolStripMenuItem.Text = "Навантаження";
            this.навантаженняToolStripMenuItem.Click += new System.EventHandler(this.навантаженняToolStripMenuItem_Click);
            // 
            // semesterListBox
            // 
            this.semesterListBox.FormattingEnabled = true;
            this.semesterListBox.Items.AddRange(new object[] {
            "Осінній",
            "Весняний"});
            this.semesterListBox.Location = new System.Drawing.Point(147, 39);
            this.semesterListBox.Name = "semesterListBox";
            this.semesterListBox.Size = new System.Drawing.Size(70, 30);
            this.semesterListBox.TabIndex = 11;
            this.semesterListBox.SelectedIndexChanged += new System.EventHandler(this.listBox8_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Семестер";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 448);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.semesterListBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Розклад";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переглядРозкладуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem групаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem аудиторіяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem викладачToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ListBox semesterListBox;
        private System.Windows.Forms.ToolStripMenuItem заміниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фактичнаВичиткаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem навантаженняToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem перезавантажитиToolStripMenuItem;
    }
}