
/**
 * Class.cs
 * Class related snippets for C#
 */

/* using */
using System; // for Console, Random


/* -----------------------------------------
   Create a Class & use methods
----------------------------------------- */

/* Step 1: create your class file */

// -------------( MyClass.cs )--------------
using System; // for Console

namespace MyNamespace.MyUtils {

	public class MyClass {
		
		public bool IsPlaying { get; set; } // returns (gets) or sets the IsPlaying state

		public static MyClass Create() {
			this.IsPlaying = false; // initialize the playing state of the new object to false
			return new MyClass(); // supply the new object back
		}

		public void Play() {
			this.IsPlaying = true; // update the IsPlaying state of the current object (this)
			Console.Write("Play method called");
		}
		
	}

}
// -------------( MyClass.cs )--------------

/* Step 2: create your script */

// using
using MyNamespace.MyUtils; // using MyClass.cs from MyNamespace.MyUtils

// create object and call method
MyClass classObj = MyClass.Create(); // create a new object
classObj.Play(); // call the Play() method of that object
Console.Write(classObj.IsPlaying); // prints the playing state of that object
classObj.IsPlaying = false;  // sets the playing state of that object


/* -----------------------------------------
   Create a Class Extension
----------------------------------------- */

/* Step 1: create a static class */

public static class ListExtensions
{

	// adds Shuffle() method to List. API
	public static void Shuffle<Τ>(this List<Τ> list) {

		Random rng = new Random();  
		
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = rng.Next(n + 1);  
			Τ value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		} 

	}

	// adds Print() method to List. API
	public static void Print<Τ>(this List<Τ> list) {

		string output = "";
		int i = 0;
		foreach (dynamic listItem in list) {
			output += " "+i+" | "+listItem.ToString()+"\n";
			i++;
		}

		Console.Write(output);

	}

}

/* Step 2: use the new methods */

// create a list
List<int> mylist = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// use the extension methods
mylist.Shuffle();
mylist.Print();


/* -----------------------------------------
   Fluent interface, Method Chaining
----------------------------------------- */

/* Step 1: create a class for the object contents */
public class MyClassObjectContents
{
    public string name;
    public string description;
	// ...
}


/* Step 2: create a class for the chaining methods */
public class MyClass {

    MyClassObjectContents item = new MyClassObjectContents();

	// this method can chain, sets the value for the name
    public MyClass SetName(string name)
    {
        item.name = name;

        return this; // required, return this object for chaining
    }

	// this method can chain, sets the value for the description
    public MyClass SetDescription(string desc)
    {
        item.description = desc;

        return this; // required, return this object for chaining
    }

	// this method does not chain but returns an item value (name)
    public string GetName()
    {
        return item.name;
    }

	// this method does not chain but returns an item value (description)
    public string GetDescription()
    {
        return item.description;
    }

}

/* Step 3: use the new methods */
MyClass myClass = new MyClass();
myClass.SetName("somename").SetDescription("somedesc"); // chain the methods together
