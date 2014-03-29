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
    public partial class ClassroomSelectForm : Form
    {
        public ClassroomSelectForm()
        {
            InitializeComponent();
        }

        private void ClassroomSelectForm_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = Program.Classrooms;
            listBox1.DisplayMember = "Title";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.schedule.GetExcelSchedule(listBox1.SelectedItem as Classroom);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.schedule.GetFormSchedule(listBox1.SelectedItem as Classroom);
        }
    }
}
