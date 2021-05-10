
/**
 * WindowsForms.ProgressBar.cs
 * ProgressBar related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form, ProgressBar, ControlStyles


/* -----------------------------------------
   Create a ProgressBar
----------------------------------------- */
/// Class Body:
ProgressBar progressbar1;

/// Form Constructor:
progressbar1 = new ProgressBar();
progressbar1.Location = new Point(0, 0);
progressbar1.Size     = new Size(200, 12);

progressbar1.Value = 80; // 0 ... 100

form1.Controls.Add(progressbar1);


/* -----------------------------------------
   Create a ProgressBar (Custom Color)
----------------------------------------- */
// First create a Class to override the ProgressBar's rendering

// -------------( ProgressBarExtended.cs )--------------
using System;
using System.Windows.Forms;
using System.Drawing;
public class ProgressBarExtended : ProgressBar
{
	public Brush Color = Brushes.Red; 
    public ProgressBarExtended()
    {
		this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = e.ClipRectangle;

        rect.Width = (int)(rect.Width * ((double)Value / Maximum)) - 4;

        if (ProgressBarRenderer.IsSupported) {
           ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
        }
        
        rect.Height = rect.Height - 4;
        e.Graphics.FillRectangle(Color, 2, 2, rect.Width, rect.Height);
    }
}
// -------------( ProgressBarExtended.cs )--------------

/// Class Body:
ProgressBarExtended progressbar2;

/// Form Constructor:
progressBar2 = new ProgressBarExtended();
progressBar2.Location    = new Point(0, 0);
progressBar2.Size        = new Size(200, 12);

progressBar2.Value = 80;

progressBar2.Color = Brushes.Red; // set the color

form1.Controls.Add(progressBar2);

