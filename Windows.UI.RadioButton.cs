
/**
 * Windows.UI.RadioButton.cs
 * RadioButton related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form, RadioButton, Panel


/* -----------------------------------------
   Create a Radio Button Group
----------------------------------------- */
/// Class Body:
public Panel radioGroup1;

public RadioButton radiobutton1;
public RadioButton radiobutton2;

/// Form Constructor:
radioGroup1          = new Panel();
radioGroup1.Location = new Point(0, 0); 
radioGroup1.Size     = new Size(80, 100); 

radiobutton1              = new RadioButton();
radiobutton1.Location     = new Point(1, 0);
radiobutton1.Size         = new Size(80, 16);
radiobutton1.Text         = "Option 1";
radiobutton1.AutoEllipsis = false;
radiobutton1.Anchor       = AnchorStyles.Left | AnchorStyles.Top;

radiobutton2              = new RadioButton();
radiobutton2.Location     = new Point(1, 18);
radiobutton2.Size         = new Size(80, 16);
radiobutton2.Text         = "Option 2";
radiobutton1.AutoEllipsis = false;
radiobutton2.Anchor       = AnchorStyles.Left | AnchorStyles.Top;

radiobutton1.Click += new EventHandler(delegate(object sender, EventArgs e) {
    Console.WriteLine("Checked: "+radiobutton1.Checked);
});

// add the radio buttons to the same group using a Panel (or GroupBox) to group them
radioGroup1.Controls.Add(radiobutton1);
radioGroup1.Controls.Add(radiobutton2);

form1.Controls.Add(radioGroup1);

