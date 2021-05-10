
/**
 * String.cs
 * String related snippets for C#
 */

/* using */
using System; // for Convert, Guid, Random
using System.Text; // for String, Encoding
using System.Text.RegularExpressions; // for Regex
using System.Collections.Generic; // for List


/* -----------------------------------------
   Text operations
----------------------------------------- */
// create a new string
string textString = "Testing,123";

// create a new string array
string[] textArray = new string[] {"Text1", "Text2", "Text3"};

// create a new string list
List<string> textList = new List<string>(){"TextA", "TextB", "TextC"};

// interpolate strings with $, string interpolation does not create new string objects like "firstString"+","+"secondString" would do
string firstString = "first"; string secondString = "second";
string mergedString = $"{firstString}, {secondString}";

// keep substring text between start position (1) and last position (3)
string textPart = textString.Substring(1, 3); // returns "est"

// returns character from string at position (4) as a string
textString[4].ToString();

// repeat a string (12) times
string.Join(textString, new string[12 + 1]);

// mask a string with a character (*)
string maskedString = string.Join("*", new string[textString.Length + 1]);

// reverse a string
char[] inArray = textString.ToCharArray();
Array.Reverse(inArray);
string reversedString = new string(inArray);

// shuffle a string's characters
char[] inArray = textString.ToCharArray();
Random rng     = new Random();
int    n       = inArray.Length;
while (n > 1) {
	n--;
	int k = rng.Next(n + 1);
	var value  = inArray[k];
	inArray[k] = inArray[n];
	inArray[n] = value;
}
string shuffledString = new string(inArray);

// join a string array together with a delimiter ","
string joinedText = string.Join(",", textArray);

// join a string list together with a delimiter ","
string joinedText = string.Join(",", textArray.ToArray());

// split a string to a string array at a delimiter ","
string[] stringParts = textString.Split(",".ToCharArray()); // returns [Testing, 123]

// replace all occurences in a string
string replacedString = Regex.Replace(textString, "Testing", "replaced"); // text, replaceThis, replaceWith | returns "replaced,123"

// check if string starts with substring "T"
bool startsWith = textString.StartsWith("T"); // true

// check if string ends with substring "T"
bool endsWith = textString.EndsWith("w"); // false

// trim string left using characterSet (checks and removes T from the left side)
string characterSet = "T";
string trimmedString = Regex.Replace(textString, "^"+characterSet+"+", "");

// trim string right using characterSet (checks and removes 3 from the right side)
string characterSet = "3";
string trimmedString = Regex.Replace(textString, ""+characterSet+"+$", "");

// trim string using characterSet (checks and removes T from both sides)
string characterSet = "T";
string trimmedString = Regex.Replace(textString, "^"+characterSet+"+|"+characterSet+"+$", "");

// convert text to uppercase
textString.ToUpper();

// convert text to lowercase
textString.ToLower();

// returns a string containing the character with the given Unicode code (Chr())
int code = 84;
string character = (Convert.ToChar( code )).ToString(); // returns "T"

// returns the Unicode value code of the first character in the given string (Ord())
string outString = ((int)textString[0]).ToString();
int code = System.Convert.ToInt32(outString); // code will be 84 since "T" is the first letter in text

// generate a new UUIDv4
string uuid = Guid.NewGuid().ToString();

// decode from base64 string
byte[] data = Convert.FromBase64String("VGVzdGluZywxMjM=");
string decodedString = Encoding.UTF8.GetString(data); // returns "Testing,123"

// encode to a base64 string
byte[] data = Encoding.UTF8.GetBytes(textString);
return Convert.ToBase64String(data).ToString(); // returns "VGVzdGluZywxMjM="

