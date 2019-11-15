
/**
 * Debug.cs
 * Debugging related snippets for C#
 */

/* using */
using System; // for Console, ConsoleColor, Exception
using System.IO; // for Path
using System.Text; // for Encoding
using System.Runtime.CompilerServices; // for CallerMemberName, CallerFilePath, CallerLineNumber


/* -----------------------------------------
   Console Window
----------------------------------------- */

// write a message without changing line
Console.Write("My message");

// read input text from user
Console.Write("Enter your name: ");
string name = Console.ReadLine();

// write a message and linebreak
Console.WriteLine("My message");

// clear the console
Console.Clear();

// get the default console colors
ConsoleColor currentBackground = Console.BackgroundColor;
ConsoleColor currentForeground = Console.ForegroundColor;

// set the console text to a color
Console.ForegroundColor = ConsoleColor.Yellow;

// reset the console window colors to the system default
Console.ResetColor();

// set the title of the console window
Console.Title = "My Title";

// change the console encoding to UTF-8
Console.OutputEncoding = Encoding.UTF8;

// change the console input encoding to UTF-8
Console.InputEncoding = Encoding.UTF8;


/* -----------------------------------------
   Error Messages
----------------------------------------- */

// show an error message
throw new Exception("My error message");



/* -----------------------------------------
   Print Method Details (.NET 4.5+)
----------------------------------------- */

// note: these details are provided by the Compiler, does not use Reflection

public int Test(int a, int b, 
	[CallerMemberName] string memberName = "", // will retrieve the Method name, e.g. "Test"
    [CallerFilePath] string sourceFilePath = "", // will retrieve the compiled source code filename
    [CallerLineNumber] int sourceLineNumber = 0 // will retrieve the source code line number
	) {
	// print method details
	Console.WriteLine($"{memberName}() {Path.GetFileName(sourceFilePath)}:{sourceLineNumber}");
	return a + b;
}

