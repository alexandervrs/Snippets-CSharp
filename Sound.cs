
/**
 * Sound.cs
 * SoundPlayer related snippets for C#
 */

using System;
using System.Media;


// note: 
//       Sound Player is a very simple way to quickly play sounds on Windows C# programs
//       but it's not very feature rich. It's best to use a better library like libvlcsharp, SharpDX, SlimDX, FMod

/* -----------------------------------------
   Play Sound
----------------------------------------- */
/// Class Body:
SoundPlayer player;

/// MyMethod():
SoundPlayer player = new SoundPlayer("sample.wav");

player.LoadCompleted += new AsyncCompletedEventHandler(delegate(object sender, AsyncCompletedEventArgs e) // On Load Complete
{
	Console.WriteLine("Loading Complete!");

	// play the sound
	player.Play();

	// OR play the sound looping
	//player.PlayLooping();

});


/* -----------------------------------------
   Methods
----------------------------------------- */

// play the sound looping
player.PlayLooping();

// play the sound synchronously by first loading it then play
player.PlaySync();

// stops playback of the sound
player.Stop();

// unload a sound resource
player.Dispose();
