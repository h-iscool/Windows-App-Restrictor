namespace App_Restrict_Test_2
{
    partial class fileManagerApp
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
            saveFile = new Button();
            whiteOrBlacklist = new ComboBox();
            label1 = new Label();
            alwaysEnabledInfo = new Button();
            alwaysEnabledApps = new CheckBox();
            processList = new CheckedListBox();
            runningProcesses = new Label();
            refreshbutton = new Button();
            showall = new CheckBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            restrictBgApps = new CheckBox();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // saveFile
            // 
            saveFile.BackColor = Color.SlateGray;
            saveFile.FlatStyle = FlatStyle.Flat;
            saveFile.ForeColor = Color.WhiteSmoke;
            saveFile.Location = new Point(1058, 520);
            saveFile.Name = "saveFile";
            saveFile.Size = new Size(112, 34);
            saveFile.TabIndex = 0;
            saveFile.Text = "Save File";
            saveFile.UseVisualStyleBackColor = false;
            saveFile.Click += saveFile_Click;
            // 
            // whiteOrBlacklist
            // 
            whiteOrBlacklist.BackColor = Color.SlateGray;
            whiteOrBlacklist.FlatStyle = FlatStyle.Flat;
            whiteOrBlacklist.ForeColor = Color.WhiteSmoke;
            whiteOrBlacklist.FormattingEnabled = true;
            whiteOrBlacklist.Items.AddRange(new object[] { "Whitelist", "Blacklist" });
            whiteOrBlacklist.Location = new Point(988, 11);
            whiteOrBlacklist.Name = "whiteOrBlacklist";
            whiteOrBlacklist.Size = new Size(182, 33);
            whiteOrBlacklist.TabIndex = 1;
            whiteOrBlacklist.Text = "Select One";
            whiteOrBlacklist.SelectedIndexChanged += whiteOrBlacklist_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(898, 12);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 2;
            label1.Text = "List Type:";
            // 
            // alwaysEnabledInfo
            // 
            alwaysEnabledInfo.BackColor = Color.SlateGray;
            alwaysEnabledInfo.FlatStyle = FlatStyle.Flat;
            alwaysEnabledInfo.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            alwaysEnabledInfo.ForeColor = Color.WhiteSmoke;
            alwaysEnabledInfo.Location = new Point(1011, 630);
            alwaysEnabledInfo.Name = "alwaysEnabledInfo";
            alwaysEnabledInfo.Size = new Size(159, 34);
            alwaysEnabledInfo.TabIndex = 3;
            alwaysEnabledInfo.Text = "Always Enabled Info";
            alwaysEnabledInfo.UseVisualStyleBackColor = false;
            alwaysEnabledInfo.Click += alwaysEnabledInfo_Click;
            // 
            // alwaysEnabledApps
            // 
            alwaysEnabledApps.AutoSize = true;
            alwaysEnabledApps.BackColor = Color.SlateGray;
            alwaysEnabledApps.Checked = true;
            alwaysEnabledApps.CheckState = CheckState.Checked;
            alwaysEnabledApps.FlatStyle = FlatStyle.Flat;
            alwaysEnabledApps.ForeColor = Color.WhiteSmoke;
            alwaysEnabledApps.Location = new Point(967, 676);
            alwaysEnabledApps.Name = "alwaysEnabledApps";
            alwaysEnabledApps.Size = new Size(203, 29);
            alwaysEnabledApps.TabIndex = 4;
            alwaysEnabledApps.Text = "Always Enabled Apps";
            alwaysEnabledApps.UseVisualStyleBackColor = false;
            alwaysEnabledApps.CheckedChanged += alwaysEnabledApps_CheckedChanged;
            // 
            // processList
            // 
            processList.BackColor = Color.SlateGray;
            processList.BorderStyle = BorderStyle.FixedSingle;
            processList.CheckOnClick = true;
            processList.ForeColor = Color.WhiteSmoke;
            processList.FormattingEnabled = true;
            processList.Location = new Point(12, 46);
            processList.Name = "processList";
            processList.Size = new Size(492, 618);
            processList.TabIndex = 5;
            processList.SelectedIndexChanged += processList_SelectedIndexChanged;
            // 
            // runningProcesses
            // 
            runningProcesses.AutoSize = true;
            runningProcesses.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            runningProcesses.Location = new Point(12, 9);
            runningProcesses.Name = "runningProcesses";
            runningProcesses.Size = new Size(233, 32);
            runningProcesses.TabIndex = 6;
            runningProcesses.Text = "Running Processesss";
            // 
            // refreshbutton
            // 
            refreshbutton.BackColor = Color.SlateGray;
            refreshbutton.FlatStyle = FlatStyle.Flat;
            refreshbutton.ForeColor = Color.WhiteSmoke;
            refreshbutton.Location = new Point(392, 7);
            refreshbutton.Name = "refreshbutton";
            refreshbutton.Size = new Size(112, 34);
            refreshbutton.TabIndex = 7;
            refreshbutton.Text = "refresh";
            refreshbutton.UseVisualStyleBackColor = false;
            refreshbutton.Click += refreshbutton_Click;
            // 
            // showall
            // 
            showall.AutoSize = true;
            showall.BackColor = Color.SlateGray;
            showall.FlatStyle = FlatStyle.Flat;
            showall.ForeColor = Color.WhiteSmoke;
            showall.Location = new Point(284, 7);
            showall.Name = "showall";
            showall.Size = new Size(97, 29);
            showall.TabIndex = 8;
            showall.Text = "show all";
            showall.UseVisualStyleBackColor = false;
            showall.CheckedChanged += showall_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.SlateGray;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.ForeColor = Color.WhiteSmoke;
            textBox1.Location = new Point(521, 46);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(331, 624);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(577, 2);
            label2.Name = "label2";
            label2.Size = new Size(210, 32);
            label2.TabIndex = 10;
            label2.Text = "Custom Processes:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.SlateGray;
            label3.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(553, 640);
            label3.Name = "label3";
            label3.Size = new Size(259, 17);
            label3.TabIndex = 11;
            label3.Text = "seperate with semicolon NO NEWLINES";
            // 
            // restrictBgApps
            // 
            restrictBgApps.AutoSize = true;
            restrictBgApps.BackColor = Color.SlateGray;
            restrictBgApps.FlatStyle = FlatStyle.Flat;
            restrictBgApps.ForeColor = Color.WhiteSmoke;
            restrictBgApps.Location = new Point(933, 595);
            restrictBgApps.Name = "restrictBgApps";
            restrictBgApps.Size = new Size(237, 29);
            restrictBgApps.TabIndex = 12;
            restrictBgApps.Text = "Restrict Background Apps";
            restrictBgApps.UseVisualStyleBackColor = false;
            restrictBgApps.CheckedChanged += restrictBgApps_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.SlateGray;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.ForeColor = Color.WhiteSmoke;
            checkBox1.Location = new Point(993, 560);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(177, 29);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Custom Processes";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // fileManagerApp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(1182, 717);
            Controls.Add(checkBox1);
            Controls.Add(restrictBgApps);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(showall);
            Controls.Add(refreshbutton);
            Controls.Add(runningProcesses);
            Controls.Add(processList);
            Controls.Add(alwaysEnabledApps);
            Controls.Add(alwaysEnabledInfo);
            Controls.Add(label1);
            Controls.Add(whiteOrBlacklist);
            Controls.Add(saveFile);
            ForeColor = Color.WhiteSmoke;
            Name = "fileManagerApp";
            Text = "File Manager";
            Load += fileManagerApp_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveFile;
        private ComboBox whiteOrBlacklist;
        private Label label1;
        private Button alwaysEnabledInfo;
        private CheckBox alwaysEnabledApps;
        private CheckedListBox processList;
        private Label runningProcesses;
        private Button refreshbutton;
        private CheckBox showall;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private CheckBox restrictBgApps;
        private CheckBox checkBox1;
    }
}