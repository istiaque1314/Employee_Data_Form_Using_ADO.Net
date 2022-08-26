using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeDataForm
{

    public partial class Form1 : Form
    {
        public void EnterAllDetailsOrNot()
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Employee ID");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter First Name");
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Enter Last Name");
                textBox3.Focus();
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Employee salary");
                textBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Employee designation");
                textBox5.Focus();
            }
        }

        public void EmptyRecord()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        public void CommandAddValue(SqlCommand sqlcmd)
        {
            sqlcmd.Parameters.AddWithValue("@empid", textBox1.Text);
            sqlcmd.Parameters.AddWithValue("@Fname", textBox2.Text);
            sqlcmd.Parameters.AddWithValue("@Lname", textBox3.Text);
            sqlcmd.Parameters.AddWithValue("@emp_salary", textBox4.Text);
            sqlcmd.Parameters.AddWithValue("@emp_desig", textBox5.Text);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn;
            sqlConn = ConnectionHelper.GetConnection();   // We get the connection from ConnectionHelper class. I define the ConnectionHelper separately 

            try
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0)
                {
                    EnterAllDetailsOrNot();
                }
                else
                {

                    sqlConn.Open();
                    string query = "INSERT INTO Employee_data (emp_id,firstname,lastname, salary, designation) VALUES (@empid, @Fname, @Lname, @emp_salary, @emp_desig)";
                    SqlCommand cmd = new SqlCommand(query, sqlConn);
                    CommandAddValue(cmd);

                    int a = cmd.ExecuteNonQuery();  // if insert operation executed successfully then it return 1 else 0
                    sqlConn.Close();
                    if (a > 0)
                    {
                        MessageBox.Show("Records inserted successfully");
                        EmptyRecord();  // After datas are successfully inserted, all the text boxes empty automatically
                    }
                    else
                    {
                        MessageBox.Show("Records are not inserted");
                    }
                }
            }
            catch(Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn;
            sqlConn = ConnectionHelper.GetConnection();   // We get the connection from ConnectionHelper class. I define the ConnectionHelper separately 

            try
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0)
                {
                    EnterAllDetailsOrNot();
                }
                else
                {

                    sqlConn.Open();
                    string query = "UPDATE Employee_data SET firstname = @Fname, lastname = @Lname, salary = @emp_salary, designation = @emp_desig WHERE emp_id = @empid";
                    SqlCommand cmd = new SqlCommand(query, sqlConn);
                    CommandAddValue(cmd);

                    int a = cmd.ExecuteNonQuery();  // if insert operation executed successfully then it return 1 else 0
                    sqlConn.Close();
                    if (a > 0)
                    {
                        MessageBox.Show("Records updated successfully");
                        EmptyRecord();  // After datas are successfully updated, all the text boxes empty automatically
                    }
                    else
                    {
                        MessageBox.Show("Records are not updated");
                    }
                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn;
            sqlConn = ConnectionHelper.GetConnection();   // We get the connection from ConnectionHelper class. I define the ConnectionHelper separately 

            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter Employee ID");
                    textBox1.Focus();
                }
                else
                {

                    sqlConn.Open();
                    string query = "DELETE from Employee_data WHERE emp_id = @empid";
                    SqlCommand cmd = new SqlCommand(query, sqlConn);
                    cmd.Parameters.AddWithValue("@empid", textBox1.Text);
 
                    int a = cmd.ExecuteNonQuery();  // if insert operation executed successfully then it return 1 else 0
                    sqlConn.Close();
                    if (a > 0)
                    {
                        MessageBox.Show("Records deleted successfully");
                        EmptyRecord();  // After datas are successfully updated, all the text boxes empty automatically
                    }
                    else
                    {
                        MessageBox.Show("Records are not deleted");
                    }
                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message.ToString());
            }
        }
    }
}
