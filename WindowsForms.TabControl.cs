
/**
 * WindowsForms.TabControl.cs
 * TabControl related snippets for C#
 */

using System;
using System.Windows.Forms;


/* -----------------------------------------
   Create a Tab Strip
----------------------------------------- */
/// Class Body:
TabControl tabs;

/// Form Constructor:
tabs = new TabControl();

TabPage tabpage1 = new TabPage();
tabpage1.Text = "Tab 1";

TabPage tabpage2 = new TabPage();
tabpage2.Text = "Tab 2";

tabs.TabPages.Add(tabpage1);
tabs.TabPages.Add(tabpage2);

tabs.SelectTab(1); // initial selected tab

tabs.SelectedIndexChanged += new EventHandler(delegate(object sender, EventArgs e) // On Tab Changed
{
	// get selected index
    Console.WriteLine("Selection Changed to "+tabs.SelectedIndex);
});

form1.Controls.Add(tabs);

// create a test UI element
Button btn = new Button();
btn.Text = "Test";

// add the test button inside tabpage1
tabpage1.Controls.Add(btn);

