
/**
 * Callback.cs
 * Callback related snippets for C#
 */

/* using */
using System; // for Action, Console


/* -----------------------------------------
   Doing a Callback using Actions
----------------------------------------- */

// create the method to use as callback
static public void ExecutionFinished(string message)
{
    Console.WriteLine(message);                      
}

// create the function that executes the method with callback
static public void ExecuteScript(Action<string> callThis, string message)
{
    // do things ...
	
	callThis(message); // execute ExecutionFinished(message)
}

// execute the method with the callback
ExecuteScript(ExecutionFinished, message); // execute method with callback and message as 1st parameter


/* -----------------------------------------------
   Pass a Callback to a Method, using Delegates
----------------------------------------------- */
/// Class A:

// declare a delegate format
public delegate void CustomCallback();

// create the function that executes the passed method with callback
public void ExecuteScript(CustomCallback callThis = null) {

    callThis?.Invoke(); // execute passed delegate: ExecuteMe("message", 3)

}

/// Class B:

// define the method to pass for callThis
public void ExecuteMe(string message, int someValue) {
    Console.WriteLine(message+", "+someValue.ToString()); 
}

// usage: execute the method from Class A with the callback from Class B and parameters "message" and 3
ExecuteScript(() => ExecuteMe("message", 3));

// OR execute any code
ExecuteScript(() => { 
    /// execute any code ...
 });