namespace App_Restrict_Test_2
{
    public partial class Form1 : Form
    {
        public Form1(bool isAdmin)
        {
            InitializeComponent();
            if (isAdmin) { label1.Text = "Admin Build"; } else { label1.Text = "Default Build"; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
