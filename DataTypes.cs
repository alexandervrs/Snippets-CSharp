
/**
 * DataTypes.cs
 * DataType related snippets for C#
 */

/* using */
using System; // for Console, Array, CompareTo
using System.Collections.Generic; // for List, Dictionary, KeyValuePair


/* -----------------------------------------
   1D Arrays
----------------------------------------- */
// create an 1D array
string[] myarray1d = new string[2];             // creates string array of length 2, default values
string[] myarray1d = new string[] { "A", "B" }; // OR creates populated string array of length 2
string[] myarray1d = { "A" , "B" };             // OR creates populated string array of length 2
string[] myarray1d = new[] { "A", "B" };        // OR created populated string array of length 2

// get 1D array dimension/length
int length = myarray1d.Length;

// set and get values from 1D array
myarray1d[1] = 6; // set the 2nd array item to value of 6
string s = myarray1d[1]; // get the 2nd item in the array

// convert array 1D to List
List<string> mylist = new List<string>(myarray1d);

// iterate through the items of a 1D array
for (int i = 0; i < myarray1d.Length; i++) {
	Console.WriteLine(myarray1d[i]);
}

// copy an array to another one
string[] myarray1dCopy = new string[2];
Array.Copy(myarray1d, myarray1dCopy, myarray1d.Length);

// clear an array
Array.Clear(myarray1d, 0, myarray1d.Length);

// sort an array
Array.Sort(myarray1d);

// resize an array
Array.Sort(myarray1d, 10); // 10 is the new size


/* -----------------------------------------
   2D Arrays
----------------------------------------- */
// create a 2D array
int[,] myarray2d = new int[3, 2]; // creates 2D array of height 3 and width 2

// set and get values from 2D array
myarray2d[1, 2] = 6; // set at [y, x]
int s = myarray2d[1, 2]; // get at [y, x]

// get 2D array dimensions
int width  = myarray2d.GetLength(1); // get width
int height = myarray2d.GetLength(0); // get height

// iterate through the items of a 2D array
int rowCount = myarray2d.GetLength(0);
int colCount = myarray2d.GetLength(1);

string output = "";

for (int row = 0; row < rowCount; row++) {

	for (int col = 0; col < colCount; col++) {           
		
		if (myarray2d[row, col] != null) {
			output += (myarray2d[row, col]).ToString()+" | ";
		} else {
			output += "<null> | ";
		}
		
	}
	output+="\n";
}

Console.WriteLine(output);

// resize a 2D array
int[,] myarray2d = new int[6, 3]; 

int rows    = 2; // resize to height: 2
int columns = 2; // resize to width: 2

int[,] newArray = new int[rows, columns];

int rowCount = Math.Min(rows,    myarray2d.GetLength(0));
int colCount = Math.Min(columns, myarray2d.GetLength(1));

for (int row = 0; row < rowCount; row++) {

	for (int col = 0; col < colCount; col++) {            
	
		if (myarray2d[row, col] != null) {
			newArray[row, col] = myarray2d[row, col];
		}
		
	}
}

myarray2d = newArray;
newArray = null;

Console.WriteLine(myarray2d.GetLength(1)+" x "+myarray2d.GetLength(0));


/* -----------------------------------------
   Enumerators
----------------------------------------- */
// create an enum
enum TestCollection : int {
	Test1 = 1,
	Test2 = 2,
	Test3 = 3,
}

// get value from enum
if (testValue == (int) TestCollection.Test1) {

	// testValue is equal to enum TestCollection.Test1 ...

}


// create an "enum" that holds string values using a static class
static class TestCollection2
{
    public const string Test1 = "One";
	public const string Test2 = "Two";
	public const string Test3 = "Three";
}

// get value from "enum"
if (testValue == TestCollection2.Test1) {

	// testValue is equal to enum TestCollection2.Test1 ...

}


/* -----------------------------------------
   Strings
----------------------------------------- */
// create a string
string mytext = "Test";

// check if string equals a value into a boolean
string mytext = "1";
bool isTrue = mytext.Equals("1");

// parse a string into a number so you can use it in calculations
float myNumberFloat = float.Parse("13.75");
int myNumberInt = int.Parse("13");

// convert a number into a string, so you can use it in string operations
float myNumberFloat = 33.45; // float, int etc. ...
string mytext = myNumberFloat.ToString(); // mytext now has "33.45" as text


/* -----------------------------------------
   Lists
----------------------------------------- */
// create a list
List<int> mylist = new List<int>(); // create list accepting int values
List<int> mylist = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // create list accepting int values with 9 default items

// get length of list
int items = mylist.Count;

// append an item to list with value 5
mylist.Add(5);

// set/get list item value
mylist[2] = "Test2"; // set the 2nd item value
int itemVal = mylist[2]; // get the 2nd item value

// removes the 2nd item
mylist.Remove(2);

// removes all items
mylist.Clear();

// invert the list items
mylist.Reverse();

// sort a list ascending
mylist.Sort((a, b) => a.CompareTo(b));

// sort a list descending
mylist.Sort((a, b) => -1* a.CompareTo(b));

// iterate through a list
foreach (int listItem in mylist) {
	Console.WriteLine(listItem);
}

// convert to 1D array
mylist.ToArray();


/* -----------------------------------------
   Dictionary
----------------------------------------- */
// create a dictionary (collection with key:value pairs)
Dictionary<int, string> mymap = new Dictionary<int, string>(); // create a new dictionary with items that have (key: int, value: string)

// add key/value to dictionary
mymap.Add(2, "Test");  // 2:"Test"

// set/get key to value
mymap[2] = "Test2"; // set the key that equals 2
string keyval = mymap[2]; // get the value from the key that equals 2

// remove dictionary item by key (2)
mymap.Remove(2);

// clear all items from dictionary
mymap.Clear();

// get length of dictionary
int items = mymap.Count;

// get value from key if exists
string valueFromKey = null;
if (mymap.TryGetValue(2, out valueFromKey)) { // try to get value from key
	Console.WriteLine(valueFromKey);
}

// iterate through a dictionary (grab both key/value)
foreach(KeyValuePair<int, string> entry in mymap) {
   Console.WriteLine("Key: "+entry.Key+", Value: "+entry.Value);
}

// iterate through a dictionary (grab only keys)
foreach(int entry in mymap.Keys) {
	Console.WriteLine(entry);
}

// iterate through a dictionary (grab only values)
foreach(string entry in mymap.Values) {
	Console.WriteLine(entry);
}


/* -----------------------------------------
   Struct
----------------------------------------- */
// create a struct to determine a custom data structure
public struct Point
{
    public readonly float X;
    public readonly float Y;

	public Point(float x, float y) {
		X = x;
		Y = y;
	}

    public override string ToString() => $"({X}, {Y})";
}

// usage:
Point pnt = new Point(32, 32);
Console.WriteLine( pnt.X+" | "+pnt.Y );
Console.WriteLine(pnt.ToString());

