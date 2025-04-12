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
    public partial class fileMngrApp : Form
    {
        public fileMngrApp(bool isAdmin, bool localEnableAll)
        {
            InitializeComponent();
            if (isAdmin)
            {
                loadSaveFile.Enabled = true;
            }
            else
            {
                loadSaveFile.Enabled = false;
            }
            if (localEnableAll)
            {
                loadSaveFile.Enabled = true;
            }
        }

        private void loadSaveFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.Filter = "App restriction file|*.appreistr|All files (*.*)|*.*";
            loadFileDialog.CheckFileExists = true;
            //loadFileDialog.ShowDialog(this); // not needed

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine("File location: " + loadFileDialog.FileName); //Hey, if anyone is reading this, i saw lava irl 2hrs ago!!! its currently 4 in the morning..... ya..... idk
                //UNFINISHED FEATURE FOR NOW
                //NOT EVEN CLOSE TO BEING NEEDED

            }
        }

        private void createSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "App restriction file|*.appreistr|All files (*.*)|(*.*)";
            saveFileDialog.FileName = "processList";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.ShowDialog();
        }
    }
}
