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
    public partial class Read : Form
    {
        public Read()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void btRead_Click(object sender, EventArgs e)
        {
            DataHandler handler = new DataHandler();
            dataGridView1.DataSource = handler.Read();
        }
    }
}
