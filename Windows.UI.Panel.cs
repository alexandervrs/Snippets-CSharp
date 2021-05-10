
/**
 * Windows.UI.Panel.cs
 * Panel related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a Panel
----------------------------------------- */
// note: panels are useful for layout sizing and position and including groups of UI Controls
/// Class Body:
Panel panel1;

/// Form Constructor:
panel1           = new Panel();
panel1.Location  = new Point(0, 0);
panel1.Size      = new Size(200, 140);
panel1.Anchor    = AnchorStyles.Right | AnchorStyles.Top;
panel1.Dock      = DockStyle.Right;
panel1.BackColor = Color.Thistle; // OR Color.Transparent in order not to show anything

// optional: only enable vertical scrolling
panel1.AutoScroll               = false; // to customize scrolling, you must first disable autoscroll
panel1.HorizontalScroll.Enabled = false;
panel1.VerticalScroll.Enabled   = true;
panel1.HorizontalScroll.Maximum = 0;
panel1.AutoScroll               = true;
//

// enable scrolling via mousewheel
panel1.MouseEnter += new EventHandler(delegate(object sender, EventArgs e)
{
    panel1.Focus();
});

form1.Controls.Add(panel1);

