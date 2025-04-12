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
            forceQuitButton.Location = new Point(12, 739);
            forceQuitButton.Name = "forceQuitButton";
            forceQuitButton.Size = new Size(112, 34);
            forceQuitButton.TabIndex = 4;
            forceQuitButton.Text = "Force Quit";
            forceQuitButton.UseVisualStyleBackColor = true;
            forceQuitButton.Click += forceQuitButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1246, 828);
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
    }
}
