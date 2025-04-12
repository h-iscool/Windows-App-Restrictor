using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Restrict_Test_2
{
    public partial class fileManagerApp : Form
    {
        public fileManagerApp()
        {
            InitializeComponent();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private void fileManagerApp_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            if (showall.Checked)
            {
                processList.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processList.Items.Add(runningProcesses[i].ToString());
                }
            }
            else
            {
                processList.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses().Where(p => p.MainWindowHandle != 0).ToArray();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processList.Items.Add(runningProcesses[i].ToString());
                }
            }
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            var generatedFileAsStr = "";
            if (whiteOrBlacklist.Text == "Select One")
            {
                MessageBox.Show("Please Choose either whitelist or blacklist");
            }
            else
            {
                //Gen Save File as string
                if (whiteOrBlacklist.Text == "Whitelist")
                {
                    generatedFileAsStr = "#WHITELIST;";
                }
                else
                {
                    if (whiteOrBlacklist.Text == "Blacklist")
                    {
                        generatedFileAsStr = "#BLACKLIST;";
                    }
                }
                if (restrictBgApps.Checked == true)
                {
                    generatedFileAsStr = generatedFileAsStr + "#RESTRICTALLPROCESSES;";
                }
                else
                {
                    generatedFileAsStr = generatedFileAsStr + "#RESTRICTWINDOWEDPROCESSES;";
                }
                if (alwaysEnabledApps.Checked && whiteOrBlacklist.Text == "Whitelist") // I almost enabled blacklisting this OwO
                {
                    generatedFileAsStr = generatedFileAsStr + "System.Diagnostics.Process (explorer);System.Diagnostics.Process (TextInputHost);System.Diagnostics.Process (App Restrict Test 2);System.Diagnostics.Process (Idle);System.Diagnostics.Process (System);System.Diagnostics.Process (Secure System);System.Diagnostics.Process (Registry);System.Diagnostics.Process (smss);System.Diagnostics.Process (csrss);System.Diagnostics.Process (wininit);System.Diagnostics.Process (services);System.Diagnostics.Process (svchost);System.Diagnostics.Process (fontdrvhost);System.Diagnostics.Process (WUDFHost);System.Diagnostics.Process (atiesrxx);System.Diagnostics.Process (Memory Compression);System.Diagnostics.Process (spoolsv);System.Diagnostics.Process (Admin Service);System.Diagnostics.Process (DAX3API);System.Diagnostics.Process (FMService64);System.Diagnostics.Process (MpDefenderCoreService);System.Diagnostics.Process (MBAMService);System.Diagnostics.Process (unsecapp);System.Diagnostics.Process (AggregatorHost);System.Diagnostics.Process (SearchIndexer);System.Diagnostics.Process (NisSrv);System.Diagnostics.Process (SecurityHealthService);System.Diagnostics.Process (conhost);System.Diagnostics.Process (winlogon);System.Diagnostics.Process (dwrm);System.Diagnostics.Process (AutoModeDetect);System.Diagnostics.Process (sihost);System.Diagnostics.Process (taskhostw);System.Diagnostics.Process (ShellHost);System.Diagnostics.Process (SearchHost);System.Diagnostics.Process (StartMenuExperienceHost);System.Diagnostics.Process (RuntimeBroker);System.Diagnostics.Process (msedgewebview2);System.Diagnostics.Process (ctfmon);System.Diagnostics.Process (SmartSenseController);System.Diagnostics.Process (devenv);System.Diagnostics.Process (RuntimeBroker);System.Diagnostics.Process (cmd);System.Diagnostics.Process (dllhost);System.Diagnostics.Process (MSBuild);System.Diagnostics.Process (DesignToolsServer);System.Diagnostics.Process (MicrosoftEdgeUpdate);System.Diagnostics.Process (Taskmgr);System.Diagnostics.Process (Notepad);"; // NOTE: ONLY A FEW RUN BECAUSE OF THIS APPLICATION, THE OTHERS ARE BACKGROUND PROCESSES THAT ARE HERE TO TRY TO PREVENT FATAL CRASHING. (SOME ALSO ARE THINGS LIKE TASK MANAGER TO STOP PROBLEMS)
                }
                else
                {
                    Debug.WriteLine("@o@");
                }

                if (processList.CheckedItems.Count > 0)
                {

                    for (int i = 0; i < processList.CheckedItems.Count; i++)
                    {
                        if (!generatedFileAsStr.Contains(processList.CheckedItems[i] + ";"))
                        {
                            generatedFileAsStr = generatedFileAsStr + processList.CheckedItems[i] + ";";
                        }
                    }

                }

                if (textBox1.Text != "")
                {
                    generatedFileAsStr = generatedFileAsStr + textBox1.Text;
                }

                //B64:
                generatedFileAsStr = Base64Encode(generatedFileAsStr);

                //Save file dialog:
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "App Restrict File|*.appreistr|All Files (*.*)|(*.*)";
                saveFileDialog.FileName = "processList";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    System.IO.FileStream fileStream = (System.IO.FileStream)saveFileDialog.OpenFile();
                    //PUT SAVE FILE CODE HERE
                    for (int i = 0; generatedFileAsStr.Length > i; i++) { 
                        fileStream.WriteByte((byte)generatedFileAsStr[i]);
                    }
                    fileStream.Close();
                }
            }
        }

        private void alwaysEnabledInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Processes that are 'always enabled' CAN be dissabled through the checkbox, YET dissableing them can cause system instability and crashes. \n \n Always enabled keeps things such as explorer.exe (the desktop GUI) running");
        }

        private void alwaysEnabledApps_CheckedChanged(object sender, EventArgs e)
        {
            if (alwaysEnabledApps.Checked == false)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure? \n \n This action may cause instability", "Action May Cause Instability", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {

                }
                else
                {
                    alwaysEnabledApps.Checked = true;
                }
            }
        }

        private void processList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            if (showall.Checked)
            {
                processList.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processList.Items.Add(runningProcesses[i].ToString());
                }
            }
            else
            {
                processList.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses().Where(p => p.MainWindowHandle != 0).ToArray();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processList.Items.Add(runningProcesses[i].ToString());
                }
            }
        }

        private void showall_CheckedChanged(object sender, EventArgs e)
        {
            if (showall.Checked)
            {
                processList.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processList.Items.Add(runningProcesses[i].ToString());
                }
            }
            else
            {
                processList.Items.Clear();
                Process[] runningProcesses = Process.GetProcesses().Where(p => p.MainWindowHandle != 0).ToArray();
                for (int i = 0; i < runningProcesses.Length; i++)
                {
                    processList.Items.Add(runningProcesses[i].ToString());
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void whiteOrBlacklist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void restrictBgApps_CheckedChanged(object sender, EventArgs e)
        {
            if (restrictBgApps.Checked)
            {
                DialogResult msgbox = MessageBox.Show("This will restrict all apps INCLUDING SYSTEM REQUIRED ONES \n \n Do you know what you are doing?", "Potential System Instability", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgbox != DialogResult.Yes)
                {
                    restrictBgApps.Checked = false;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Warning, this is the most easily breakable object \n \n !!ONLY USE IF YOU KNOW WHAT YOU ARE DOING!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogResult != DialogResult.OK)
                {
                    checkBox1.Checked = false;
                    textBox1.Enabled = false;
                }
                else
                {
                    textBox1.Enabled = true;
                }
            }
            else { 
                textBox1.Enabled = false ;
            }
        }
    }
}
