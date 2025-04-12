using System.Diagnostics;

namespace App_Restrict_Test_2
{
    public partial class Form1 : Form
    {
        public bool isAdmin = false;
        public bool firstTick = true;
        public bool enableAll = false;
        public Form1(bool build, bool localEnableAll)
        {
            isAdmin = build;
            InitializeComponent();
            if (isAdmin)
            {
                label1.Text = "Admin Build";
                limitList.Checked = false;
                limitList.Enabled = true;
                forceQuitButton.Enabled = true;
            }
            else
            {
                label1.Text = "Default Build";
                limitList.Checked = true;
                limitList.Enabled = false;
                forceQuitButton.Enabled = false;
            }
            if (localEnableAll) { limitList.Enabled = true; forceQuitButton.Enabled = true; enableAll = true; }
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 50; //50ms interval
            timer.Tick += APPTICK;
            timer.Start();

            if (limitList.Checked)
            {
                processListBox.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses().Where(p => p.MainWindowHandle != 0).ToArray();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processListBox.Items.Add(runningProcesses[i].ProcessName + "|" + runningProcesses[i].Id);
                }
            }
            else
            {
                processListBox.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processListBox.Items.Add(runningProcesses[i].ProcessName + "|" + runningProcesses[i].Id);
                }
            }

        }

        private void APPTICK(object? sender, EventArgs e)
        {
            //Debug.WriteLine("TICK");

            if (firstTick) { firstTick = false; }
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
            Process toKill = Process.GetProcessById(int.Parse(forceQuitAppID.Text));
            if (toKill != null) { toKill.Kill(); }


            //            List<string> APPIDS = new List<string>();
            //            var temp = "";
            //            for (int i = 0; i < processListBox.Items.Count; i++)
            //            {
            //                if (processListBox.GetItemChecked(i) == true)
            //                {
            //                    Debug.WriteLine("Process: " + processListBox.Items[i].ToString() + " is checked");
            //                    bool pastLine = false;
            //#pragma warning disable CS8602 // Dereference of a possibly null reference.
            //                    for (int j = 0; j < processListBox.Items[i].ToString().Length; j++)
            //                    {
            //                        if (pastLine)
            //                        {
            //                            temp = temp + processListBox.Items[i].ToString()[j];
            //                        }
            //                        else
            //                        {
            //                            if (processListBox.Items[i].ToString()[j] == '|')
            //                            {
            //                                pastLine = true;
            //                            }
            //                        }
            //                    }
            //#pragma warning restore CS8602 // Dereference of a possibly null reference.
            //                }
            //                Debug.WriteLine(temp);
            //                temp = "";
            //            }
        }

        private void refreshList_Click(object sender, EventArgs e)
        {
            if (limitList.Checked)
            {
                processListBox.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses().Where(p => p.MainWindowHandle != 0).ToArray();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processListBox.Items.Add(runningProcesses[i].ProcessName + "|" + runningProcesses[i].Id);
                }
            }
            else
            {
                processListBox.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processListBox.Items.Add(runningProcesses[i].ProcessName + "|" + runningProcesses[i].Id);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void limitList_CheckedChanged(object sender, EventArgs e)
        {
            if (limitList.Checked)
            {
                processListBox.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses().Where(p => p.MainWindowHandle != 0).ToArray();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processListBox.Items.Add(runningProcesses[i].ProcessName + "|" + runningProcesses[i].Id);
                }
            }
            else
            {
                processListBox.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processListBox.Items.Add(runningProcesses[i].ProcessName + "|" + runningProcesses[i].Id);
                }
            }
        }

        private void fileMngrApp_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("WATERBUCKET, RELEASE!!!!!!!!");
            fileManagerApp fileManagerApp = new fileManagerApp();
            fileManagerApp.Show();
            //fileManagerApp.Dispose();
        }

        private void forceQuitAppID_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileHolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("processList.appreistr"))
            {
                var processListFileContents = "";
                FileStream processListFile = File.OpenRead("processList.appreistr");
                processListFile.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < processListFile.Length; i++)
                {
                    processListFile.Position = i;
                    processListFileContents = processListFileContents + ((char)((byte)processListFile.ReadByte()));
                }
                processListFileContents = Program.Base64Decode(processListFileContents);
                processListFile.Close();
                fileHolder.Text = processListFileContents;
            }
        }
    }
}
