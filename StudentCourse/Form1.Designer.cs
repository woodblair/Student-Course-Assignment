namespace StudentCourse
{
    partial class MainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.studentButton = new System.Windows.Forms.Button();
            this.courseButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.studentCsvPath = new System.Windows.Forms.Label();
            this.courseCsvPath = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.courseMsg = new System.Windows.Forms.Label();
            this.studentMsg = new System.Windows.Forms.Label();
            this.studentText = new System.Windows.Forms.TextBox();
            this.courseText = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.courseDataGridView = new System.Windows.Forms.DataGridView();
            this.course_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.course_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.couirse_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.72489F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.27511F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 299F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.Controls.Add(this.studentButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.courseButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.showButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveButton, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.studentCsvPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.courseCsvPath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.exitButton, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.courseMsg, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.studentMsg, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.studentText, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.courseText, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 427);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.17722F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.91139F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 97);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // studentButton
            // 
            this.studentButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.studentButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentButton.Location = new System.Drawing.Point(3, 3);
            this.studentButton.Name = "studentButton";
            this.studentButton.Size = new System.Drawing.Size(96, 27);
            this.studentButton.TabIndex = 0;
            this.studentButton.Text = "Load Students";
            this.studentButton.UseVisualStyleBackColor = false;
            this.studentButton.Click += new System.EventHandler(this.studentButton_Click);
            // 
            // courseButton
            // 
            this.courseButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.courseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseButton.Location = new System.Drawing.Point(3, 36);
            this.courseButton.Name = "courseButton";
            this.courseButton.Size = new System.Drawing.Size(96, 25);
            this.courseButton.TabIndex = 1;
            this.courseButton.Text = "Load Courses";
            this.courseButton.UseVisualStyleBackColor = false;
            this.courseButton.Click += new System.EventHandler(this.courseButton_Click);
            // 
            // showButton
            // 
            this.showButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.showButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showButton.Location = new System.Drawing.Point(757, 3);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(118, 27);
            this.showButton.TabIndex = 2;
            this.showButton.Text = "Show Courses";
            this.showButton.UseVisualStyleBackColor = false;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(757, 36);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(118, 25);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // studentCsvPath
            // 
            this.studentCsvPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentCsvPath.Location = new System.Drawing.Point(105, 0);
            this.studentCsvPath.Name = "studentCsvPath";
            this.studentCsvPath.Size = new System.Drawing.Size(110, 33);
            this.studentCsvPath.TabIndex = 4;
            this.studentCsvPath.Text = "Stuents CSV Path:";
            this.studentCsvPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // courseCsvPath
            // 
            this.courseCsvPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseCsvPath.Location = new System.Drawing.Point(105, 33);
            this.courseCsvPath.Name = "courseCsvPath";
            this.courseCsvPath.Size = new System.Drawing.Size(110, 31);
            this.courseCsvPath.TabIndex = 5;
            this.courseCsvPath.Text = "Courses CSV Path:";
            this.courseCsvPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(757, 67);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(118, 27);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // courseMsg
            // 
            this.courseMsg.AutoSize = true;
            this.courseMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseMsg.Location = new System.Drawing.Point(458, 33);
            this.courseMsg.Name = "courseMsg";
            this.courseMsg.Size = new System.Drawing.Size(293, 31);
            this.courseMsg.TabIndex = 8;
            this.courseMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // studentMsg
            // 
            this.studentMsg.AutoSize = true;
            this.studentMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentMsg.Location = new System.Drawing.Point(458, 0);
            this.studentMsg.Name = "studentMsg";
            this.studentMsg.Size = new System.Drawing.Size(293, 33);
            this.studentMsg.TabIndex = 9;
            this.studentMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // studentText
            // 
            this.studentText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentText.Location = new System.Drawing.Point(221, 3);
            this.studentText.Name = "studentText";
            this.studentText.Size = new System.Drawing.Size(231, 20);
            this.studentText.TabIndex = 10;
            this.studentText.TextChanged += new System.EventHandler(this.studentText_TextChanged);
            // 
            // courseText
            // 
            this.courseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseText.Location = new System.Drawing.Point(221, 36);
            this.courseText.Name = "courseText";
            this.courseText.Size = new System.Drawing.Size(231, 20);
            this.courseText.TabIndex = 11;
            this.courseText.TextChanged += new System.EventHandler(this.courseText_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            this.openFileDialog1.Title = "Select a CSV file";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.courseDataGridView, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Title, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.603774F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.39622F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(878, 424);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // courseDataGridView
            // 
            this.courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.course_id,
            this.course_name,
            this.student_name,
            this.student_id,
            this.couirse_state,
            this.student_state});
            this.courseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseDataGridView.Location = new System.Drawing.Point(3, 31);
            this.courseDataGridView.Name = "courseDataGridView";
            this.courseDataGridView.Size = new System.Drawing.Size(872, 390);
            this.courseDataGridView.TabIndex = 0;
            // 
            // course_id
            // 
            this.course_id.HeaderText = "Course ID";
            this.course_id.Name = "course_id";
            // 
            // course_name
            // 
            this.course_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.course_name.HeaderText = "Course Name";
            this.course_name.Name = "course_name";
            this.course_name.Width = 230;
            // 
            // student_name
            // 
            this.student_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.student_name.HeaderText = "Student Name";
            this.student_name.Name = "student_name";
            this.student_name.Width = 200;
            // 
            // student_id
            // 
            this.student_id.HeaderText = "Student ID";
            this.student_id.Name = "student_id";
            // 
            // couirse_state
            // 
            this.couirse_state.HeaderText = "Course State";
            this.couirse_state.Name = "couirse_state";
            // 
            // student_state
            // 
            this.student_state.HeaderText = "Student State";
            this.student_state.Name = "student_state";
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(3, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(872, 28);
            this.Title.TabIndex = 1;
            this.Title.Text = "List Courses and Students";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 524);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Student & Course";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button studentButton;
        private System.Windows.Forms.Button courseButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label studentCsvPath;
        private System.Windows.Forms.Label courseCsvPath;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label courseMsg;
        private System.Windows.Forms.Label studentMsg;
        private System.Windows.Forms.TextBox studentText;
        private System.Windows.Forms.TextBox courseText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView courseDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn course_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn course_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn couirse_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_state;
        private System.Windows.Forms.Label Title;
    }
}

