using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Unicode;
namespace App_Restrict_Test_2
{
    internal static class Program
    {
        private static string? whiteOrBlackList;

        [STAThread]
        static void Main(string[] args)
        {
            var GUI = false;
            var isAdmin = false;
            var enableAll = false;
            if ((new WindowsPrincipal(WindowsIdentity.GetCurrent())
                .IsInRole(WindowsBuiltInRole.Administrator)))
            {
                GUI = true;
                isAdmin = true;
                enableAll = true;
            }
            if (args.FirstOrDefault("noGUI").ToLower() == "gui")
            {
                GUI = true;
            }
            if (args.Contains("enableAll")) { 
                enableAll = true;
            }
            if (GUI)
            {
                Application.Run(new Form1(isAdmin,enableAll));
            }
            else
            {
                while (true)
                {
                    var processes = Process.GetProcesses()
                    .Where(p => p.MainWindowHandle != 0)
                        .ToArray();
                    List<string> processList = new List<string>();

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
                        Debug.WriteLine("File read as: \n \n" + processListFileContents);
                        //how to inefficient your code 101 for beginers!

                        //step 1: ask me to write it for you

                        //step 2: never know what you are doing

                        //step 3: go on a 5hr plane ride with out documentation and take 30 minutes to make a bad file reader

                        //ok im done
                        String tempStr = "";
                        for (int i = 0; i < processListFileContents.Length;)
                        {
                            if (processListFileContents[i].ToString() == ";")
                            {
                                //Debug.WriteLine("End Char after text: \n \n" + tempStr);
                                if (tempStr == "#BLACKLIST")
                                {
                                    //BLOCKLIST CODE:
                                    Debug.WriteLine("Type: Blocklist");
                                    whiteOrBlackList = "blacklist";
                                }
                                else
                                {
                                    if (tempStr == "#WHITELIST")
                                    {
                                        //processList CODE:
                                        Debug.WriteLine("Type: whitelist");
                                        whiteOrBlackList = "whitelist";
                                    }
                                    else
                                    {
                                        if (whiteOrBlackList == "")
                                        {
                                            Debug.WriteLine("Invalid file header");
                                        }
                                        else
                                        {
                                            if (processList.Contains(tempStr)) { Debug.WriteLine("Already Contains: \n" + tempStr); }
                                            else
                                            {
                                                processList.Add(tempStr);
                                            }
                                        }
                                    }
                                }
                                tempStr = "";
                            }
                            else
                            {
                                if (processListFileContents[i].ToString() == "\n") { /*Debug.WriteLine("I WAS SO CONFUSED BECAUSE OF THIS BS");*/ }
                                else
                                {
                                    tempStr = tempStr + processListFileContents[i].ToString();
                                }
                            }
                            i++;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("No file exists, stopping to prevent crashing");
                    }
                    String[] ArrayVerOfList = processList.ToArray();
                    //for (int i = 0; i < ArrayVerOfList.Length; i++) { 
                    //Debug.WriteLine(ArrayVerOfList[i].ToString());
                    //}

                    if (whiteOrBlackList == "whitelist")
                    {
                        foreach (var process in processes)
                        {
                            if (process != null)
                            {
                                if (processList.Contains(process.ToString()))
                                {
                                    Debug.WriteLine("Application '" + process.ToString() + "' is safe | WHITELIST ALLOWED");
                                }
                                else
                                {
                                    Debug.WriteLine("Application '" + process.ToString() + "' will close as it is not on whitelist.");

                                }
                            }
                            else { Debug.WriteLine("Process is null"); }
                        }
                        
                    }




                    //OLD CODE:
                    //
                    //
                    //foreach (var process in processes)
                    //{
                    //    if (processList.Contains(process.ToString()))
                    //    {

                    //    }
                    //    else
                    //    {
                    //        //MessageBox.Show(process.ToString());
                    //        var killProgram = MessageBox.Show("Kill Process " + process + "?", "Kill Process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //        if (killProgram == DialogResult.Yes)
                    //        {
                    //            process.Kill();
                    //        }
                    //    }
                    //}
                }
            }
        }
    }
}