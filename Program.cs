using System.Diagnostics;
using System.Security.Principal;
namespace App_Restrict_Test_2
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var GUI = false;
            var isAdmin = false;
            if ((new WindowsPrincipal(WindowsIdentity.GetCurrent())
                .IsInRole(WindowsBuiltInRole.Administrator)))
            {
                GUI = true;
                isAdmin = true;
            }
            if (args.FirstOrDefault("noGUI") == "GUI")
            {
                GUI = true;
            }
            if (GUI)
            {
                Application.Run(new Form1(isAdmin));
            }
            else
            {
                var processes = Process.GetProcesses()
                .Where(p => p.MainWindowHandle != 0)
                    .ToArray();
                string[] allowList = ["System.Diagnostics.Process (explorer)", "System.Diagnostics.Process (NVIDIA Overlay)", "System.Diagnostics.Process (Adobe Desktop Service)", "System.Diagnostics.Process (chrome)", "System.Diagnostics.Process (ShellExperienceHost)", "System.Diagnostics.Process (TextInputHost)"];
                foreach (var process in processes)
                {
                    if (allowList.Contains(process.ToString()))
                    {

                    }
                    else {
                        //MessageBox.Show(process.ToString());
                        var killProgram = MessageBox.Show("Kill Process "+process+"?", "Kill Process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (killProgram == DialogResult.Yes)
                        {
                            process.Kill();
                        }
                    }
                }
            }
        }
    }
}