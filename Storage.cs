
/**
 * Storage.cs
 * Filesystem related snippets for C#
 */

/* using */
using System;            // for Environment, FileAttributes, Console
using System.IO;         // for File, FileInfo, FileMode, Folder, Path, StreamWriter, StreamReader, BinaryWriter, BinaryReader, SearchOption
using System.Reflection; // for Assembly


/* -----------------------------------------
   Write a file
----------------------------------------- */

StreamWriter writer = new StreamWriter("C:\\test.txt");
writer.Write("sample text");
writer.Close();


/* -----------------------------------------
   Read a file
----------------------------------------- */

string data = ""; // the variable to hold the data in
StreamReader reader = new StreamReader("C:\\test.txt");
data = reader.ReadToEnd();
reader.Close();


/* -----------------------------------------
   Write a file (Binary)
----------------------------------------- */

int[] data = new int[] { 12, 32, 20, 250 };

BinaryWriter binWriter = new BinaryWriter(File.Open("C:\\test.bin", FileMode.Create));
foreach (int i in data) {
    binWriter.Write(i);
}
binWriter.Close();


/* -----------------------------------------
   Read a file (Binary)
----------------------------------------- */

BinaryReader binReader = new BinaryReader(File.Open("C:\\test.bin", FileMode.Open));
int seekPosition = 0;
int length = (int)binReader.BaseStream.Length;
while (seekPosition < length) {

    int res = binReader.ReadInt32();
    Console.WriteLine(res);
    seekPosition += sizeof(int);

}
binReader.Close();


/* -----------------------------------------
   Manage files
----------------------------------------- */

// check if file exists
bool fileExists = File.Exists("C:\\test.txt");

// rename
File.Move("C:\\test.txt", "C:\\newTest.txt");

// copy
File.Copy("C:\\test.txt", "C:\\newTest.txt");

// delete
File.Delete("C:\\test.txt");


/* -----------------------------------------
   Get file info
----------------------------------------- */

// check if file is a file
FileAttributes attr = File.GetAttributes("C:\\test.txt");
if ((attr & FileAttributes.Directory) != FileAttributes.Directory) {
	
	// is file ...
	
}

// get file's name, including extension
string fname = Path.GetFileName("C:\\test.txt");

// get file's name (no extension)
string fnameNoExt = Path.GetFileNameWithoutExtension("C:\\test.txt");

// get file's extension
string ext = Path.GetExtension("C:\\test.txt");

// get file's size as bytes (Int64 / long)
long length = new FileInfo("C:\\test.txt").Length;


/* -----------------------------------------
   Manage folders
----------------------------------------- */

// check if folder exists
bool folderExists = Directory.Exists("C:\\test\\");

// create folder
Directory.CreateDirectory("C:\\test\\");

// rename folder
Directory.Move("C:\\test\\", "C:\\newTest\\");

// delete directory
Directory.Delete("C:\\test\\", true); // "true" forces deletion of non-empty folder, use with caution

// get all files in a directory, based on the location of a source file
string[] filePaths = Directory.GetFiles(Path.GetDirectoryName("C:\\test.txt"));

// get all files in a directory, based on the location of a source file, with specified extension (e.g. png)
string[] filePaths = Directory.GetFiles(Path.GetDirectoryName("C:\\test.txt", "*.png"));

// get all files in a directory, based on the location of a source file, also look in all subdirectories
string[] filePaths = Directory.GetFiles(Path.GetDirectoryName("C:\\test.txt", "*.*", SearchOption.AllDirectories));

// get next file from current source file
string sourceFilePath = "C:\\test.txt";

int currentIndex = 0;

string[] filePaths = Directory.GetFiles(Path.GetDirectoryName(sourceFilePath));

int i = 0;
foreach (string thisFile in filePaths) {

    if (thisFile == sourceFilePath) {
        currentIndex = i;
    }

    i++;

}

if (currentIndex+1 > filePaths.Length-1) {
    Console.WriteLine(sourceFilePath);
} else {
    Console.WriteLine(filePaths[currentIndex+1]);
}

// get previous file from current source file
string sourceFilePath = "C:\\test.txt";

int currentIndex = 0;

string[] filePaths = Directory.GetFiles(Path.GetDirectoryName(sourceFilePath));

int i = 0;
foreach (string thisFile in filePaths) {

    if (thisFile == sourceFilePath) {
        currentIndex = i;
    }

    i++;

}

if (currentIndex-1 < 0) {
    Console.WriteLine(sourceFilePath);
} else {
    Console.WriteLine(filePaths[currentIndex-1]);
}


/* -----------------------------------------
   Get folder info
----------------------------------------- */

// retrieve the directory separator character per platform, e.g. "/"
char folderSeparator = Path.DirectorySeparatorChar;

// check if directory is a folder
FileAttributes attr = File.GetAttributes("C:\\test\\");
if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
	
	// is folder ...
	
}


/* -----------------------------------------
   Retrieve System folders
----------------------------------------- */

// get the program's directory
string programDirectory = AppDomain.CurrentDomain.BaseDirectory+Path.DirectorySeparatorChar;

// get the current working directory
string cwd = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

// get the desktop directory
string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

// get appdata (roaming) directory
string localStorageFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

// get user profile directory
string userProfileFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

// get user documents directory
string userDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

