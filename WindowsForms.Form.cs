
/**
 * WindowsForms.Form.cs
 * Form related snippets for C#
 */

using System;
using System.Windows.Forms; // (Windows-Only) for Application, Control, Form
using System.Drawing; // for Point, Size, Color, Image

/* -----------------------------------------
   Create a Form (Window)
----------------------------------------- */
/// Class Body:
public Form form1;

/// Form Constructor:
form1 = this; // keep reference to this Form

form1.Text = "My Title";
form1.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

form1.MinimizeBox = true;
form1.MaximizeBox = false;
form1.ControlBox  = true;

form1.FormBorderStyle = FormBorderStyle.FixedSingle; // OR FormBorderStyle.FixedDialog, FormBorderStyle.Sizable, FormBorderStyle.None (No Border)
form1.WindowState     = FormWindowState.Normal; // OR FormWindowState.Maximized, FormWindowState.Minimized;

form1.TopLevel = false; // set to "true" to have the window on top of all other windows

form1.BackColor = DefaultBackColor; // OR any other color like Color.Black

// OR use a background image
//Image bgImage = new Bitmap("test.png");
//form1.BackgroundImage = bgImage;

form1.Size          = new Size(1280, 720);
form1.MinimumSize   = new Size(800, 600);
form1.MaximumSize   = new Size(1920, 1080);
form1.StartPosition = FormStartPosition.CenterScreen;

form1.ShowInTaskbar = true;

form1.AllowDrop = false; // set to "true" to allow File Drops

form1.DoubleBuffered = false; // set to "true" to reduce any rendering flickering

form1.Cursor = Cursors.Default; // OR other cursors e.g. Arrow, WaitCursor, Cross, No etc.

form1.Visible = true;
form1.Show();
form1.Activate();


/* -----------------------------------------
    Events
----------------------------------------- */
// On Loaded
form1.Load += new EventHandler(delegate(object sender, EventArgs e)
{
    Console.WriteLine("Loaded");
});

// On Closing
form1.FormClosing += new FormClosingEventHandler(delegate(object sender, FormClosingEventArgs e)
{

    // ask user before closing window
    DialogResult dialogResult = MessageBox.Show("Do you want to close this window?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    if (dialogResult == DialogResult.No) {
        // Don't close the Form if user chooses "No" button
        e.Cancel = true;
    }

});

// On Closed
form1.FormClosed += new FormClosedEventHandler(delegate(object sender, FormClosedEventArgs e)
{
    Console.WriteLine("Form Closed");
});

// On Focus Received
form1.Activated  += new EventHandler(delegate(object sender, EventArgs e)
{
    Console.WriteLine("Form Has Focus");
});

// On Focus Lost
form1.Deactivate += new EventHandler(delegate(object sender, EventArgs e)
{
    Console.WriteLine("Form Lost Focus");
});

// On Resize Begin
form1.ResizeBegin += new EventHandler(delegate(object sender, EventArgs e)
{
    Console.WriteLine("Resize Begin");
});

// On Resizing
form1.Resize += new EventHandler(delegate(object sender, EventArgs e)
{
    Console.WriteLine("Resizing...");
});

// On Resize End
form1.ResizeEnd += new EventHandler(delegate(object sender, EventArgs e)
{
    Console.WriteLine("Resized");
});

// On Move
form1.Move += new EventHandler(delegate(object sender, EventArgs e)
{
    Console.WriteLine("Move");
});

// On Frame Paint
form1.Paint += new PaintEventHandler(delegate(object sender, PaintEventArgs e)
{
    Console.WriteLine("Painting...");
});

// On Mouse Click Event
form1.MouseClick += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
{

    if (e.Button == MouseButtons.Left) {
        Console.WriteLine("Left Mouse Button Clicked");
    }

    if (e.Button == MouseButtons.Middle) {
        Console.WriteLine("Middle Mouse Button Clicked");
    }

    if (e.Button == MouseButtons.Right) {
        Console.WriteLine("Right Mouse Button Clicked");
    }

});

// On Mouse Wheel Event
form1.MouseWheel += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
{

    if (ea.Delta > 0) {
        Console.WriteLine("Mouse Wheel Down");
    }

    if (ea.Delta < 0) {
        Console.WriteLine("Mouse Wheel Up");
    }

});

// On Key Down Event
form1.KeyDown += new KeyEventHandler(delegate(object sender, KeyEventArgs e)
{

    // close window if Escape Key is pressed
    if (e.KeyCode == Keys.Escape) {
        Console.WriteLine("Escape Key Down");
        Application.Exit();
    }

});

// On File Drag Over (needs form1.AllowDrop set to "true" in order to work)
form1.DragOver += new DragEventHandler(delegate(object sender, DragEventArgs e)
{

    if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        e.Effect = DragDropEffects.Link;  
    } else {
        e.Effect = DragDropEffects.None;
    }
    
});

// On File Drop (needs form1.AllowDrop set to "true" in order to work)
form1.DragDrop += new DragEventHandler(delegate(object sender, DragEventArgs e)
{

    string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; 

    if (files != null && files.Length > 0) {

        // list dropped files
        foreach (string file in files) {
        	Console.WriteLine(file);
		}

        // populate a Picture Box (see below) with the first dropped file
        //picturebox1.ImageLocation = files[0];
	    //picturebox1.Refresh();

    }

});


/* -----------------------------------------
   Methods
----------------------------------------- */
// show a window
form1.Show();

// hide a window
form1.Hide();

// give focus to a window
form1.Activate();

// close a window
form1.Close();

// repaint a window
form1.Refresh();

// update a window
form1.Update();

// fullscreen a window
form1.WindowState     = FormWindowState.Normal;
form1.FormBorderStyle = FormBorderStyle.None;
form1.WindowState     = FormWindowState.Maximized;
form1.Activate();

// restore a window from fullscreen
form1.FormBorderStyle = FormBorderStyle.Sizable; // OR FormBorderStyle.FixedDialog, FormBorderStyle.None (No Border)
form1.WindowState     = FormWindowState.Normal;

// maximize a window
form1.WindowState = FormWindowState.Maximized;

// get the parent window
Control parentWindow = form1.Parent;
