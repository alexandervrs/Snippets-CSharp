
/**
 * WindowsForms.StatusBar.cs
 * StatusStrip related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a Statusbar
----------------------------------------- */
/// Class Body:
StatusStrip statusstrip1;

/// Form Constructor:
statusstrip1 = new StatusStrip();
statusstrip1.SizingGrip  = true;

ToolStripStatusLabel toolStripStatusLabel1 = new ToolStripStatusLabel();
toolStripStatusLabel1.Text = "Info";
statusstrip1.Items.Add(toolStripStatusLabel1);

form1.Controls.Add(statusstrip1);


