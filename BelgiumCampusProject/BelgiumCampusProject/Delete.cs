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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.StudentNumber = int.Parse(tbDelete.Text);

            DataHandler handler = new DataHandler();
            handler.Delete(student.StudentNumber);

            this.Close();
        }
    }
}
