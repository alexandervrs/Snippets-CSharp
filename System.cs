
/**
 * System.cs
 * System related snippets for C#
 */

/* using */
using System; // for Environment, GC
using System.Diagnostics;


/* -----------------------------------------
   Get CommandLine Parameters
----------------------------------------- */

string[] Parameters = Environment.GetCommandLineArgs();


/* -----------------------------------------
   Run & Execute
----------------------------------------- */

// execute file
Diagnostics.Process.Start("C://text.txt");

// open folder
Diagnostics.Process.Start("C://text/");

// open URL
Diagnostics.Process.Start("https://google.com");


/* -----------------------------------------
   Garbage Collector
----------------------------------------- */

/*
	note: Disabling the Garbage Collector must be done with great care as continuous memory allocations will
	      increase memory usage and will not free any memory. 
		  Disabling the Garbage Collector can help with random hiccups during the application or during a critical execution that is caused by the GC randomly 
		  called by the application. The Garbage Collector can be disabled, any memory allocated ahead of time (e.g. object pooling) 
		  and the GC enabled back along with calling System.GC.Collect() manually to free up memory (usually at the end of an operation or loading/unloading process)
	
*/

 
// mark variable reference as ineligible for Garbage Collection at this point (useful when a reference is still used somewhere else)
List<int> myList = new List<int>(); // create a list
GC.KeepAlive(myList); // mark the list variable reference as ineligible for Garbage Collection at this point

// manually disable Garbage Collection if memory is available for a region of code (.NET 4.6+)
// allow the GC to allocate 15MB
if (GC.TryStartNoGCRegion(15360, true))
{
	try
	{
		// your operation here ...
	}
	finally
	{
		// manually enable Garbage Collection back (.NET 4.6+)
		GC.EndNoGCRegion();
	}
}


// manually do a Garbage Collect 
GC.Collect();