
/**
 * Application.cs
 * Application related snippets for C#
 */

/* using */
using System; // for Environment
using System.Windows.Forms; // (Windows-Only) for Application
using System.Threading; // for Thread


/* -----------------------------------------
   Main Application
----------------------------------------- */

// note: See UI.*.cs for more info on Form and UI Controls

// -------------( Program.cs )--------------
using System;
using System.Windows.Forms;

using MyForms;
// more modules here ...

namespace MainApplication
{
	
    static class Program
    {
		
        [STAThread]
        static void Main()
        {
			/// more content here...
			
			Console.WriteLine("Version is: "+Application.ProductVersion);
			
			// run the Application with a Form1() as its Main Form
			Application.Run(new Form1());
			
			// OR run it as Console Application
			//Application.Run();
		
		}
	}
	
}
// -------------( Program.cs )--------------

// -------------( Form1.cs )--------------
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace MyForms
{
	public class Form1 : Form 
	{
		
		// Control IDs
		public Form form1;
		// ...
	
		public Form1() 
		{

			form1 = this;

			form1.Text = "My Title";
			form1.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

			form1.Size          = new Size(1280, 720);
			form1.StartPosition = FormStartPosition.CenterScreen;

			/// more content here...

			form1.Show();
			
		}

	}
}

// -------------( Form1.cs )--------------


/* -----------------------------------------
   Get CommandLine Parameters
----------------------------------------- */

string[] Parameters = Environment.GetCommandLineArgs();


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

