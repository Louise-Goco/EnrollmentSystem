using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationSystem
{
    public partial class MainMenu: Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void StudentEntryButton_Click(object sender, EventArgs e)
        {
            StudentEntryForm STF = new StudentEntryForm();
            STF.Show();

            this.Hide();
        }

        private void SubjectEntryButton_Click(object sender, EventArgs e)
        {
            SubjectEntry SE = new SubjectEntry();
            SE.Show();

            this.Hide();
        }

        private void SubjectScheduleButton_Click(object sender, EventArgs e)
        {
            SubjectScheduleEntry SSF = new SubjectScheduleEntry();
            SSF.Show();

            this.Hide();
        }

        private void EnrollmentEntryButton_Click(object sender, EventArgs e)
        {
            StudentEnrollmentEntry EDR = new StudentEnrollmentEntry();
            EDR.Show();

            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
