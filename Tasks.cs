
/**
 * Tasks.cs
 * Tasks and async related snippets for C#
 */

/* using */
using System.Threading.Tasks; // for Task


/* -----------------------------------------
   Perform Async Task
----------------------------------------- */

// 1. create a method that will execute asynchronously
public async Task DoTask()
{
	await Task.Delay(1000); // wait 1 seconds
	System.Console.WriteLine("Task Executed");
}

// 2. execute that method and return the task reference
Task tsk = DoTask();

// 3. check when async task is completed
tsk.ContinueWith(delegate {
	
	// perform actions when task is complete
	// ...
	System.Console.WriteLine("Task Completed");

});


/* -----------------------------------------
   Complete a collection of Tasks
----------------------------------------- */

// 1. create two or more methods that will execute asynchronously
public async Task DoTask1()
{
	await Task.Delay(1000); // wait 1 seconds
	System.Console.WriteLine("Task 1 Executed");
}

public async Task DoTask2()
{
	await Task.Delay(2000); // wait 2 seconds
	System.Console.WriteLine("Task 2 Executed");
}

// 2. create an async method that performs all tasks
public async Task DoAllTasks()
{
	await Task.WhenAll(
		DoTask1(),
		DoTask2()
	);
}

// 3. execute that method and return the task reference
Task tskCollection = DoAllTasks();

// 4. check for completion of all assigned tasks
tskCollection.ContinueWith(delegate {

	// perform actions when task is complete
	// ...
	System.Console.WriteLine("All Tasks Completed");

});


/* -----------------------------------------
   Delay Task
----------------------------------------- */

// wait 1 second and then go to next line
await Task.Delay(1000);

// keep task alive
await Task.Delay(-1);