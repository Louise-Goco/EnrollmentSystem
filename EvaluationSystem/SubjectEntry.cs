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
            this.StartPosition = FormStartPosition.CenterScreen;
            OfferingComboBox.Items.Add("1 - First Semester");
            OfferingComboBox.Items.Add("2 - Second Semester");
            CategoryComboBox.Items.Add("Lecture");
            CategoryComboBox.Items.Add("Labratory");
            CourseCodeComboBox.Items.Add("BSIT");
            CourseCodeComboBox.Items.Add("BSIS");
        }

        public void ClearFields()
        {
            SubjectCodeTextBox.Clear();
            DescriptionTextBox.Clear();
            UnitsTextBox.Clear();
            OfferingComboBox.SelectedItem = null;
            CategoryComboBox.SelectedItem = null;
            CourseCodeComboBox.SelectedItem = null;
            CurriculumYearTextBox.Clear();
        }

        private bool SubjectRequisiteExists(string subjectCode, string prereqCode, DataTable prereqTable)
        {
            foreach (DataRow row in prereqTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted &&
                    row["SUBJCODE"].ToString() == subjectCode &&
                    row["SUBJPRECODE"].ToString() == prereqCode)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsDataGridViewEmpty(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow) // Exclude the last empty row used for new entries
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            return false; // Found data
                        }
                    }
                }
            }
            return true; // No actual data found
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MainMenu MM = new MainMenu();
            MM.Show();

            this.Hide();
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
                        thisRow["SFSUBJSTATUS"] = "AC";
                        thisRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text;
                        thisRow["SFSUBJCURRCODE"] = CurriculumYearTextBox.Text;

                        thisDataSet.Tables["SUBJECTFILE"].Rows.Add(thisRow);
                        thisAdapter.Update(thisDataSet, "SUBJECTFILE");

                        MessageBox.Show("Entries Recorded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
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
            }

        }

        private void SaveCoPreButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\63915\Documents\Goco.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection myConnection = new SqlConnection(connectionString);
            string sql = "SELECT * FROM SUBJECTPREQFILE";
            SqlDataAdapter thisAdapter = new SqlDataAdapter(sql, myConnection);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "SubjectPreqFile");

            DataColumn[] keys = new DataColumn[2];

            keys[0] = thisDataSet.Tables["SUBJECTPREQFILE"].Columns["SUBJCODE"];
            keys[1] = thisDataSet.Tables["SUBJECTPREQFILE"].Columns["SUBJPRECODE"];
            thisDataSet.Tables["SUBJECTPREQFILE"].PrimaryKey = keys;

            String[] valuesToSearch = new string[2];
            valuesToSearch[0] = SubjectCodeTextBox.Text;
            valuesToSearch[1] = CourseCodeComboBox.Text;
            DataRow findRow = thisDataSet.Tables["SUBJECTPREqFILE"].Rows.Find(valuesToSearch);

            if (RequisiteSubjectTextBox.Text.Equals(""))
            {
                MessageBox.Show("Missing Subject Code", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!PreRequisiteRadioButton.Checked && !CoRequisiteRadioButton.Checked)
            {
                MessageBox.Show("Please select a category (Pre-requisite or Co-requisite).", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (IsDataGridViewEmpty(SubjectDataGridView))
            {
                MessageBox.Show("The grid is empty or contains only blank rows.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (SubjectRequisiteExists(RequisiteSubjectTextBox.Text, CourseCodeComboBox.Text, thisDataSet.Tables["SUBJECTPREQFILE"]))
            {
                MessageBox.Show("This prerequisite entry already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                if (findRow == null)
                {
                    DataRow thisRow = thisDataSet.Tables["SUBJECTPREQFILE"].NewRow();
                    thisRow["SUBJCODE"] = RequisiteSubjectTextBox.Text;
                    thisRow["SUBJPRECODE"] = CourseCodeComboBox.Text;

                    if (PreRequisiteRadioButton.Checked)
                        thisRow["SUBJCATEGORY"] = "PR";
                    else if (CoRequisiteRadioButton.Checked)
                        thisRow["SUBJCATEGORY"] = "CR";

                    thisDataSet.Tables["SUBJECTPREQFILE"].Rows.Add(thisRow);
                    thisAdapter.Update(thisDataSet, "SUBJECTPREQFILE");

                    MessageBox.Show("Entries Recorded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset UI
                    RequisiteSubjectTextBox.Clear();
                    SubjectDataGridView.Rows.Clear();
                    PreRequisiteRadioButton.Checked = false;
                    CoRequisiteRadioButton.Checked = false;
                }
                else
                {
                    MessageBox.Show("Duplicate subject + prerequisite combination.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
