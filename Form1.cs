using System.Diagnostics;

namespace App_Restrict_Test_2
{
    public partial class Form1 : Form
    {
        public Form1(bool isAdmin)
        {
            InitializeComponent();
            processListBox.Items.Clear();
            if (isAdmin) { label1.Text = "Admin Build"; } else { label1.Text = "Default Build"; }
            Process[] runningProcesses = Process.GetProcesses();
            for (int i = 0; i < runningProcesses.Length; i++)
            {
                processListBox.Items.Add(runningProcesses[i].ProcessName + " | " + runningProcesses[i].Id);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void processListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void forceQuitButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Force quit button pressed");
            for (int i = 0; i < processListBox.Items.Count; i++)
            {
                if (processListBox.GetItemChecked(i) == true)
                {
                    Debug.WriteLine("Process: "+processListBox.Items[i].ToString()+" is checked");
                }
            }
        }
    }
}
