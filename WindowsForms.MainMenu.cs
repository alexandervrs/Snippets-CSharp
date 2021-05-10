
/**
 * WindowsForms.MainMenu.cs
 * MainMenu related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a MainMenu & MenuItems
----------------------------------------- */
/// Class Body:
public MainMenu mainMenu1;

/// Form Constructor:
mainMenu1 = new MainMenu();
form1.Menu = mainMenu1; // parent the UI Control to Form

// MenuItem: File
MenuItem menuItem1 = new MenuItem();
menuItem1.Text = "File";  
mainMenu1.MenuItems.Add(menuItem1); // parent to mainMenu1

menuItem1.Click += new EventHandler(delegate(object sender, EventArgs e) // On Click
{
    Console.WriteLine("File Clicked");
});

// MenuItem: Edit
MenuItem menuItem2 = new MenuItem();
menuItem2.Text = "Edit";  
mainMenu1.MenuItems.Add(menuItem2); // parent to mainMenu1

menuItem2.Click += new EventHandler(delegate(object sender, EventArgs e) // On Click
{
    Console.WriteLine("Edit Clicked");
});

// MenuItem: File > Close
MenuItem menuItem1b = new MenuItem();
menuItem1b.Text = "Close";
menuItem1.MenuItems.Add(menuItem1b); // parent to menuItem1

menuItem1b.Click += new EventHandler(delegate(object sender, EventArgs e) // On Click
{
    Console.WriteLine("Close Clicked");
    form1.Close(); // close the Form
});


/* -----------------------------------------
   Create a MainMenu (MenuStrip)
----------------------------------------- */
/// Form Constructor:
MenuStrip mainMenu1;

/// Form Constructor:
mainMenu1 = new MenuStrip();
mainMenu1.BackColor = Color.Black;
mainMenu1.ForeColor = Color.White;
mainMenu1.Height = 32;
mainMenu1.Location = new Point(0, 0);
form1.MainMenuStrip = mainMenu1; // parent the UI Control to Form

// MenuItem: File
ToolStripMenuItem menuItem1 = new ToolStripMenuItem();
menuItem1.Text              = "File";  
mainMenu1.Items.Add(menuItem1); // parent to mainMenu1

menuItem1.Click += new EventHandler(delegate(object sender, EventArgs e) // On Click
{
    Console.WriteLine("File Clicked");
});

// MenuItem: Edit
ToolStripMenuItem menuItem2 = new ToolStripMenuItem();
menuItem2.Text              = "Edit";  
mainMenu1.Items.Add(menuItem2); // parent to mainMenu1

menuItem2.Click += new EventHandler(delegate(object sender, EventArgs e) // On Click
{
    Console.WriteLine("Edit Clicked");
});

// MenuItem: File > Close
ToolStripMenuItem menuItem1b = new ToolStripMenuItem();
menuItem1b.Text              = "Close";
menuItem1b.BackColor         = Color.Yellow;
menuItem1.DropDownItems.Add(menuItem1b); // parent to menuItem1

menuItem1b.Click += new EventHandler(delegate(object sender, EventArgs e) // On Click
{
    Console.WriteLine("Close Clicked");
    form1.Close(); // close the Form
});

/* optional: assign custom images to menu items */
ImageList imglist = new ImageList();

imglist.Images.Add(Image.FromFile("root.png"));
imglist.Images.Add(Image.FromFile("child.png"));

mainMenu1.ImageList = imglist;

menuItem1.ImageIndex  = 0;
menuItem1b.ImageIndex = 1;
//

form1.Controls.Add(mainMenu1);

