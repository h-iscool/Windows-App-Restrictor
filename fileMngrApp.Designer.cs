namespace App_Restrict_Test_2
{
    partial class fileMngrApp
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
            label1 = new Label();
            loadSaveFile = new Button();
            createSaveFile = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(218, 38);
            label1.TabIndex = 0;
            label1.Text = "Current file info:";
            // 
            // loadSaveFile
            // 
            loadSaveFile.Location = new Point(385, 308);
            loadSaveFile.Name = "loadSaveFile";
            loadSaveFile.Size = new Size(112, 34);
            loadSaveFile.TabIndex = 1;
            loadSaveFile.Text = "Load File";
            loadSaveFile.UseVisualStyleBackColor = true;
            loadSaveFile.Click += loadSaveFile_Click;
            // 
            // createSaveFile
            // 
            createSaveFile.Location = new Point(609, 221);
            createSaveFile.Name = "createSaveFile";
            createSaveFile.Size = new Size(112, 34);
            createSaveFile.TabIndex = 2;
            createSaveFile.Text = "Save File";
            createSaveFile.UseVisualStyleBackColor = true;
            createSaveFile.Click += createSaveFile_Click;
            // 
            // fileMngrApp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(createSaveFile);
            Controls.Add(loadSaveFile);
            Controls.Add(label1);
            Name = "fileMngrApp";
            Text = "fileMngrApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button loadSaveFile;
        private Button createSaveFile;
    }
}