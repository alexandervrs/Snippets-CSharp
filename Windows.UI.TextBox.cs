
/**
 * Windows.UI.TextBox.cs
 * TextBox related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a Textfield
----------------------------------------- */
/// Class Body:
public TextBox textbox1;

/// Form Constructor:
textbox1          = new TextBox();
textbox1.Location = new Point(6, 62);
textbox1.Size     = new Size(120, 40);
textbox1.Text     = "My Text";

textbox1.LostFocus += new EventHandler(delegate(object sender, EventArgs e) {
    Console.WriteLine("Text Changed to "+textbox1.Text);
});

form1.Controls.Add(textbox1);


/* -----------------------------------------
   Create a Textarea
----------------------------------------- */
/// Class Body:
public TextBox textbox1;

/// Form Constructor:
textbox1            = new TextBox();
textbox1.Location   = new Point(6, 62);
textbox1.Size       = new Size(120, 40);
textbox1.Text       = "My Text";
textbox1.Multiline  = true;
textbox1.WordWrap   = false;
textbox1.ScrollBars = ScrollBars.Vertical;

textbox1.LostFocus += new EventHandler(delegate(object sender, EventArgs e) {
    Console.WriteLine("Text Changed to "+textbox1.Text);
});

form1.Controls.Add(textbox1);

