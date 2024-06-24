using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace BelgiumCampusProject
{
    public partial class Login : Form
    {
        private const string usersFilePath = "users.txt";
        private Dictionary<string, string> users;
        public Login()
        {
            InitializeComponent();
            LoadUsers();
        }
        private void LoadUsers()
        {
            users = new Dictionary<string, string>();

            // edit path corrctly to view users 
            if (File.Exists(@"C:\Users\-------\BelgiumCampusProject\Login.txt"))
            {
                string[] lines = File.ReadAllLines(@"C:\Users\--------\BelgiumCampusProject\Login.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string username = parts[0];
                        string password = parts[1];
                        users.Add(username, password);
                    }
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private bool AuthenticateUser(string username, string password)
        {
            if (users.ContainsKey(username))
            {
                if (users[username] == password)
                {
                    return true;
                }
            }

            return false;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = tbUser.Text;
            string password = tbPW.Text;

            if (AuthenticateUser(username, password))
            {
                // User authenticated, proceed to the main form
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            string username = tbUser.Text;
            string password = tbPW.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (users.ContainsKey(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add the new user to the dictionary and write to the text file
            users.Add(username, password);
            File.AppendAllText(usersFilePath, $"{username}:{password}" + Environment.NewLine);

            MessageBox.Show("Registration successful! You can now log in.", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
