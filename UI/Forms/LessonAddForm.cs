using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.IO;

namespace Susie
{
    public partial class LessonAddForm : Form
    {
        public LessonAddForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "Title";
            listBox3.DisplayMember = "Title";
            listBox4.DisplayMember = "Title";
            listBox5.DisplayMember = "Title";
            listBox10.DisplayMember = "Title";
            listBox11.DisplayMember = "Title";

            comboBox1.DataSource = Program.Specialitys;
            semesterListBox.SelectedIndex = 0;
            listBox10.DataSource = Program.Classrooms;
            listBox1.SelectedIndex = 0;
            listBox8.SelectedIndex = 0;
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem == null) || (listBox2.SelectedItem == null))
            {
                listBox3.DataSource = null;
                listBox3.Enabled = false;
            }
            else
            {
                listBox3.Enabled = true;
                listBox3.DataSource = Program.schedule.GetGroups(listBox2.SelectedIndex + 1, comboBox1.SelectedItem as Speciality);
                listBox5.DataSource = Program.schedule.GetSubjectsForGroup(listBox3.SelectedItem as Group);
                listBox5_SelectedIndexChanged(sender, e);
            }

        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void UpDate()
        {
            mapOfLoad1.Assign(Program.schedule.GetLessonsForGroups(
                listBox3.SelectedItems.Cast<Group>().ToList()));
            mapOfLoad2.Assign(Program.schedule.GetLessonsForTeachers(
                listBox4.SelectedItems.Cast<Teacher>().ToList()));
            mapOfLoad3.Assign(Program.schedule.GetLessonsForClassrooms(
                listBox10.SelectedItems.Cast<Classroom>().ToList()));
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int type;
            if (radioButton1.Checked)
                type = 0;
            else
                if (radioButton2.Checked)
                    type = 1;
                else
                    type = 2;
            Lesson les = new Lesson();
            try
            {
                les.Type = type;
                les.Number = listBox6.SelectedIndex;
                les.DayOfWeek = listBox9.SelectedIndex;
                les.Subject = (listBox5.SelectedItem as Subject);
                les.AddGroups(listBox3.SelectedItems.Cast<Group>().ToList());
                les.AddTeachers(listBox4.SelectedItems.Cast<Teacher>().ToList());
                les.AddClassrooms(listBox11.Items.Cast<Classroom>().ToList());
                Program.schedule.AddLesson(les);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpDate();
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == listBox3)
                listBox5.DataSource = Program.schedule.GetSubjectsForGroup(listBox3.SelectedItem as Group);
            listBox4.DataSource = Program.schedule.GetTeachersFor(listBox3.SelectedItems.Cast<Group>().ToList(),
                listBox5.SelectedItem as Subject, listBox7.SelectedIndex);
            UpDate();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.schedule.Update();
            Program.schedule.Semester = Program.schedule.Semester;
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.schedule.Semester = semesterListBox.SelectedIndex;
            listBox2_SelectedIndexChanged(sender, e);
            UpDate();
        }

        private void listBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpDate();
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            radioButton5.Checked = !radioButton4.Checked;
            listBox3.SelectionMode = SelectionMode.MultiSimple;
            listBox4.SelectionMode = SelectionMode.One;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox10.DataSource = Program.Classrooms.Where(c => c.Corps == listBox1.SelectedIndex + 1).Where(c => c.Type == listBox8.SelectedIndex + 1).ToList<Classroom>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox10.SelectedItem == null) return;
            if (listBox11.Items.Contains(listBox10.SelectedItem)) return;
            listBox11.Items.Add(listBox10.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox11.Items.Remove(listBox11.SelectedItem);
        }

        private void radioButton5_Click_1(object sender, EventArgs e)
        {
            radioButton4.Checked = !radioButton5.Checked;
            listBox3.SelectionMode = SelectionMode.One;
            listBox4.SelectionMode = SelectionMode.MultiSimple;
        }

    }
}
