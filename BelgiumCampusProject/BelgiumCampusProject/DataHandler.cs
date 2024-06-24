using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BelgiumCampusProject
{
    internal class DataHandler
    {
        public DataHandler() { }
        static string connect = "Data Source=.; Initial Catalog= database; Integrated Security=SSPI;";

        SqlConnection con;
        SqlDataAdapter adapt;
        SqlCommand command;

        //Enroll students
        public void Enroll(int stNum,string n, string s,object img,DateTime dob,string g, string p,string a, string c)
        {
            string query = $"INSERT INTO Students VALUES('{stNum}','{n}','{s}','{dob}','{g}','{p}','{a}','{c}')";
            con = new SqlConnection(connect);
            con.Open();
            command = new SqlCommand(query, con);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Student Details Saved");
            }
            catch( Exception ex)
            {
                MessageBox.Show("Student Details NOT Saved" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //update
        public void Update(int stNum, string n, string s, string img, string dob, string g, string p, string a, string c)
        {
            string query = $"UPDATE Students SET [StudentNumber]='{stNum}',[Name]='{n}',[Surname]='{s}',[DateOfBirth]='{dob}',[Gender]='{g}'[Phone]=,'{p}',[Address]='{a}',[CourseCode]='{c}') WHERE [StudentNumber]='{stNum}'";

            con = new SqlConnection(connect);
            con.Open();
            command = new SqlCommand(query, con);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Student Details Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Student Details NOT Updated" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //delete
        public void Delete(int stNum)
        {
            string query = $"DELETE FROM Students WhERE StudentNumber='{stNum}'";
            con = new SqlConnection(connect);
            con.Open();
            command = new SqlCommand(query, con);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Student Details Deleted");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Student Details NOT Deleted" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //search
        public DataTable Search(int stNum)
        {
            string query = $"SELECT * FROM Students WHERE StudentNumber ='{stNum}'";
            con = new SqlConnection(connect);
            adapt = new SqlDataAdapter(query,con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            return table;
        }

        public DataTable Read()
        {
            string query = $"SELECT * FROM Students";
            con = new SqlConnection(connect);
            adapt = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            adapt.Fill(table);
            return table;
        }
    }

}
