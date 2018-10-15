
/**
 * Plugin.cs
 * External API, Library related snippets for C#
 */

/* using */
using System; // for IntPtr
using System.Runtime.InteropServices; // for DllImport, CharSet


/* -----------------------------------------
   Calling a Method from a DLL
----------------------------------------- */
// Constructor:

// link to the DLL and expose/define the WINAPI MessageBox method
[DllImport("user32.dll", CharSet = CharSet.Unicode)]
public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);


// Initialize(), Update():
MessageBox(new IntPtr(0), "Message text", "Title text", 0);