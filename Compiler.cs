
/**
 * Compiler.cs
 * Compiler related snippets for C#
 */

/* using */
using System.Runtime.CompilerServices; // for MethodImpl, MethodImplOptions


/* -----------------------------------------
   Force Inline method (.NET 4+)
----------------------------------------- */

[MethodImpl(MethodImplOptions.AggressiveInlining)]
public int Test(int a, int b) {
	return a + b;
}

