
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
		
		// declare Control IDs
		public Form form1;
		public Button button1;
		public TextBox textbox1;
	
		public Form1() 
		{

			// store the Form ID for further operations to it
			form1 = this;

			// set the Form details
			this.Text = "My Title";
			this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			
			// set the Form buttons
			this.MinimizeBox = true;
			this.MaximizeBox = false;
			this.ControlBox  = true;
			
			// set size and position
			this.Size = new Size(1280, 720);
			this.MinimumSize = new Size(800, 600);
			this.MaximumSize = new Size(1280, 720);
			this.StartPosition = FormStartPosition.CenterScreen;
			
			// show in Taskbar
			this.ShowInTaskbar = true;
			
			// make the form non-resizable
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			// OR
			//this.FormBorderStyle = FormBorderStyle.FixedDialog;
			// OR no border
			//this.FormBorderStyle = FormBorderStyle.None;
			
			// Form events
			this.FormClosing += Form1_FormClosing; // On Form Closing
			this.FormClosed += Form1_FormClosed; // On Form Closed
			this.Activated += Form1_Activated; // On Form Activate
			this.Deactivate += Form1_Deactivated; // On Form Deactivate
			
			// set the Form colors
			this.BackColor = DefaultBackColor;
			
			// show the form
			this.Visible = true;

			// activate the form
			this.Activate();
			
			// add a UI Button
			button1 = new Button();
			button1.FlatStyle = FlatStyle.Flat; // make flat styled
			button1.Size = new Size(120, 40);
			button1.Location = new Point(6, 6);
			button1.Text = "Button Text";
			button1.Font = new Font(button1.Font.FontFamily, button1.Font.Size*1.1f); // set font size
			this.Controls.Add(button1);
			button1.Click += new EventHandler(button1_Click); // OnClick event
			button1.MouseEnter += new EventHandler(delegate(object s, EventArgs e) { // MouseEnter event with delegate
				button1.BackColor = Color.FromArgb(139, 158, 193);
				button1.ForeColor = Color.White;
			});
			button1.MouseLeave += new EventHandler(delegate(object s, EventArgs e) { // MouseLeave event with delegate
				button1.BackColor = DefaultBackColor;
				button1.ForeColor = DefaultForeColor;
			});

			// add a UI TextBox
		    textbox1 = new TextBox();
			textbox1.Size = new Size(120, 40);
			textbox1.Location = new Point(6, 62);
			textbox1.Text = "Test";
			this.Controls.Add(textbox1);
			textbox1.LostFocus += new EventHandler(textBox1_LostFocus); // OnChange event

			// add a UI Checkbox
			CheckBox checkbox1 = new CheckBox();
			checkbox1.Size = new Size(120, 40);
			checkbox1.Location = new Point(6, 84);
			checkbox1.Text = "Check";
			this.Controls.Add(checkbox1);
			// add an event to menuitem2
			checkbox1.Click += new EventHandler(delegate(object s, EventArgs e) { // OnClick event with delegate
				Console.WriteLine("Checked: "+checkbox1.Checked);
			});

			// add a UI Label
			Label label1 = new Label();
			label1.Text = "Label";
			label1.ForeColor = Color.FromArgb(139, 158, 193);
			label1.Font = new Font(button1.Font.FontFamily, button1.Font.Size*1.1f); // set font size
			label1.Size = new Size(120, 40);
			label1.Location = new Point(6, 132);
			this.Controls.Add(label1);

			// add a UI PictureBox
			PictureBox pb1 = new PictureBox();            
			pb1.ImageLocation = "Test.png"; // must be in the same folder as the .exe
			pb1.SizeMode = PictureBoxSizeMode.Zoom;
			pb1.Size = new Size(120, 40);
			pb1.Location = new Point(0, 200);
			this.Controls.Add(pb1);

			// add a UI MainMenu
			MainMenu mainMenu1 = new MainMenu();

			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();

			menuItem1.Text = "File";  // File
			menuItem2.Text = "Close"; // File > Close

			// add the MenuItem objects to the MainMenu
			mainMenu1.MenuItems.Add(menuItem1);
			menuItem1.MenuItems.Add(menuItem2);

			// add mainmenu to form1
			this.Menu = mainMenu1;

			// add an event to menuitem2
			menuItem2.Click += new EventHandler(delegate(object s, EventArgs e) { // OnClick event with delegate
				form1.Close(); // close the Form
			});
			
		}
		
		// add event for the Button
		private void button1_Click(object sender, EventArgs e)
		{
			// show the Form as a small new Form
			Form childForm = new Form1();
			childForm.Size = new Size(400, 200);
			childForm.StartPosition = FormStartPosition.CenterScreen;
			childForm.Show();
		}

		// add event for the text
		private void textBox1_LostFocus(object sender, EventArgs e)
		{
			Console.WriteLine("Text Changed to "+textbox1.Text);
		}
		
		// Event Handler > On Form Closing
		private void Form1_FormClosing(Object sender, FormClosingEventArgs e) 
		{
			
			DialogResult dialogResult = MessageBox.Show("Do you want to close this window?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.No) {
				// Don't close the Form if user chooses "No" button
				e.Cancel = true;
			}
		}

		// Event Handler > On Form Closed
		private void Form1_FormClosed(object sender, EventArgs e)
		{
			Console.WriteLine("Form Closed");
		}
		
		// Event Handler > On Form Activated
		private void Form1_Activated(object sender, EventArgs e) 
		{
			Console.WriteLine("Form Active");
			form1.Activate();
		}

		// Event Handler > On Form Deactivated
		private void Form1_Deactivated(object sender, EventArgs e) 
		{
			Console.WriteLine("Form Deactivated");
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

