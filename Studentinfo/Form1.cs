using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studentinfo
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        List<studentinfo> stu = new List<studentinfo>();
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill all require fields");
            }
            else
            {
                studentinfo s = new studentinfo();
                s.StudentID = int.Parse(textBox1.Text);
                s.StudentName = textBox2.Text;
                s.Age = int.Parse(textBox3.Text);
                s.marks = int.Parse(textBox4.Text);
                s.gender = textBox5.Text;
                stu.Add(s);
                MessageBox.Show("Record Save Successfully");
                cleartextboxes();

            }
        }

        private void cleartextboxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox10.Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var myString = from d in stu
                           select d;
            foreach (studentinfo d in myString)
            {
                dataGridView1.Rows.Add(d.StudentID, d.StudentName, d.Age, d.marks,d.gender);
            }
        }

    

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (textBox10.Text == "")
            {
                MessageBox.Show("Please Enter Name to Search");
            }
            else
            {
                var myString = from std in stu
                               where std.StudentName == textBox10.Text
                               select std;
                foreach (studentinfo s in myString)
                {
                    dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);
                }
                textBox10.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (textBox6.Text == "")
            {
                MessageBox.Show("Please Enter Marks to Search");
            }
            else
            {
                var myString = from mark in stu
                               where mark.marks > int.Parse(textBox6.Text)
                               orderby mark.marks descending
                               select mark;
                foreach (studentinfo s in myString)
                {
                    dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);

                }
                textBox6.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var myString = from mark in stu
                           orderby mark.marks descending
                           select mark;
            foreach (studentinfo s in myString)
            {
                dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var myString = from s in stu
                           orderby s.gender ascending, s.marks descending, s.Age ascending
                           select s;
            foreach (studentinfo s in myString)
            {
                dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks,s.gender);
            }

        }
    }
}
