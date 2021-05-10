
/**
 * Windows.UI.Label.cs
 * Label related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a Text Label
----------------------------------------- */
/// Class Body:
public Label label1;

/// Form Constructor:
label1           = new Label();
label1.Location  = new Point(6, 132);
label1.Size      = new Size(120, 40);
label1.Text      = "My Text";
label1.ForeColor = Color.FromArgb(139, 158, 193);
label1.BackColor = Color.Transparent;
label1.Font      = new Font(button1.Font.FontFamily, button1.Font.Size*1.1f);

form1.Controls.Add(label1);
