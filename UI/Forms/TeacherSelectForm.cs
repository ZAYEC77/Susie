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
    public partial class TeacherSelectForm : Form
    {
        public TeacherSelectForm()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = Program.Teachers.OrderBy(t => t.LastName);
            listBox1.DisplayMember = "Title";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.schedule.GetFormSchedule(listBox1.SelectedItem as Teacher);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.schedule.GetExcelSchedule(listBox1.SelectedItem as Teacher);
        }
    }
}
