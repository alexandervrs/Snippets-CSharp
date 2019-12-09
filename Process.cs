
/**
 * Process.cs
 * Process related snippets for C#
 */

/* using */
using System.Diagnostics; // for Process


/* -----------------------------------------
   Run & Execute
----------------------------------------- */

// execute file
Process.Start("C://text.txt");

// open folder
Process.Start("C://text/");

// open URL
Process.Start("https://google.com");

// execute program with arguments
Process.Start("notepad.exe", "C://text.txt");
