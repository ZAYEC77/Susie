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
    public partial class ReplacementAddForm : Form
    {
        public ReplacementAddForm()
        {
            InitializeComponent();
        }

        private void ReplacementAddForm_Load(object sender, EventArgs e)
        {
            this.Text = "Заміни на заняття: " + Program.replacement.SelectedLesson.Title;
            listBox1.DataSource = Program.replacement.SelectedLesson.Groups;
            listBox1.DisplayMember = "Title";
            listBox3.DisplayMember = "Title";
            listBox10.DisplayMember = "Title";
            listBox11.DisplayMember = "Title";
            comboBox1.DisplayMember = "Title";
            label4.Text = Program.replacement.SelectedLesson.TitleGroups + '\n' +
                Program.replacement.SelectedLesson.TitleSubject + '\n' +
                Program.replacement.SelectedLesson.TitleTeachers + '\n' +
                Program.replacement.SelectedLesson.TitleClassrooms;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == listBox1)
                comboBox1.DataSource = Program.schedule.GetSubjectsForGroup(listBox1.SelectedItem as Group);
            listBox3.DataSource = Program.schedule.GetTeachersFor(listBox1.SelectedItems.Cast<Group>().ToList(),
                comboBox1.SelectedItem as Subject, listBox7.SelectedIndex);
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox10.DataSource = Program.Classrooms.
                Where(c => c.Corps == listBox4.SelectedIndex + 1).
                Where(c => c.Type == listBox8.SelectedIndex + 1).
                ToList<Classroom>();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listBox1.SelectionMode = SelectionMode.MultiSimple;
                listBox3.SelectionMode = SelectionMode.One;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                listBox1.SelectionMode = SelectionMode.One;
                listBox3.SelectionMode = SelectionMode.MultiSimple;
            }
        }

        private void listBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = Program.replacement.AddReplacemant(
                listBox1.SelectedItems.Cast<Group>().ToList<Group>(),
                listBox3.SelectedItems.Cast<Teacher>().ToList<Teacher>(),
                listBox11.Items.Cast<Classroom>().ToList<Classroom>(),
                comboBox1.SelectedItem as Subject);
            if (flag)
            {
                listBox2.DataSource = null;
                listBox2.DataSource = Program.replacement.CurrentReplacements;
                listBox2.DisplayMember = "ShortTitle";
            }
            else
                MessageBox.Show(Program.replacement.Message);
        }

        private void ReplacementAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.replacement.CurrentReplacements.Count == 0) return;
            if (MessageBox.Show("Бажаєте зберегти заміни?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                Program.replacement.RollBack();
            }
            else
            {
                Program.replacement.RefreshFact();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox11.Items.Remove(listBox11.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox10.SelectedItem == null) return;
            if (listBox11.Items.Contains(listBox10.SelectedItem)) return;
            listBox11.Items.Add(listBox10.SelectedItem);
        }
    }
}
