
/**
 * System.cs
 * System related snippets for C#
 */

/* using */
using System; // for Environment
using System.Diagnostics;


/* -----------------------------------------
   Get CommandLine Parameters
----------------------------------------- */

string[] Parameters = Environment.GetCommandLineArgs();


/* -----------------------------------------
   Run & Execute
----------------------------------------- */

// execute file
Diagnostics.Process.Start("C://text.txt");

// open folder
Diagnostics.Process.Start("C://text/");

// open URL
Diagnostics.Process.Start("https://google.com");

