
/**
 * Windows.UI.CheckBox.cs
 * CheckBox related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a CheckBox
----------------------------------------- */
/// Class Body:
public CheckBox checkbox1;

/// Form Constructor:
checkbox1          = new CheckBox();
checkbox1.Location = new Point(6, 84);
checkbox1.Size     = new Size(120, 40);
checkbox1.Text     = "Check Me";

checkbox1.Click += new EventHandler(delegate(object sender, EventArgs e) {
    Console.WriteLine("Checked: "+checkbox1.Checked);
});

form1.Controls.Add(checkbox1);

