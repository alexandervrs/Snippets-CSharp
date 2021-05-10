
/**
 * WindowsForms.ListView.cs
 * ListView related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a ListView
----------------------------------------- */
/// Class Body:
ListView listview1;

/// Form Constructor:
listview1 = new ListView();
listview1.Location = new Point(64, 64);
listview1.Size = new Size(200, 140);
listview1.MultiSelect = false;
listview1.Scrollable = true;
listview1.View = View.LargeIcon; // OR View.List;

listview1.BackColor = Color.Black;
listview1.ForeColor = Color.White;

// Items
listview1.Items.Add("Item 1");
listview1.Items.Add("Item 2");

listview1.SelectedIndexChanged += new EventHandler(delegate(object sender, EventArgs e) // On Item Changed
{

	if (listview1.SelectedItems.Count == 0) {
    	return;
	}

	Console.WriteLine(listview1.SelectedItems[0].Text);
	listview1.SelectedItems[0].BackColor = Color.Red;

});

form1.Controls.Add(listview1);

/* optional: assign custom images to nodes */
ImageList imglist = new ImageList();

imglist.Images.Add(Image.FromFile("root.png"));
imglist.Images.Add(Image.FromFile("test.png"));

listview1.LargeImageList = imglist;

listview1.Items[0].ImageIndex = 0;
listview1.Items[1].ImageIndex = 1;

//

