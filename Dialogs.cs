
/**
 * Dialog.cs
 * Dialog related snippets for C#
 */

/* using */
using System; // for Environment, Console
using System.Windows.Forms; // (Windows-Only) for MessageBox, MessageBoxButtons, MessageBoxIcon, NotifyIcon, DialogResult, SaveFileDialog, OpenFileDialog
using System.IO; // for StreamReader, File

/* -----------------------------------------
   Show Messagebox
----------------------------------------- */

/*

	MessageBoxButtons:
		OK, OKCancel, YesNo, YesNoCancel
	
	MessageBoxIcon:
		None, Warning, Error, Information, Question
	
*/

// show messagebox
MessageBox.Show("Message", "Title", MessageBoxButtons.OK, MessageBoxIcon.None);

// show question
DialogResult dialogResult = MessageBox.Show("Message", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
if (dialogResult == DialogResult.Yes) {
	/// Yes was chosen ...
} else {
	/// No was chosen ...
}


/* -----------------------------------------
   Show Desktop Notification
----------------------------------------- */

NotifyIcon notification = new NotifyIcon()
{
    Visible = true,
    Icon = System.Drawing.SystemIcons.Information,
    BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
    BalloonTipTitle = "My Title",
    BalloonTipText = "My description",
};

// show notification for 2 seconds
notification.ShowBalloonTip(2000);

// remove notification
notification.Dispose();


/* -----------------------------------------
   File Open Dialog
----------------------------------------- */

string fileContents = "";
System.Windows.Forms.OpenFileDialog fileOpenDialog = new System.Windows.Forms.OpenFileDialog();

// dialog properties
fileOpenDialog.Title            = "Open File";
fileOpenDialog.Filter           = "TXT files|*.txt|All files|*.*";
fileOpenDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

if (fileOpenDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fileOpenDialog.FileName)) {
	
	string filePath = fileOpenDialog.FileName;

	if (System.IO.File.Exists(filePath)) {
		
		using(System.IO.StreamReader fileStream = new System.IO.StreamReader(filePath))
		{
			fileContents = fileStream.ReadToEnd();
			fileStream.Close();
			
			Console.WriteLine(fileContents);
			// read or save fileContents ...
		}
	}
	
} else {
	// user Cancel ...
}


/* -----------------------------------------
   File Save Dialog
----------------------------------------- */

string fileContents = "The file contents\nTest line";
System.Windows.Forms.SaveFileDialog fileSaveDialog = new System.Windows.Forms.SaveFileDialog();

// dialog properties
fileSaveDialog.Title            = "Save File";
fileSaveDialog.Filter           = "TXT files|*.txt";
fileSaveDialog.FileName         = "test.txt";
fileSaveDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

if (fileSaveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fileSaveDialog.FileName)) {
	
	string filePath = fileSaveDialog.FileName;

	using(System.IO.StreamWriter fileStream = new System.IO.StreamWriter(filePath))
	{
		fileStream.Write(fileContents);
		fileStream.Close();
	}
	
} else {
	// user Cancel ...
}


/* -----------------------------------------
   Folder Browse Dialog
----------------------------------------- */

System.Windows.Forms.FolderBrowserDialog folderBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();

// dialog properties
folderBrowseDialog.Description         = "Select directory";
folderBrowseDialog.RootFolder          = System.Environment.SpecialFolder.Desktop;
folderBrowseDialog.ShowNewFolderButton = true;

if (folderBrowseDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowseDialog.SelectedPath)) {

	string[] files = System.IO.Directory.GetFiles(folderBrowseDialog.SelectedPath);

	// print info from selected folder
	Console.WriteLine("Selected path is: "+folderBrowseDialog.SelectedPath);
	Console.WriteLine("Files found: " + files.Length.ToString());
	
	foreach (string file in files) {
		Console.WriteLine("File: "+file);
	}
	
} else {
	// user Cancel ...
}

