
/**
 * Windows.UI.ContextMenu.cs
 * ContextMenu related snippets for C#
 */

using System;
using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a ContextMenu
----------------------------------------- */
/// Class Body:
ContextMenu contextmenu1;

/// Form Constructor:

// MenuItem: Test
MenuItem contextMenuItem1 = new MenuItem();
contextMenuItem1.Text = "Test";  

contextMenuItem1.Click += new EventHandler(delegate(object sender, EventArgs e) // On Click
{
    Console.WriteLine("Test Clicked");
});

// Context Menu
contextmenu1 = new ContextMenu();
contextmenu1.MenuItems.Clear();
contextmenu1.MenuItems.Add(contextMenuItem1);
//contextmenu1.MenuItems.Add("-"); // add separator

form1.ContextMenu = contextmenu1; // assign contextmenu to form1


/* -----------------------------------------
   Create a ContextMenu (Alternative)
----------------------------------------- */

// note: ContextMenuStrip can also show icons

/// Class Body:
ContextMenuStrip menuStrip;

/// Form Constructor:
menuStrip = new ContextMenuStrip();

ToolStripMenuItem menuItem  = new ToolStripMenuItem();
menuItem.Text = "Test";
menuItem.Image = Image.FromFile("root.png");

menuItem.Click += new EventHandler(delegate(object sender, EventArgs e) // On Click
{
    Console.WriteLine("Test Clicked");
});

menuStrip.Items.Add(menuItem);

// show menu on right click on the form/window
form1.MouseClick += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
{

    // show menu at mouse position on the window
    if (e.Button == MouseButtons.Right) {
        menuStrip.Show(this, this.PointToClient(MousePosition));
    }

});

