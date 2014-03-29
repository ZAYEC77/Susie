using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Susie
{
    public partial class ReplacementForm : Form
    {
        public ReplacementForm()
        {
            InitializeComponent();
        }

        private void Replacement_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Program.replacement.FactBind;
            comboBox1.DataSource = Program.Teachers.OrderBy(t => t.LastName).ToList();
            comboBox2.DataSource = Program.Groups.
                OrderBy(g => g.Title).
                OrderBy(g => g.Speciality.ID).
                OrderBy(g => g.Course).
                ToList();
            comboBox1.DisplayMember = "Title";
            comboBox2.DisplayMember = "Title";
            Program.replacement.Day = (int)(dateTimePicker1.Value.DayOfWeek) - 1;
            Program.replacement.Type = radioButton1.Checked;
            ClearCombos();
        }
        private void ClearCombos()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ClearCombos();
            Program.replacement.Day = (int)(dateTimePicker1.Value.DayOfWeek) - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.replacement.SelectedLesson = Program.replacement.FactBind.Current as Lesson;
            if (Program.replacement.IsReplacement(Program.replacement.FactBind.Current as Lesson))
            {
                if (MessageBox.Show("Це заняття -- заміна\nВидалити?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Program.replacement.RemoveReplacemant(Program.replacement.FactBind.Current as Lesson);
                }
                return;
            }
            ReplacementAddForm form = new ReplacementAddForm();
            form.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ClearCombos();
            Program.replacement.Type = radioButton1.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;
            comboBox2.SelectedIndex = -1;
            Program.replacement.ShowFor(comboBox1.SelectedItem as Teacher);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.schedule.GetFormSchedule(comboBox1.SelectedItem as Teacher);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1) return;
            comboBox1.SelectedIndex = -1;
            Program.replacement.ShowFor(comboBox2.SelectedItem as Group);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.schedule.GetFormSchedule(comboBox2.SelectedItem as Group);
        }

        private void ReplacementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Зберегти заміни?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Program.replacement.SubmitChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearCombos();
            Program.replacement.ShowAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.replacement.ExportInWord(dateTimePicker1.Value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Дані про фактичні заняття будуть занесені в фактичну вичитку.\nПродовжити?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;
            Program.replacement.WriteFact();
        }
    }
}
