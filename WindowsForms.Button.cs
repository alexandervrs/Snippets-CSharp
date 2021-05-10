
/**
 * WindowsForms.Button.cs
 * Button related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a Button
----------------------------------------- */
/// Class Body:
public Button button1;

/// Form Constructor:
button1           = new Button();
button1.FlatStyle = FlatStyle.Flat;
button1.Location  = new Point(6, 6);
button1.Size      = new Size(120, 40);
button1.Text      = "My Text";
button1.Font      = new Font(button1.Font.FontFamily, button1.Font.Size*1.1f);

button1.Click += new EventHandler(delegate(object sender, EventArgs e) {
    Console.WriteLine("Clicked");
});
button1.MouseEnter += new EventHandler(delegate(object sender, EventArgs e) {
    button1.BackColor = Color.FromArgb(139, 158, 193);
    button1.ForeColor = Color.White;
});
button1.MouseLeave += new EventHandler(delegate(object sender, EventArgs e) {
    button1.BackColor = DefaultBackColor;
    button1.ForeColor = DefaultForeColor;
});

form1.Controls.Add(button1);


