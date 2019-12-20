
/**
 * UI.ComboBox.cs
 * ComboBox related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a ComboBox
----------------------------------------- */
/// Class Body:
ComboBox combobox1;

/// Form Constructor:
ComboBox combobox1       = new ComboBox();
combobox1.DropDownStyle  = ComboBoxStyle.DropDownList;
combobox1.FlatStyle      = FlatStyle.Flat;
combobox1.Location       = new Point(20, 400);
combobox1.Size           = new Size(164, 25);
combobox1.DropDownHeight = 50;
combobox1.DropDownWidth  = 300;
combobox1.Sorted         = true;

combobox1.BackColor = Color.Orange;
combobox1.ForeColor = Color.Black;

// Items
combobox1.Items.Add("Option 1");
combobox1.Items.Add("Option 2");
combobox1.Items.Add("Option 3");

combobox1.SelectedIndex = 2; // selected item

combobox1.SelectedValueChanged += new EventHandler(delegate(object sender, EventArgs e) // On Option Changed
{
	// get selected index
    Console.WriteLine("Selection Changed to "+combobox1.SelectedIndex);
});

form1.Controls.Add(combobox1);

