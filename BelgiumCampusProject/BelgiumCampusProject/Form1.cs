using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelgiumCampusProject
{
    public partial class Form1 : Form
    {
        DataHandler handler = new DataHandler();
        Student student = new Student();
        public Form1()
        {
            InitializeComponent();
            cbCode.Items.Add("Diploma");
            cbCode.Items.Add("Degree");
            cbCode.Items.Add("BCOM");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            student.StudentNumber=int.Parse(tbSnum.Text);
            student.Name=tbName.Text;
            student.Surname = tbSname.Text;
            student.Image= pictureBox1.Image;
            student.Gender = rbFemale.Checked.ToString();
            student.Gender = rbMale.Checked.ToString();
            student.Phone = tbPhone.Text;
            student.Address = richTextBox1.Text;
            student.CourseCode=cbCode.Text;

            handler.Enroll(student.StudentNumber,student.Name,student.Surname,student.Image,student.DateOfBirth,student.Gender,student.Phone,student.Address,student.CourseCode);
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            Delete d = new Delete();
            d.Show();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            Read r = new Read();
            r.Show();
        }
    }
}
