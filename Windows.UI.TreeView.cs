
/**
 * Windows.UI.TreeView.cs
 * TreeView related snippets for C#
 */

using System.Windows.Forms; // (Windows-Only) for Control, Form


/* -----------------------------------------
   Create a TreeView
----------------------------------------- */
/// Class Body:
TreeView treeview1;

/// Form Constructor:
treeview1          = new TreeView();
treeview1.Location = new Point(10, 500);
treeview1.Size     = new Size(200, 180);

// Node: Root
TreeNode treenode1 = new TreeNode("Root");
treeview1.Nodes.Add(treenode1);

// Node: Root > Child 1
TreeNode treenode1a = new TreeNode("Child 1");
treenode1.Nodes.Add(treenode1a);

treeview1.SelectedNode = treenode1a; // selected item

treeview1.NodeMouseClick += new TreeNodeMouseClickEventHandler(delegate(object sender, TreeNodeMouseClickEventArgs e) // On Node Clicked
{
	// get selected index of treeview
    if (e.Node != null) {
		Console.WriteLine("Selection Changed to "+e.Node.Text);
	}
});

form1.Controls.Add(treeview1);

/* optional: assign custom images to nodes */
ImageList imglist = new ImageList();

imglist.Images.Add(Image.FromFile("root.png"));
imglist.Images.Add(Image.FromFile("child.png"));

treeview1.ImageList  = imglist;

treenode1.ImageIndex          = 0;
treenode1.SelectedImageIndex  = 0;
treenode1a.ImageIndex         = 1;
treenode1a.SelectedImageIndex = 1;
//

