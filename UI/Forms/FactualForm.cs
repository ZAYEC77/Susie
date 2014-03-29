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
    public partial class FactualForm : Form
    {
        public FactualForm()
        {
            InitializeComponent();
        }

        private void FactualForm_Load(object sender, EventArgs e)
        {
            Program.fact.Load();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Program.fact.Bind;
            comboBox1.DisplayMember = "Title";
            comboBox2.DisplayMember = "Title";
            comboBox1.DataSource = Program.Teachers.OrderBy(t => t.LastName).ToList();
            comboBox2.DataSource = Program.Groups.
                OrderBy(g => g.Title).
                OrderBy(g => g.Speciality.ID).
                OrderBy(g => g.Course).
                ToList();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.fact.SelectedTeacher = comboBox1.SelectedItem as Teacher;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.fact.SelectedGroup = comboBox2.SelectedItem as Group;
        }

    }
}
