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
        private static string? restrictAll;



        //public static string Base64Encode(string plainText)
        //{
        //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        //    return System.Convert.ToBase64String(plainTextBytes);
        //}

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        [STAThread]
        static void Main(string[] args)
        {
            var GUI = false;
            var isAdmin = false;
            var enableAll = false;
            var noKill = false;
            bool mainLoop = true;
            if ((new WindowsPrincipal(WindowsIdentity.GetCurrent())
                .IsInRole(WindowsBuiltInRole.Administrator)))
            {
                GUI = true;
                isAdmin = true;
                enableAll = true;
                noKill = true;
            }
            if (args.FirstOrDefault("noGUI").ToLower() == "gui")
            {
                GUI = true;
            }
            if (args.Contains("enableAll")) { 
                enableAll = true;
            }
            if (args.Contains("noKill")) { 
                noKill = true;
            }
            if (GUI)
            {
                Application.Run(new Form1(isAdmin,enableAll));
            }
            else
            {
                while (mainLoop)
                {
                    
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
                        //processListFileContents = fileManagerApp.ShiftEncoding(processListFileContents, fileManagerApp.encodingCharSet.Capacity - 7, fileManagerApp.encodingCharSet);
                        processListFileContents = Base64Decode(processListFileContents);
                        processListFile.Close();
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
                                            if (tempStr == "#RESTRICTALLPROCESSES")
                                            {
                                                restrictAll = "all";
                                                Debug.WriteLine("Restriction = all");
                                            }
                                            else {
                                                if (tempStr == "#RESTRICTWINDOWEDPROCESSES")
                                                {
                                                    restrictAll = "win";
                                                    Debug.WriteLine("Restriction = windowed");
                                                }
                                                else {
                                                    if (restrictAll == "")
                                                    {
                                                        Debug.WriteLine("Invalid Restriction State");
                                                    }
                                                    else {
                                                        if (processList.Contains(tempStr)) { Debug.WriteLine("Already Contains: \n" + tempStr); }
                                                        else
                                                        {
                                                            processList.Add(tempStr);
                                                        }
                                                    }
                                                }
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
                        MessageBox.Show("No file exists, stopping to prevent crashing");
                        mainLoop = false;
                    }
                    String[] ArrayVerOfList = processList.ToArray();
                    //for (int i = 0; i < ArrayVerOfList.Length; i++) { 
                    //Debug.WriteLine(ArrayVerOfList[i].ToString());
                    //}

                    if (whiteOrBlackList == "whitelist")
                    {
                        if (restrictAll == "win")
                        {
                            var processes = Process.GetProcesses()
                            .Where(p => p.MainWindowHandle != 0)
                            .ToArray();
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
                                        if (!noKill) { process.Kill(); }
                                    }
                                }
                                else { Debug.WriteLine("Process is null"); }
                            }
                        }
                        if (restrictAll == "all")
                        {
                            var processes = Process.GetProcesses();
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
                                        if (!noKill) { process.Kill(); }
                                    }
                                }
                                else { Debug.WriteLine("Process is null"); }
                            }
                        }

                    }
                    else {
                        if (whiteOrBlackList == "blacklist")
                        {
                            if (restrictAll == "win")
                            {
                                var processes = Process.GetProcesses()
                                .Where(p => p.MainWindowHandle != 0)
                                .ToArray();
                                foreach (var process in processes)
                                {
                                    if (process != null)
                                    {
                                        if (processList.Contains(process.ToString()))
                                        {
                                            Debug.WriteLine("Application '" + process.ToString() + "' is NOT safe | BLACKLISTED");
                                            if (!noKill) { process.Kill(); }
                                        }
                                        else
                                        {
                                            Debug.WriteLine("Application '" + process.ToString() + "' is ok (not on blacklist)");

                                        }
                                    }
                                    else { Debug.WriteLine("Process is null"); }
                                }
                            }
                            if (restrictAll == "all")
                            {
                                var processes = Process.GetProcesses();
                                foreach (var process in processes)
                                {
                                    if (process != null)
                                    {
                                        if (processList.Contains(process.ToString()))
                                        {
                                            Debug.WriteLine("Application '" + process.ToString() + "' is NOT safe | BLACKLISTED");
                                            if (!noKill) { process.Kill(); }
                                        }
                                        else
                                        {
                                            Debug.WriteLine("Application '" + process.ToString() + "' is ok (not on blacklist)");

                                        }
                                    }
                                    else { Debug.WriteLine("Process is null"); }
                                }
                            }

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