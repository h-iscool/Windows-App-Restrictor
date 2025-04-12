using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Restrict_Test_2
{
    public partial class fileMngrApp : Form
    {
        public fileMngrApp(bool isAdmin)
        {
            InitializeComponent();
        }

        private void loadSaveFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.ShowDialog(this);
        }
    }
}
