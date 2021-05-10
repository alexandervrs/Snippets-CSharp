
/**
 * WindowsForms.SplitContainer.cs
 * SplitContainer related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form, SplitContainer, Orientation, SplitterEventHandler, SplitterEventArgs


/* -----------------------------------------
   Create a SplitContainer
----------------------------------------- */
/// Class Body:
SplitContainer splitcontainer1;

/// Form Constructor:
splitcontainer1               = new SplitContainer();
splitcontainer1.Location      = new Point(0, 0);
splitcontainer1.Size          = new Size(200, 140);
splitcontainer1.Dock          = DockStyle.Fill;
splitcontainer1.BorderStyle   = BorderStyle.FixedSingle;
splitcontainer1.SplitterWidth = 5; // width of Splitter grip
splitcontainer1.Orientation   = Orientation.Vertical; // Horizontal or Vertical

splitcontainer1.Panel1Collapsed = false; // set panel1 to visible
splitcontainer1.Panel2Collapsed = false; // set panel2 to visible

splitcontainer1.Panel1MinSize = 100; // set minimum size of panels

splitcontainer1.Panel1.BackColor = Color.Thistle; // color of first panel
splitcontainer1.Panel2.BackColor = Color.SeaShell; // color of second panel

splitcontainer1.SplitterMoved += new SplitterEventHandler(delegate(object sender, SplitterEventArgs e)
{
	Console.WriteLine("Splitter Moved");
});

form1.Controls.Add(splitcontainer1);

// create a test UI element
Button btn = new Button();
btn.Text = "Test";

// add the test button inside the panel 1 of split container
splitcontainer1.Panel1.Controls.Add(btn);

