
/**
 * WindowsForms.Group.cs
 * GroupBox related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form, GroupBox


/* -----------------------------------------
   Create a GroupBox
----------------------------------------- */
/// Class Body:
GroupBox groupbox1;

/// Form Constructor:
groupbox1          = new GroupBox();
groupbox1.Location = new Point(6, 6); 
groupbox1.Size     = new Size(200, 200); 
groupbox1.Text     = "Group"; 

form1.Controls.Add(groupbox1);

// create a test UI element
Button btn = new Button();
btn.Location = new Point(12, 18);
btn.Text = "Test";

// add the test button inside the groupbox
groupbox1.Controls.Add(btn);