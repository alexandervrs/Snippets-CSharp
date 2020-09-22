
/**
 * Tasks.cs
 * Tasks and async related snippets for C#
 */

/* using */
using System.Threading.Tasks; // for Task
using System.Threading; // for CancellationTokenSource, CancellationToken


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
   Cancel Task
----------------------------------------- */

// 1. create a cancellation token and cancellation token source
CancellationTokenSource tokenSource = new CancellationTokenSource();
CancellationToken token = tokenSource.Token;

// 2. create an async task that accounts for the cancellation token
public async Task DoTask(CancellationToken cancellationToken, CancellationTokenSource cancellationTokenSource)
{

	// point that entire DoTask() task can be cancelled at
	if (cancellationToken.IsCancellationRequested) {

		System.Console.WriteLine("Task 1 was cancelled...");

		cancellationTokenSource.Dispose(); // cleanup token
	}

	// some work for Task 1 here...

	System.Console.WriteLine("Task 1 Complete");

	await Task.Delay(1000); // some small delay between the tasks

	// point that entire DoTask() task can be cancelled at
	if (cancellationToken.IsCancellationRequested) {

		System.Console.WriteLine("Task 2 was cancelled...");

		cancellationTokenSource.Dispose(); // cleanup token
	}

	// some work for Task 2 here...

	System.Console.WriteLine("Task 2 Complete");

	cancellationTokenSource.Dispose(); // cleanup token

}


// 3. execute the async task, providing the cancellation token and source
Task task = DoTask(token, tokenSource);

// 4. request a cancellation of the task, could be in a Cancel button click event etc. 
try 
{
	// request cancellation of the task
	tokenSource.Cancel();
} 
catch (System.ObjectDisposedException) 
{
	// catch any case the token might be disposed, normally should not happen.
	// You would need to make sure that tasks that use the cancellation token
	// start and end gracefully
	System.Console.WriteLine("Warning: CancellationToken is Disposed");
}


/* -----------------------------------------
   Delay Task
----------------------------------------- */

// wait 1 second and then go to next line
await Task.Delay(1000);

// keep task alive
await Task.Delay(-1);

