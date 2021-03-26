
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
		
		public bool IsPlaying { get; set; } // A public Property, returns (gets) or sets the IsPlaying state. Remove set; to make it readonly

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
// -------------( ListExtensions.cs )--------------
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
// -------------( ListExtensions.cs )--------------

/* Step 2: use the new methods */

// create a list
List<int> mylist = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// use the extension methods
mylist.Shuffle();
mylist.Print();


/* --------------------------------------------
   Property Get/Set, Accessing Private Fields
-------------------------------------------- */

/* Step 1: create a class */
// -------------( MyClass.cs )--------------
public class MyClass
{
    private string name; // private field
	
    // public property that gets or sets the private field "name"
    // Properties will allow you to use different more semantic names for the private fields
    // or do some extra operations before setting or getting the value
    public string Name 
    {
        get { return name; }
        set { name = value; } // "value" is what we will assign "name" to be when setting this Property's value
    }

}
// -------------( MyClass.cs )--------------

/* Step 2: use the new methods */
MyClass myClassInstance = new MyClass();
myClassInstance.Name = "Test"; // set the "name" field using Name property and value "Test"
Console.WriteLine( myClassInstance.Name ); // get the "name" field using Name property
//myClassInstance.name will not work because the "name" field is private


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
// -------------( MyClass.cs )--------------
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
// -------------( MyClass.cs )--------------

/* Step 3: use the new methods */

MyClass myClass = new MyClass();
myClass.SetName("somename").SetDescription("somedesc"); // chain the methods together


/* -----------------------------------------
   Inherit from a Base Class
----------------------------------------- */

/* Step 1: create a Base parent class */
// -------------( BaseClass.cs )--------------
public abstract class BaseClass // parent class is marked as abstract so we can define abstract/virtual methods
{
    
    // variable that only exists in BaseClass but can be get/set from its child classes
    // protected means private but allows its derived classes to access it
    public virtual string classVariable { get; set; }

    // this variable is ONLY access in this class, not accessible from ChildClass
    private string classOnlyVariable = "classOnlyVariable";

    // abstract method exists conceptually but lacks an implementation
    // implementation should be done in ChildClass
    public abstract string AbstractMethod();

    // method with an implementation that can be overriden in ChildClass
    public virtual string VirtualMethod()
    {
        return "BaseClass VirtualMethod()";
    }

    // regular method in BaseClass, cannot be overriden
    // can be accessed with base.RegularMethodGetVariableFromBase() from ChildClass
    public string RegularMethodGetVariableFromBase()
    {
        return "RegularMethodGetVariableFromBase()";
    }

}
// -------------( BaseClass.cs )--------------


/* Step 2: create a class that would inherit from Base class */
// -------------( ChildClass.cs )--------------
public class ChildClass : BaseClass // child of and inherits from BaseClass
{

    // variable that only exists in ChildClass
    public string classVariable = "classVariable from Child Class";

    // implementation of AbstractMethod()
    public override string AbstractMethod()
    {
        return "ChildClass AbstractMethod()";
    }

    // overrides BaseClass VirtualMethod() with this implementation instead
    public override string VirtualMethod()
    {
        // base.VirtualMethod(); // you can also call the same VirtualMethod() from BaseClass inside the same method
        // OR
        // return base.VirtualMethod(); // you can also return the result of VirtualMethod() instead
        // OR
        return "ChildClass VirtualMethod()"; // return the result from this VirtualMethod() in ChildClass
    }

    // return VirtualMethod() from BaseClass from this method
    public string CallBaseVirtualMethod()
    {
        return base.VirtualMethod();
    }

    // returns classVariable from this ChildClass
    public string GetChildClassVariable()
    {
        return this.classVariable;
    }

    // returns classVariable from BaseClass
    public string GetBaseClassVariable()
    {
        return base.classVariable;
    }

	// calls RegularMethodGetVariableFromBase() from BaseClass
    public string CallRegularMethodGetVariableFromBase()
    {
        return base.RegularMethodGetVariableFromBase();
    }

}
// -------------( ChildClass.cs )--------------

/* Step 3: use the methods */

// use class that implements a base class
ChildClass obj = new ChildClass();

Console.WriteLine( obj.VirtualMethod() );


/* -----------------------------------------
   Implement from Interface Class
----------------------------------------- */

/* Step 1: create an interface class */
// -------------( IClass.cs )--------------
// define an interface, usually interface names have an "I" prefix (.NET guidelines suggest it does)
public interface IClass 
{

    // note: all properties and methods in an interface are public
	//       interfaces do not provide the implementation 
	//       but rather ensure the class that implements them does implement all their functionality

    // add a property to our interface
    int InterfaceProperty { get; set; }

    // add a method to our interface that will return a string result
    string InterfaceMethod();

}
// -------------( IClass.cs )--------------


/* Step 2: create a second class that will implement that interface */

// -------------( ClassThatImplementsInterface.cs )--------------
public class ClassThatImplementsInterface : IClass // implements interface IClass, you can implement multiple interfaces like "ClassThatImplementsInterface : IClass, IDisposable, IEquatable" etc.
{

    // implementation of InterfaceProperty from IClass in this class
    public int InterfaceProperty { get; set; }

    // implementation of InterfaceMethod() from IClass in this class
    public string InterfaceMethod()
    {
        return "ClassThatImplementsInterface InterfaceMethod()";
    }

}
// -------------( ClassThatImplementsInterface.cs )--------------

/* Step 3: use the methods */

// use class that implements interface
ClassThatImplementsInterface obj = new ClassThatImplementsInterface();

Console.WriteLine( obj.InterfaceMethod() );


/* -----------------------------------------
   Split Class into multiple files
----------------------------------------- */

// note: partial keyword is used to split class files into multiple ones
//       useful to reduce noise with classes or when a class has a section
//       that doesn't need to be changed as often

/* Step 1: create the class files */
// -------------( PartialClassA.cs )--------------
public partial class PartialClass // PartialClass A
{

    public int PartialProperty { set; get; }

    public string Method1()
    {
        return "Method1() in PartialClassA.cs";
    }

    // Method2() is implemented in PartialClassB...
}
// -------------( PartialClassA.cs )--------------

// -------------( PartialClassB.cs )--------------
public partial class PartialClass // PartialClass B
{

    // Method1() is implemented in PartialClassA...
    
    public string Method2()
    {
        this.PartialProperty = 3;
        return "Method2() in PartialClassB.cs, PartialProperty is "+this.PartialProperty.ToString();
    }

}
// -------------( PartialClassB.cs )--------------

/* Step 3: use the methods */

PartialClass classObj = new PartialClass();
Debug.Log(classObj.Method2());


/* -----------------------------------------
   Normal classes
----------------------------------------- */

// note: a class can be instantiated with the "new" keyword

/* Step 1: create your class file */

// -------------( MyClass.cs )--------------
public class MyClass
{
    // constructor, use the same name as the class, gets called when a Class object has been created
    public MyClass()
    {
        UnityEngine.Debug.Log("Constructor()");
    }

    // destructor gets called when a Class object has been discarded
    ~MyClass()
    {
        UnityEngine.Debug.Log("~Destructor()");
    }

    // a method of this class
    public string Method()
    {
        return "Method in MyClass";
    }
}
// -------------( MyClass.cs )--------------

/* Step 2: use the methods */

MyClass classObj = new MyClass(); // create a new object of MyClass
Console.WriteLine(classObj.Method());


/* -----------------------------------------
   Static classes
----------------------------------------- */

// note: a class marked as static cannot be instantiated with the "new" keyword, provides a performance boost

/* Step 1: create your class file */

// -------------( MyStaticClass.cs )--------------
public static class MyStaticClass
{
    public static string Method()
    {
        return "Method in MyStaticClass";
    }
}
// -------------( MyStaticClass.cs )--------------

/* Step 2: use the methods */

Console.WriteLine(MyStaticClass.Method()); // call a static method from the MyStaticClass, no need for "new" keyword


/* -----------------------------------------
   Sealed classes
----------------------------------------- */

// note: a class marked as sealed cannot be inherited from but can be instantiated with "new" keyword, sometimes it provides a performance boost

/* Step 1: create your class file */

// -------------( MySealedClass.cs )--------------
public sealed class MySealedClass
{
    public string Method()
    {
        return "Method in MySealedClass";
    }
}
// -------------( MySealedClass.cs )--------------

/* Step 2: use the methods */

MySealedClass classObj = new MySealedClass(); // create a new object of MySealedClass
Console.WriteLine(classObj.Method());

