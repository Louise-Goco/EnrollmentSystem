namespace EvaluationSystem
{
    partial class StudentEnrollmentEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StudentEnrollmentEntryLabel = new System.Windows.Forms.Label();
            this.IdNumberLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.IdNumberTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.CourseTextBox = new System.Windows.Forms.TextBox();
            this.EDPCodeTextBox = new System.Windows.Forms.TextBox();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.CourseLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.EDPCodeLabel = new System.Windows.Forms.Label();
            this.SubjectChoosedDataGridView = new System.Windows.Forms.DataGridView();
            this.EDPCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EncodedByLabel = new System.Windows.Forms.Label();
            this.TotalUnitsLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.TotalUnitsTextBox = new System.Windows.Forms.TextBox();
            this.EncodedByTextBox = new System.Windows.Forms.TextBox();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectChoosedDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentEnrollmentEntryLabel
            // 
            this.StudentEnrollmentEntryLabel.BackColor = System.Drawing.SystemColors.Control;
            this.StudentEnrollmentEntryLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StudentEnrollmentEntryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentEnrollmentEntryLabel.Location = new System.Drawing.Point(9, 7);
            this.StudentEnrollmentEntryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StudentEnrollmentEntryLabel.Name = "StudentEnrollmentEntryLabel";
            this.StudentEnrollmentEntryLabel.Size = new System.Drawing.Size(794, 63);
            this.StudentEnrollmentEntryLabel.TabIndex = 3;
            this.StudentEnrollmentEntryLabel.Text = "Student Enrollment Entry";
            this.StudentEnrollmentEntryLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // IdNumberLabel
            // 
            this.IdNumberLabel.AutoSize = true;
            this.IdNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdNumberLabel.Location = new System.Drawing.Point(66, 98);
            this.IdNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IdNumberLabel.Name = "IdNumberLabel";
            this.IdNumberLabel.Size = new System.Drawing.Size(75, 17);
            this.IdNumberLabel.TabIndex = 4;
            this.IdNumberLabel.Text = "ID Number";
            this.IdNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(94, 124);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 17);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IdNumberTextBox
            // 
            this.IdNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdNumberTextBox.Location = new System.Drawing.Point(145, 92);
            this.IdNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.IdNumberTextBox.Name = "IdNumberTextBox";
            this.IdNumberTextBox.Size = new System.Drawing.Size(87, 23);
            this.IdNumberTextBox.TabIndex = 6;
            this.IdNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdNumberTextBox_KeyPress);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(145, 119);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(162, 23);
            this.NameTextBox.TabIndex = 7;
            // 
            // CourseTextBox
            // 
            this.CourseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourseTextBox.Location = new System.Drawing.Point(145, 145);
            this.CourseTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CourseTextBox.Name = "CourseTextBox";
            this.CourseTextBox.Size = new System.Drawing.Size(62, 23);
            this.CourseTextBox.TabIndex = 8;
            // 
            // EDPCodeTextBox
            // 
            this.EDPCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDPCodeTextBox.Location = new System.Drawing.Point(145, 172);
            this.EDPCodeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EDPCodeTextBox.Name = "EDPCodeTextBox";
            this.EDPCodeTextBox.Size = new System.Drawing.Size(87, 23);
            this.EDPCodeTextBox.TabIndex = 9;
            this.EDPCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EDPCodeTextBox_KeyPress);
            // 
            // YearTextBox
            // 
            this.YearTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearTextBox.Location = new System.Drawing.Point(253, 145);
            this.YearTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(62, 23);
            this.YearTextBox.TabIndex = 10;
            // 
            // CourseLabel
            // 
            this.CourseLabel.AutoSize = true;
            this.CourseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourseLabel.Location = new System.Drawing.Point(86, 151);
            this.CourseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CourseLabel.Name = "CourseLabel";
            this.CourseLabel.Size = new System.Drawing.Size(53, 17);
            this.CourseLabel.TabIndex = 11;
            this.CourseLabel.Text = "Course";
            this.CourseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearLabel.Location = new System.Drawing.Point(211, 148);
            this.YearLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(38, 17);
            this.YearLabel.TabIndex = 12;
            this.YearLabel.Text = "Year";
            this.YearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EDPCodeLabel
            // 
            this.EDPCodeLabel.AutoSize = true;
            this.EDPCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDPCodeLabel.Location = new System.Drawing.Point(68, 178);
            this.EDPCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EDPCodeLabel.Name = "EDPCodeLabel";
            this.EDPCodeLabel.Size = new System.Drawing.Size(73, 17);
            this.EDPCodeLabel.TabIndex = 13;
            this.EDPCodeLabel.Text = "EDP Code";
            this.EDPCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SubjectChoosedDataGridView
            // 
            this.SubjectChoosedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubjectChoosedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDPCodeColumn,
            this.SubjectCodeColumn,
            this.StartTimeColumn,
            this.EndTimeColumn,
            this.DaysColumn,
            this.RoomColumn,
            this.UnitsColumn});
            this.SubjectChoosedDataGridView.Location = new System.Drawing.Point(56, 210);
            this.SubjectChoosedDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.SubjectChoosedDataGridView.Name = "SubjectChoosedDataGridView";
            this.SubjectChoosedDataGridView.RowHeadersVisible = false;
            this.SubjectChoosedDataGridView.RowHeadersWidth = 51;
            this.SubjectChoosedDataGridView.RowTemplate.Height = 24;
            this.SubjectChoosedDataGridView.Size = new System.Drawing.Size(703, 213);
            this.SubjectChoosedDataGridView.TabIndex = 14;
            // 
            // EDPCodeColumn
            // 
            this.EDPCodeColumn.HeaderText = "EDP Code";
            this.EDPCodeColumn.Name = "EDPCodeColumn";
            this.EDPCodeColumn.ReadOnly = true;
            // 
            // SubjectCodeColumn
            // 
            this.SubjectCodeColumn.HeaderText = "Subject Code";
            this.SubjectCodeColumn.Name = "SubjectCodeColumn";
            this.SubjectCodeColumn.ReadOnly = true;
            // 
            // StartTimeColumn
            // 
            this.StartTimeColumn.HeaderText = "Start Time";
            this.StartTimeColumn.Name = "StartTimeColumn";
            this.StartTimeColumn.ReadOnly = true;
            // 
            // EndTimeColumn
            // 
            this.EndTimeColumn.HeaderText = "End Time";
            this.EndTimeColumn.Name = "EndTimeColumn";
            this.EndTimeColumn.ReadOnly = true;
            // 
            // DaysColumn
            // 
            this.DaysColumn.HeaderText = "Days";
            this.DaysColumn.Name = "DaysColumn";
            this.DaysColumn.ReadOnly = true;
            // 
            // RoomColumn
            // 
            this.RoomColumn.HeaderText = "Room";
            this.RoomColumn.Name = "RoomColumn";
            this.RoomColumn.ReadOnly = true;
            // 
            // UnitsColumn
            // 
            this.UnitsColumn.HeaderText = "Units";
            this.UnitsColumn.Name = "UnitsColumn";
            this.UnitsColumn.ReadOnly = true;
            // 
            // EncodedByLabel
            // 
            this.EncodedByLabel.AutoSize = true;
            this.EncodedByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodedByLabel.Location = new System.Drawing.Point(56, 489);
            this.EncodedByLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EncodedByLabel.Name = "EncodedByLabel";
            this.EncodedByLabel.Size = new System.Drawing.Size(88, 17);
            this.EncodedByLabel.TabIndex = 15;
            this.EncodedByLabel.Text = "Encoded By:";
            this.EncodedByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalUnitsLabel
            // 
            this.TotalUnitsLabel.AutoSize = true;
            this.TotalUnitsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalUnitsLabel.Location = new System.Drawing.Point(600, 440);
            this.TotalUnitsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalUnitsLabel.Name = "TotalUnitsLabel";
            this.TotalUnitsLabel.Size = new System.Drawing.Size(76, 17);
            this.TotalUnitsLabel.TabIndex = 16;
            this.TotalUnitsLabel.Text = "Total Units";
            this.TotalUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.Location = new System.Drawing.Point(320, 489);
            this.DateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(38, 17);
            this.DateLabel.TabIndex = 17;
            this.DateLabel.Text = "Date";
            this.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalUnitsTextBox
            // 
            this.TotalUnitsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalUnitsTextBox.Location = new System.Drawing.Point(680, 437);
            this.TotalUnitsTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TotalUnitsTextBox.Name = "TotalUnitsTextBox";
            this.TotalUnitsTextBox.ReadOnly = true;
            this.TotalUnitsTextBox.Size = new System.Drawing.Size(124, 23);
            this.TotalUnitsTextBox.TabIndex = 18;
            this.TotalUnitsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EncodedByTextBox
            // 
            this.EncodedByTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodedByTextBox.Location = new System.Drawing.Point(148, 483);
            this.EncodedByTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EncodedByTextBox.Name = "EncodedByTextBox";
            this.EncodedByTextBox.Size = new System.Drawing.Size(124, 23);
            this.EncodedByTextBox.TabIndex = 19;
            this.EncodedByTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker.Location = new System.Drawing.Point(358, 485);
            this.DateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(237, 23);
            this.DateTimePicker.TabIndex = 21;
            // 
            // SaveButton
            // 
            this.SaveButton.AutoSize = true;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(56, 549);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(78, 27);
            this.SaveButton.TabIndex = 26;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.AutoSize = true;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(158, 549);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(78, 27);
            this.CancelButton.TabIndex = 27;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // StudentEnrollmentEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(812, 612);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.EncodedByTextBox);
            this.Controls.Add(this.TotalUnitsTextBox);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.TotalUnitsLabel);
            this.Controls.Add(this.EncodedByLabel);
            this.Controls.Add(this.SubjectChoosedDataGridView);
            this.Controls.Add(this.EDPCodeLabel);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.CourseLabel);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.EDPCodeTextBox);
            this.Controls.Add(this.CourseTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.IdNumberTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IdNumberLabel);
            this.Controls.Add(this.StudentEnrollmentEntryLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StudentEnrollmentEntry";
            this.Text = "StudentEnrollmentEntry";
            ((System.ComponentModel.ISupportInitialize)(this.SubjectChoosedDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StudentEnrollmentEntryLabel;
        private System.Windows.Forms.Label IdNumberLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox IdNumberTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox CourseTextBox;
        private System.Windows.Forms.TextBox EDPCodeTextBox;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.Label CourseLabel;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label EDPCodeLabel;
        private System.Windows.Forms.DataGridView SubjectChoosedDataGridView;
        private System.Windows.Forms.Label EncodedByLabel;
        private System.Windows.Forms.Label TotalUnitsLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.TextBox TotalUnitsTextBox;
        private System.Windows.Forms.TextBox EncodedByTextBox;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDPCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn;
    }
}