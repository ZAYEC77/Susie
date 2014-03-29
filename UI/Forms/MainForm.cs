using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Susie
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Program.schedule.LessonBind;
            dataGridView1.Columns[0].DataPropertyName = "TitleTeachers";
            dataGridView1.Columns[1].DataPropertyName = "TitleGroups";
            dataGridView1.Columns[2].DataPropertyName = "TitleClassrooms";
            dataGridView1.Columns[3].DataPropertyName = "TitleSubject";
            dataGridView1.Columns[4].DataPropertyName = "DayName";
            dataGridView1.Columns[5].DataPropertyName = "TitleNumber";
            semesterListBox.SelectedIndex = 0;
            //this.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.schedule.RemoveLessons(Program.schedule.LessonBind.Current as Lesson);
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.schedule.Update();
        }

        private void групаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupSelectForm f = new GroupSelectForm();
            f.ShowDialog();
        }

        private void викладачToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherSelectForm f = new TeacherSelectForm();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LessonAddForm f = new LessonAddForm();
            f.ShowDialog();
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.schedule.Semester = semesterListBox.SelectedIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SplashScreen f = new SplashScreen();
            f.Show();
        }

        private void заміниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.replacement.Schedule = Program.schedule.Lessons.Where(l => l.Semester == semesterListBox.SelectedIndex).ToList();
            Program.replacement.Load();
            ReplacementForm form = new ReplacementForm();
            form.ShowDialog();
        }

        private void аудиторіяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassroomSelectForm f = new ClassroomSelectForm();
            f.ShowDialog();
        }

        private void навантаженняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingForm form = new LoadingForm();
            form.Show();
        }

        private void фактичнаВичиткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FactualForm form = new FactualForm();
            form.Show();
        }

        private void перезавантажитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
