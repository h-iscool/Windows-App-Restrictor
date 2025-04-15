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
            var tempAppCMD = "";
            int processIDTEMP;
            string allowGUI = "";
            string allowEnableAll = "";

            List<string> tempProcessList = new List<string>();
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
                processListFileContents = Base64Decode(processListFileContents);
                processListFile.Close();
                Debug.WriteLine("File read as: \n \n" + processListFileContents);
                if (processListFileContents == "")
                {
                    Debug.WriteLine("the file is not ok");
                }

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
                                    else
                                    {
                                        if (tempStr == "#RESTRICTWINDOWEDPROCESSES")
                                        {
                                            restrictAll = "win";
                                            Debug.WriteLine("Restriction = windowed");
                                        }
                                        else
                                        {
                                            if (restrictAll == "")
                                            {
                                                Debug.WriteLine("Invalid Restriction State");
                                            }
                                            else
                                            {
                                                if (tempStr == "#NOGUI")
                                                {
                                                    
                                                    Debug.WriteLine("GUI ARGS DISSABLED");
                                                    allowGUI = "nogui";
                                                }
                                                else {
                                                    if (tempStr == "#GUI")
                                                    {
                                                        Debug.WriteLine("GUI ARGS ENABLED");
                                                        allowGUI = "gui";
                                                    }
                                                    else { if (allowGUI == "")
                                                        {
                                                            Debug.WriteLine("NEED GUI ARG STATUS (TRUE BY DEFAULT)");
                                                            allowGUI = "gui";
                                                        }
                                                        else {
                                                            if (tempStr == "#ALLOWENABLEALL")
                                                            {
                                                                allowEnableAll = "enableAll";
                                                            }
                                                            else {
                                                                if (tempStr == "#NOENABLEALL")
                                                                {
                                                                    allowEnableAll = "NoEnableAll";
                                                                }
                                                                else {
                                                                    if (allowEnableAll == "")
                                                                    {
                                                                        Debug.WriteLine("EnableAll enabled by default");
                                                                        allowEnableAll = "enableAll";
                                                                    }
                                                                    else {
                                                                        if (tempProcessList.Contains(tempStr)) { Debug.WriteLine("Already Contains: \n" + tempStr); }
                                                                        else
                                                                        {
                                                                            tempProcessList.Add(tempStr);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                      }
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
            if (args.Contains("enableAll") && (allowEnableAll=="enableAll" || isAdmin)) { 
                enableAll = true;
            }
            if (isAdmin && args.Contains("noGUI")) { 
                GUI = false;
            }
            if (args.Contains("noKill") && GUI == false)
            {
                noKill = true;
            }
            else { 
                if (GUI)
                {
                    Debug.WriteLine("Redundent and therefore discarded");
                }

            }
            if (GUI)
            {
                if (allowGUI == "gui" || isAdmin)
                {
                    Application.Run(new Form1(isAdmin, enableAll));                           //// pain in a nutshell: semi-complex winforms
                }
                else {
                    MessageBox.Show("GUI has been dissabled by admin","GUI Dissabled",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (args.Length > 0)
                {
                    //mainLoop = false; //FOR TESTING (duh)
                    for (int i = 0; i < args.Length; i++)
                    {
                        Debug.WriteLine($"{args[i].ToString()}");
                    }
                    if (args[0].ToString() == "kill" || args[0].ToString() == "k")
                    {
                        tempAppCMD = "k";
                    }
                    else {
                        if (args[0].ToString() == "refresh" || args[0].ToString() == "r")
                        {
                            tempAppCMD = "r";
                        }
                        else {
                            if (args[0].ToString() == "list" || args[0].ToString() == "l") {
                                tempAppCMD = "l";
                            }
                        }
                    }
                    if (tempAppCMD != "l")
                    {
                        if (int.TryParse(args[1].ToString(), out processIDTEMP))
                        {
                            if (tempAppCMD == "k") { 
                                Process toBeOOFED = Process.GetProcessById(processIDTEMP);
                                if (toBeOOFED != null) { toBeOOFED.Kill(); }
                            }
                            if (tempAppCMD == "r")
                            {
                                Process toBeRefreshed = Process.GetProcessById(processIDTEMP);
                                if (toBeRefreshed != null) { toBeRefreshed.Refresh(); }
                            }
                        }
                        else {
                            MessageBox.Show("... \n \n IT NEEDS A NUMBER ID NOT A PROCESS THING \n \n (im too tired to try to make this not stupid ngl)");
                        }
                    }
                    else {
                        Process[] allProcesses = Process.GetProcesses();
                        for (int i = 0; i < allProcesses.Length; i++) {
                            DialogResult a = MessageBox.Show(allProcesses[i].ToString() +" \\ "+ allProcesses[i].Id, "[DEBUG] List Processes",MessageBoxButtons.OKCancel);
                            if (a == DialogResult.OK)
                            {

                            }
                            else { 
                                break;
                            }
                        }
                    }
                }
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
                        if (processListFileContents == "") {
                            Debug.WriteLine("the file is not ok");
                            break;
                        }

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
                                            else
                                            {
                                                if (tempStr == "#RESTRICTWINDOWEDPROCESSES")
                                                {
                                                    restrictAll = "win";
                                                    Debug.WriteLine("Restriction = windowed");
                                                }
                                                else
                                                {
                                                    if (restrictAll == "")
                                                    {
                                                        Debug.WriteLine("Invalid Restriction State");
                                                    }
                                                    else
                                                    {
                                                        if (tempStr == "#NOGUI")
                                                        {

                                                            Debug.WriteLine("GUI ARGS DISSABLED");
                                                            allowGUI = "nogui";
                                                        }
                                                        else
                                                        {
                                                            if (tempStr == "#GUI")
                                                            {
                                                                Debug.WriteLine("GUI ARGS ENABLED");
                                                                allowGUI = "gui";
                                                            }
                                                            else
                                                            {
                                                                if (allowGUI == "")
                                                                {
                                                                    Debug.WriteLine("NEED GUI ARG STATUS (TRUE BY DEFAULT)");
                                                                    allowGUI = "gui";
                                                                }
                                                                else
                                                                {
                                                                    if (tempStr == "#ALLOWENABLEALL")
                                                                    {
                                                                        allowEnableAll = "enableAll";
                                                                    }
                                                                    else
                                                                    {
                                                                        if (tempStr == "#NOENABLEALL")
                                                                        {
                                                                            allowEnableAll = "NoEnableAll";
                                                                        }
                                                                        else
                                                                        {
                                                                            if (allowEnableAll == "")
                                                                            {
                                                                                Debug.WriteLine("EnableAll enabled by default");
                                                                                allowEnableAll = "enableAll";
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
                                                                }
                                                            }
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
                    else
                    {
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