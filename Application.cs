
/**
 * Application.cs
 * Application related snippets for C#
 */

/* using */
using System; // for Environment
using System.Windows.Forms; // (Windows-Only) for Application
using System.Threading; // for Thread


/* -----------------------------------------
   Quit Application
----------------------------------------- */
// exit application (window or console)
if (System.Windows.Forms.Application.MessageLoop) {
    // Close WinForms App
    Application.Exit();
} else {
    // Close Console App
    Environment.Exit(1);
}


/* -----------------------------------------
   Crash Application
----------------------------------------- */

// crash the application with an unhandled exception
throw new Exception();


/* -----------------------------------------
   Freeze Application
----------------------------------------- */
// freeze the main application thread for 2 seconds
Thread.Sleep(2000);


/* -----------------------------------------
   Trigger DotNet Install Error
----------------------------------------- */
 
/*

	To trigger a helpful DotNet install error if the user
	doesn't have the required DotNet Framework installed:

	1. Create a file <YourExecutableName>.exe.config
	   with the following contents:

<?xml version="1.0" encoding="utf-8"?>
<configuration>  
  <startup>  
    <supportedRuntime version="4.0.30319" />
  </startup>  
</configuration>

	   where 4.0.30319 is your required framework version
	   
	2. Place in the same folder as your Application executable

*/

