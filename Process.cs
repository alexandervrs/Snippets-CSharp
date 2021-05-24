
/**
 * Process.cs
 * Process related snippets for C#
 */

/* using */
using System.Diagnostics; // for Process, ProcessStartInfo


/* -----------------------------------------
   Run & Execute
----------------------------------------- */

// execute file
ProcessStartInfo processStartInfo = new ProcessStartInfo();
processStartInfo.FileName = "C://text.txt";
processStartInfo.UseShellExecute = true;
System.Diagnostics.Process.Start(processStartInfo);

// open folder
ProcessStartInfo processStartInfo = new ProcessStartInfo();
processStartInfo.FileName = "C://test/";
processStartInfo.UseShellExecute = true;
System.Diagnostics.Process.Start(processStartInfo);

// open URL
ProcessStartInfo processStartInfo = new ProcessStartInfo();
processStartInfo.FileName = "https://google.com";
processStartInfo.UseShellExecute = true;
System.Diagnostics.Process.Start(processStartInfo);

// execute program with arguments
System.Diagnostics.Process process = System.Diagnostics.Process.Start("notepad.exe", "C://text.txt");    
process.WaitForExit(); // wait for program to exit, optional

