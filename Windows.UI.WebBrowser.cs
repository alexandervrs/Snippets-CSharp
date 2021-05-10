
/**
 * Windows.UI.WebBrowser.cs
 * WebBrowser related snippets for C#
 */

using System; // for Uri
using System.Windows.Forms; // (Windows-Only) for Control, Form
using System.Drawing; // for Point, Size


// note: 
//       WebBrowser is using Internet Explorer on Windows to display webpages
//       for a better browser engine, you can consider some other library like CefSharp

/* -----------------------------------------
   Create a Web Browser
----------------------------------------- */
/// Class Body
WebBrowser webbrowser1;

/// Form Constructor:
webbrowser1          = new WebBrowser();
webbrowser1.Location = new Point(0, 0);
webbrowser1.Size     = new Size(1280, 720);

webbrowser1.Url      = new Uri("http://example.com");

form1.Controls.Add(webbrowser1);


/* -----------------------------------------
   Events
----------------------------------------- */
webbrowser1.Navigating += new WebBrowserNavigatingEventHandler(delegate(object sender, WebBrowserNavigatingEventArgs e) // On Navigating
{
	Console.WriteLine("Navigating...");
});

webbrowser1.Navigated += new WebBrowserNavigatedEventHandler(delegate(object sender, WebBrowserNavigatedEventArgs e) // On Navigated
{
	Console.WriteLine("Reached URL");
});

webbrowser1.NewWindow += new CancelEventHandler(delegate(object sender, CancelEventArgs e) // On New Window Popup
{
	Console.WriteLine("New Window Open");
});

webbrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(delegate(object sender, WebBrowserProgressChangedEventArgs e) // On Download Progress
{
	Console.WriteLine("Progress... "+e.CurrentProgress+" bytes");
});


/* -----------------------------------------
   Methods
----------------------------------------- */
// navigate to another page
webbrowser1.Url = new Uri("http://test.com");

// go back a page
webbrowser1.GoBack();

// go forward a page
webbrowser1.GoForward();

// stop a pending navigation
webbrowser1.Stop();

// reload the page
webbrowser1.Refresh();

