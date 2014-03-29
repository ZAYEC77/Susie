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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Program.schedule.Loads.Where(l => l.Semester == Program.schedule.Semester);
            dataGridView1.Columns[0].DataPropertyName = "TitleTeacher";
            dataGridView1.Columns[1].DataPropertyName = "TitleGroup";
            dataGridView1.Columns[2].DataPropertyName = "WeeklyHour";
            dataGridView1.Columns[3].DataPropertyName = "TitleSubject";
            dataGridView1.Columns[4].DataPropertyName = "Lecture";
            dataGridView1.Columns[5].DataPropertyName = "Lab";
        }
    }
}
