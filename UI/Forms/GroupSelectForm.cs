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
    public partial class GroupSelectForm : Form
    {
        public GroupSelectForm()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = Program.Specialitys;
            listBox1.DisplayMember = "Title";
            listBox3.DisplayMember = "Title";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((listBox1.SelectedItem == null) || (listBox2.SelectedItem == null))
            {
                listBox3.DataSource = null;
                listBox3.Enabled = false;
            }
            else
            {
                listBox3.Enabled = true;
                listBox3.DataSource = Program.schedule.GetGroups(listBox2.SelectedIndex + 1, listBox1.SelectedItem as Speciality);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.schedule.GetFormSchedule(listBox3.SelectedItem as Group);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                Program.schedule.GetExcelSchedule(listBox3.SelectedItems.Cast<Group>().ToList());
            if (radioButton2.Checked)
                Program.schedule.GetExcelSchedule(Program.Groups.Where(g => g.Speciality == listBox1.SelectedItem).OrderBy(g => g.Title).OrderBy(g => g.Course).ToList());
            if (radioButton3.Checked)
                if(listBox2.SelectedIndex != -1)
                    Program.schedule.GetExcelSchedule(Program.Groups.Where(g => g.Course == listBox2.SelectedIndex + 1).OrderBy(g => g.Title).OrderBy(g => g.Speciality.ID).ToList());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listBox2.Enabled = true;
                listBox3.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                listBox2.Enabled = false;
                listBox3.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                listBox3.Enabled = false;
                listBox2.Enabled = true;
            }
        }

    }
}
