namespace App_Restrict_Test_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            processListBox = new CheckedListBox();
            forceQuitButton = new Button();
            refreshList = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            limitList = new CheckBox();
            fileMngrApp = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1135, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 21);
            label1.TabIndex = 1;
            label1.Text = "Default Build";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(140, 32);
            label2.TabIndex = 2;
            label2.Text = "Process List:";
            // 
            // processListBox
            // 
            processListBox.CheckOnClick = true;
            processListBox.FormattingEnabled = true;
            processListBox.Location = new Point(12, 44);
            processListBox.Name = "processListBox";
            processListBox.Size = new Size(497, 676);
            processListBox.TabIndex = 3;
            processListBox.SelectedIndexChanged += processListBox_SelectedIndexChanged;
            // 
            // forceQuitButton
            // 
            forceQuitButton.Location = new Point(397, 726);
            forceQuitButton.Name = "forceQuitButton";
            forceQuitButton.Size = new Size(112, 34);
            forceQuitButton.TabIndex = 4;
            forceQuitButton.Text = "Force Quit";
            forceQuitButton.UseVisualStyleBackColor = true;
            forceQuitButton.Click += forceQuitButton_Click;
            // 
            // refreshList
            // 
            refreshList.Location = new Point(173, 7);
            refreshList.Name = "refreshList";
            refreshList.Size = new Size(112, 34);
            refreshList.TabIndex = 5;
            refreshList.Text = "Refresh";
            refreshList.UseVisualStyleBackColor = true;
            refreshList.Click += refreshList_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 731);
            label3.Name = "label3";
            label3.Size = new Size(99, 25);
            label3.TabIndex = 6;
            label3.Text = "App ID (#):";
            label3.Click += label3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 729);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(269, 31);
            textBox1.TabIndex = 7;
            // 
            // limitList
            // 
            limitList.AutoSize = true;
            limitList.Location = new Point(335, 9);
            limitList.Name = "limitList";
            limitList.Size = new Size(107, 29);
            limitList.TabIndex = 8;
            limitList.Text = "Limit List";
            limitList.UseVisualStyleBackColor = true;
            limitList.CheckedChanged += limitList_CheckedChanged;
            // 
            // fileMngrApp
            // 
            fileMngrApp.Location = new Point(674, 731);
            fileMngrApp.Name = "fileMngrApp";
            fileMngrApp.Size = new Size(497, 34);
            fileMngrApp.TabIndex = 9;
            fileMngrApp.Text = "Open File Manager";
            fileMngrApp.UseVisualStyleBackColor = true;
            fileMngrApp.Click += fileMngrApp_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1246, 828);
            Controls.Add(fileMngrApp);
            Controls.Add(limitList);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(refreshList);
            Controls.Add(forceQuitButton);
            Controls.Add(processListBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Allowed Apps Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckedListBox processListBox;
        private Button forceQuitButton;
        private Button refreshList;
        private Label label3;
        private TextBox textBox1;
        private CheckBox limitList;
        private Button fileMngrApp;
    }
}
