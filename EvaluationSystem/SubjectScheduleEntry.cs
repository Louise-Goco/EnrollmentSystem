using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationSystem
{
    public partial class SubjectScheduleEntry: Form
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\63915\Documents\Goco.mdf;Integrated Security=True;Connect Timeout=30";

        public SubjectScheduleEntry()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            AMPMComboBox.Items.Add("AM");
            AMPMComboBox.Items.Add("PM");
        }

        public void ClearFields()
        {
            SubjectEDPCodeTextBox.Clear();
            SubjectCodeTextBox.Clear();
            DescriptionTextBox.Clear();
            AMPMComboBox.SelectedItem = null;
            DaysTextBox.Clear();
            RoomTextBox.Clear();
            SectionTextBox.Clear();
            SchoolYearTextBox.Clear();
        }

        private void SubjectScheduleEntry_Load(object sender, EventArgs e)
        {
            StartDateTimePicker.Format = DateTimePickerFormat.Time;
            StartDateTimePicker.ShowUpDown = true;
            StartDateTimePicker.Format = DateTimePickerFormat.Custom;
            StartDateTimePicker.CustomFormat = "HH:mm tt";

            EndDateTimePicker.Format = DateTimePickerFormat.Time;
            EndDateTimePicker.ShowUpDown = true;
            EndDateTimePicker.Format = DateTimePickerFormat.Custom;
            EndDateTimePicker.CustomFormat = "HH:mm tt";
        }

        private bool SubjectEdpCodeExists(string edpCode, DataTable subjectTable)
        {
            foreach (DataRow row in subjectTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["SSFEDPCODE"].ToString() == edpCode)
                {
                    return true;
                }
            }
            return false;
        }

        static List<int> availableRooms = new List<int>()
           .Concat(new[] { 203 })                 // 203
           .Concat(Enumerable.Range(209, 11))     // 209–219
           .Concat(new[] { 221 })                 // 221
           .Concat(Enumerable.Range(304, 10))     // 304–313
           .Concat(Enumerable.Range(316, 2))      // 316–317
           .Concat(Enumerable.Range(401, 7))      // 401–407
           .Concat(Enumerable.Range(409, 14))     // 409–422
           .Concat(Enumerable.Range(425, 2))      // 425–426
           .Concat(new[] { 502 })                 // 502
           .Concat(Enumerable.Range(518, 4))      // 518–521
           .Concat(Enumerable.Range(601, 12))     // 601–612
           .Concat(Enumerable.Range(620, 7))      // 620–626
           .Concat(Enumerable.Range(701, 13))     // 701–713
           .Concat(Enumerable.Range(717, 2))      // 717–718
           .Concat(Enumerable.Range(801, 4))      // 801–804
           .ToList();

            // Convert to string list for comparison
            static List<string> roomStrings = availableRooms.Select(r => r.ToString()).ToList();

        static List<string> section = new List<string>()
        {
            "1A", "1B", "1D", "1E", "1F", "1G", "1H", "1J", "1K", // 1st year
            "2A", "2B", "2D", "2E", "2F", "2G", // 2nd year
            "3A", "3B", "3D", "3E", "3F", //3rd year
            "4A", "4B", "4D", "4E" //4th year
        };



        private void SaveButton_Click(object sender, EventArgs e)
        {

            SqlConnection myConnection = new SqlConnection(connectionString);

            String sql = "SELECT * FROM SubjectSchedFile";

            SqlDataAdapter subjectAdapter = new SqlDataAdapter(sql, myConnection);
            SqlCommandBuilder subjectBuilder = new SqlCommandBuilder(subjectAdapter);

            DataSet subjectDataSet = new DataSet();
            subjectAdapter.Fill(subjectDataSet, "SubjectSchedFile");

            DataRow schedRow = subjectDataSet.Tables["SubjectSchedFile"].NewRow();

            if (SubjectEDPCodeTextBox.Text.Equals("") ||
                SubjectCodeTextBox.Text.Equals("") ||
                DaysTextBox.Text.Equals("") ||
                RoomTextBox.Text.Equals("") ||
                SectionTextBox.Text.Equals("") ||
                AMPMComboBox.SelectedItem == null ||
                SchoolYearTextBox.Text.Equals(""))
            {
                MessageBox.Show("FILL UP THE REMAINING FIELDS", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (SubjectEdpCodeExists(SubjectEDPCodeTextBox.Text, subjectDataSet.Tables["SubjectSchedFile"]))
            {
                MessageBox.Show("EDP Code already, please create a new one.", "Duplicate EDP Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if(!int.TryParse(SubjectEDPCodeTextBox.Text, out int SubjectEDPCode))
            {
                MessageBox.Show("Subject EDP Code must be an integer", "Invalid Subject Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (!(DaysTextBox.Text == "M" || DaysTextBox.Text == "T" || DaysTextBox.Text == "W" ||
                DaysTextBox.Text == "TH" || DaysTextBox.Text == "F" || DaysTextBox.Text == "S" ||
                DaysTextBox.Text == "MW" || DaysTextBox.Text == "TTH" ||
                DaysTextBox.Text == "MWF" || DaysTextBox.Text == "TTHS"))
            {
                MessageBox.Show("Not a Valid Day. \n Choose the following \n M, T, W, TH, F, S, MW, TTH, MWF, TTHS", "Day/Days not valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (!section.Contains(SectionTextBox.Text))
            {
                MessageBox.Show("Section not available", "Section Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (!roomStrings.Contains(RoomTextBox.Text))
            {
                MessageBox.Show("Room not available", "Room Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (!int.TryParse(SchoolYearTextBox.Text, out int SchoolYear)) // Must be integer
            {
                MessageBox.Show("Year must be an integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (SchoolYear < 2000 || SchoolYear > 2025)
            {
                MessageBox.Show("School Year not valid", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            try
            {
                schedRow["SSFEDPCODE"] = SubjectEDPCodeTextBox.Text;
                schedRow["SSFSUBJCODE"] = SubjectCodeTextBox.Text;
                schedRow["SSFSTARTTIME"] = StartDateTimePicker.Value.ToString("hh:mm tt");
                schedRow["SSFENDTIME"] = EndDateTimePicker.Value.ToString("hh:mm tt");
                schedRow["SSFDAYS"] = DaysTextBox.Text;
                schedRow["SSFROOM"] = Convert.ToInt64(RoomTextBox.Text);
                schedRow["SSFMAXSIZE"] = 1;
                schedRow["SSFCLASSSIZE"] = 0;
                schedRow["SSFSTATUS"] = "AC";
                schedRow["SSFXM"] = AMPMComboBox.SelectedItem.ToString();
                schedRow["SSFSECTION"] = SectionTextBox.Text;
                schedRow["SSFSCHOOLYEAR"] = Convert.ToInt64(SchoolYearTextBox.Text);

                subjectDataSet.Tables["SubjectSchedFile"].Rows.Add(schedRow);
                subjectAdapter.Update(subjectDataSet, "SubjectSchedFile");

                MessageBox.Show("Entries Recored", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MainMenu MM = new MainMenu();
            MM.Show();

            this.Hide();
        }

        private void SubjectCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                bool found = false;
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                SqlCommand subjectCommand = myConnection.CreateCommand();

                subjectCommand.CommandText = "SELECT * FROM SUBJECTFILE";

                SqlDataReader subjectDataReader = subjectCommand.ExecuteReader();
                while (subjectDataReader.Read())
                {
                    if (subjectDataReader["SFSUBJCODE"].ToString().ToUpper() == SubjectCodeTextBox.Text.ToUpper())
                    {
                        DescriptionTextBox.Text = subjectDataReader["SFSUBJDESC"].ToString();

                        found = true;
                        break;
                    }
                    continue;
                }

                if (!found)
                {
                    MessageBox.Show("Subject Code not Found!", "Empty Subject Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                subjectDataReader.Close();
            }
        }

        private void RoomButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(2nd Floor) RM 203, 209-219, 221" +
                "           \r\n(3rd Floor)  RM 304-313, 316-317" +
                "           \r\n(4th Floor)  RM 401-407, 409-422, 425-426" +
                "           \r\n(5th Floor)  RM 502, 518-521" +
                "           \r\n(6th Floor)  RM 601-612, 620-626" +
                "           \r\n(7th Floor)  RM 701-713, 717-718" +
                "           \r\n(8th Floor)  RM 801-804", "List of Rooms", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SectionList_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(1st Year) 1A, 1B, 1D, 1E, 1F, 1G, 1H, 1J, 1K" +
                            "\r\n(2nd Year) 2A, 2B, 2D, 2E, 2F, 2G" +
                            "\r\n(3rd Year) 3A, 3B, 3D, 3E, 3F" +
                            "\r\n(4th Year) 4A, 4B, 4D, 4E", "List of Section", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
