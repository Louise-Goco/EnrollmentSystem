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

namespace EvaluationSystem
{
    public partial class StudentEnrollmentEntry: Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\63915\Documents\Goco.mdf;Integrated Security=True;Connect Timeout=30";

        public StudentEnrollmentEntry()
        {
            InitializeComponent();
        }

        private void IdNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                bool found = false;
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                SqlCommand studentCommand = myConnection.CreateCommand();

                studentCommand.CommandText = "SELECT * FROM STUDENTFILE";

                SqlDataReader studentDataReader = studentCommand.ExecuteReader();
                while (studentDataReader.Read())
                {
                    if (studentDataReader["STFSTUDID"].ToString().ToUpper() == IdNumberTextBox.Text.ToUpper())
                    {
                        NameTextBox.Text = studentDataReader["STFSTUDLNAME"].ToString() + ", " + studentDataReader["STFSTUDFNAME"].ToString();
                        CourseTextBox.Text = studentDataReader["STFSTUDCOURSE"].ToString();
                        YearTextBox.Text = studentDataReader["STFSTUDYEAR"].ToString();
                        found = true;
                        break;
                    }
                    continue;
                }

                if (!found)
                {
                    MessageBox.Show("ID Number not Found", "No ID Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
