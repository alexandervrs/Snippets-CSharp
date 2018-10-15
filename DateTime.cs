
/**
 * DateTime.cs
 * DateTime related snippets for C#
 */

/* using */
using System; // for DateTime
using System.Globalization; // for CultureInfo


/* -----------------------------------------
   Create DateTime Object
----------------------------------------- */
// parse string as datetime object
DateTime MyDateTime = DateTime.Parse("3 Jun 2019 14:12:40", CultureInfo.InvariantCulture);

// create datetime object from current datetime
DateTime MyDateTime = DateTime.Now;


/* -----------------------------------------
   Get Data from DateTime Object
----------------------------------------- */
DateTime MyDateTime = DateTime.Now;
int year   = MyDateTime.Year;
int month  = MyDateTime.Month;
int day    = MyDateTime.Day;
int hour   = MyDateTime.Hour;
int minute = MyDateTime.Minute;
int second = MyDateTime.Second;
int ms     = MyDateTime.Millisecond;


/* -----------------------------------------
   Parse DateTime
----------------------------------------- */
// parse current datetime as string with the following format
string dateNow = DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss");

