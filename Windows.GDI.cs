
/**
 * Windows.GDI.cs
 * Windows Graphics Device Interface (GDI+) related snippets for C#
 */

using System;
using System.Windows.Forms; // (Windows-Only) for Form
using System.Drawing; // (Windows-Only) for Graphics, Color, Bitmap, Image, SolidBrush, Pen, StringFormat
using System.Drawing.Imaging; // (Windows-Only) for PixelFormat
using System.Drawing.Drawing2D; // for (Windows-Only) InterpolationMode


// note: 
//       Graphics & Bitmap are a very quick way to display simple graphics on Windows C# programs
//       but it's not very feature rich or performant, it's best to use something like MonoGame, SlimDX, SharpDX or OpenTK
//       if you're making a game or a graphics-centered application

/* -----------------------------------------
   Draw on Canvas
----------------------------------------- */
/// Form Constructor:
form1.Paint += new PaintEventHandler(delegate(object s, PaintEventArgs e)
{

    // draw graphics using a bitmap buffer
	Bitmap canvasContext = new Bitmap(1280, 720, PixelFormat.Format32bppArgb); // width, height, pixel format (can be omitted)
	canvasContext.MakeTransparent(); // for transparent canvas, needs PixelFormat.Format32bppArgb above

	Graphics canvas1 = Graphics.FromImage(canvasContext);

    // clear background with a color
	canvas1.Clear(Color.White);

	// set interpolation mode
	canvas1.InterpolationMode = InterpolationMode.HighQualityBilinear; // Default, Bicubic, Bilinear, HighQualityBicubic, HighQualityBilinear, Low, NearestNeighbor

    // draw ellipse
	canvas1.DrawEllipse(new Pen(Color.Black, 1f), new Rectangle(1, 1, 65, 65));

	// draw rectangle
	canvas1.DrawRectangle(new Pen(Color.Black, 1f), new Rectangle(68, 1, 65, 65));

	// draw line
	canvas1.DrawLine(new Pen(Color.Black, 1f), 200, 0, 200, 60);

	// draw text
	canvas1.DrawString("My Text 1234567890!?", new Font("Arial", 24, FontStyle.Bold), new SolidBrush(ForeColor), new Point(0, 64));
	// OR with custom color
	canvas1.DrawString("My Text 1234567890!?", new Font("Arial", 25), new SolidBrush(Color.WhiteSmoke), 0, 64, new StringFormat());

	// draw image
	canvas1.DrawImage(Image.FromFile("test.png"), new Point(1, 100));

	// draw filled rectangle
	canvas1.FillRectangle(new SolidBrush(Color.CornflowerBlue), new Rectangle(200, 1, 65, 65));

	// draw filled ellipse
	canvas1.FillEllipse(new SolidBrush(Color.CornflowerBlue), new Rectangle(300, 1, 65, 65));

    // draw the final graphics contents to the canvas buffer
	e.Graphics.DrawImage((Image)canvasContext.Clone(), 0, 0); // 0,0 is the Location of the Canvas
	
});

