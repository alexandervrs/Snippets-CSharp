
/**
 * Windows.UI.PictureBox.cs
 * PictureBox related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a PictureBox
----------------------------------------- */
/// Class Body:
public PictureBox picturebox1;

/// Form Constructor:
picturebox1               = new PictureBox();            
picturebox1.ImageLocation = "Test.png"; // must be in the same folder as the .exe
picturebox1.Location      = new Point(0, 200);
picturebox1.Size          = new Size(120, 40);
picturebox1.SizeMode      = PictureBoxSizeMode.Zoom; // OR PictureBoxSizeMode.CenterImage

form1.Controls.Add(picturebox1);
