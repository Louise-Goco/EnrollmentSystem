using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationSystem
{
    public partial class SubjectEntry : Form
    {
        public SubjectEntry()
        {
            InitializeComponent();
            OfferingComboBox.Items.Add("1 - First Semester");
            OfferingComboBox.Items.Add("2 - Second Semester");
            CategoryComboBox.Items.Add("Lecture");
            CategoryComboBox.Items.Add("Labratory");
            CourseCodeComboBox.Items.Add("BSIT");
            CourseCodeComboBox.Items.Add("BSIS");
        }

        

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\63915\Documents\Goco.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection myConnection = new SqlConnection(connectionString);
            string sql = "SELECT * FROM SUBJECTFILE";
            SqlDataAdapter thisAdapter = new SqlDataAdapter(sql, myConnection);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "SubjectFile");

            DataColumn[] keys = new DataColumn[2];

            keys[0] = thisDataSet.Tables["SUBJECTFILE"].Columns["SFSUBJCODE"];
            keys[1] = thisDataSet.Tables["SUBJECTFILE"].Columns["SFSUBJCOURSECODE"];
            thisDataSet.Tables["SUBJECTFILE"].PrimaryKey = keys;

            String[] valuesToSearch = new string[2];
            valuesToSearch[0] = SubjectCodeTextBox.Text;
            valuesToSearch[1] = CourseCodeComboBox.Text;
            DataRow findRow = thisDataSet.Tables["SUBJECTFILE"].Rows.Find(valuesToSearch);

            if (SubjectCodeTextBox.Text.Equals("") ||
                DescriptionTextBox.Text.Equals("") ||
                UnitsTextBox.Text.Equals("") ||
                OfferingComboBox.SelectedItem == null ||
                CategoryComboBox.SelectedItem == null ||
                CourseCodeComboBox.SelectedItem == null ||
                CurriculumYearTextBox.Text.Equals(""))
            {
                MessageBox.Show("FILL UP THE REMAINING FIELDS", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (!int.TryParse(UnitsTextBox.Text, out int Units)) // Must be integer
            {
                MessageBox.Show("Units must be an integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (!int.TryParse(CurriculumYearTextBox.Text, out int year) || year < 2000 || year > 2100) // Only accepts the year 2000 - 2100
            {
                MessageBox.Show("Please enter a valid curriculum year .", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
                {
                    if (findRow == null)
                    {
                        DataRow thisRow = thisDataSet.Tables["SUBJECTFILE"].NewRow();

                        thisRow["SFSUBJCODE"] = SubjectCodeTextBox.Text;
                        thisRow["SFSUBJDESC"] = DescriptionTextBox.Text;
                        thisRow["SFSUBJUNITS"] = Convert.ToInt16(UnitsTextBox.Text);
                        thisRow["SFSUBJREGOFRNG"] = OfferingComboBox.Text.Substring(0, 1);
                        thisRow["SFSUBJCATEGORY"] = CategoryComboBox.Text.Substring(0, 3);
                        thisRow["SFSUBJSTATUS"] = "Active";
                        thisRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text;
                        thisRow["SFSUBJCURRCODE"] = CurriculumYearTextBox.Text;

                        thisDataSet.Tables["SUBJECTFILE"].Rows.Add(thisRow);
                        thisAdapter.Update(thisDataSet, "SUBJECTFILE");

                        MessageBox.Show("Entries Recorded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }

        private void RequisiteSubjectTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\63915\Documents\Goco.mdf;Integrated Security=True;Connect Timeout=30";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();

                string commandText = "SELECT * FROM SUBJECTFILE";
                SqlCommand thisCommand = myConnection.CreateCommand();
                thisCommand.CommandText = commandText;

                SqlDataReader thisReader = thisCommand.ExecuteReader();

                bool flag = false;
                while (thisReader.Read())
                {
                    if (thisReader["SFSUBJCODE"].ToString().ToUpper() == RequisiteSubjectTextBox.Text.ToUpper())
                    {
                        flag = true;
                        SubjectDataGridView.Rows[0].Cells["SubjectCodeColumn"].Value = thisReader["SFSUBJCODE"].ToString();
                        SubjectDataGridView.Rows[0].Cells["DescriptionColumn"].Value = thisReader["SFSUBJDESC"].ToString();
                        SubjectDataGridView.Rows[0].Cells["UnitsColumn"].Value = thisReader["SFSUBJUNITS"].ToString();
                        if (PreRequisiteRadioButton.Checked)
                        {
                            SubjectDataGridView.Rows[0].Cells["CoPreColumn"].Value = "Pre-Requisite";
                        }
                        else if (CoRequisiteRadioButton.Checked)
                        {
                            SubjectDataGridView.Rows[0].Cells["CoPreColumn"].Value = "Co-Requisite";
                        }
                        break;
                    }
                    else
                        continue;
                }
                if (flag == false)
                {
                    MessageBox.Show("Subject Not Found", "No Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                {
                    
                }
            }

        }
    }
}
