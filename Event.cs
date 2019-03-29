
/**
 * Event.cs
 * Event & Callback related snippets for C#
 */

/* using */
using System; // for EventHandler, EventArgs, Action, Console


/* -----------------------------------------
   Register and Execute an Event
----------------------------------------- */
/// Class A:

// define the method to execute when OnSomeEvent event is fired
void ExecuteMe(object sender, EventArgs e)
{
	Debug.Log("OnSomeEvent fired!");
}

// create a new object from Class B: MyEventClass
MyEventClass myEventClass = new MyEventClass();

// register event, when MyEventClass fires OnThree event, then execute the action
// note: you can unregister event anytime like: myEventClass.OnSomeEvent -= ExecuteMe;
myEventClass.OnSomeEvent += ExecuteMe;

// execute the class method to return a random number
myEventClass.ExecuteScript();


/// Class B:
public class MyEventClass {

    // declare an Event Handler
    public event System.EventHandler OnSomeEvent;
	// ...
    
    public int ExecuteScript()
    {
        // generate a random int between 0 and 1 for testing
        System.Random rnd = new System.Random();
        int randomNum  = rnd.Next(0, 2);

        // if random number is 1, fire event: OnSomeEvent
        if (randomNum > 0) {
            OnSomeEvent?.Invoke(this, EventArgs.Empty);
        }

        return randomNum;
        
    }

}


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