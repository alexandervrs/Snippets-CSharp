
/**
 * Compiler.cs
 * Compiler related snippets for C#
 */

/* using */
using System.Runtime.CompilerServices; // for MethodImpl, MethodImplOptions


/* -----------------------------------------
   Force Inline method (.NET 4.5+)
----------------------------------------- */

// suggest to the Compiler that it should inline the following method

[MethodImpl(MethodImplOptions.AggressiveInlining)]
public int Test(int a, int b) {
	return a + b;
}


/* -----------------------------------------
   Conditional Compilation
----------------------------------------- */

#if NET46
// this code compiles and executes when NET46 is defined
#elif NET_STANDARD2_0
// this code compiles and executes when NET_STANDARD2_0 is defined
#else
// this code compiles and executes when NET46 nor NET_STANDARD2_0 are defined
#endif

/*

.NET Framework	        NETFRAMEWORK, NET48, NET472, NET471, NET47, NET462, NET461, NET46, NET452, NET451, NET45, NET40, NET35, NET20
.NET Standard	        NETSTANDARD, NETSTANDARD2_1, NETSTANDARD2_0, NETSTANDARD1_6, NETSTANDARD1_5, NETSTANDARD1_4, NETSTANDARD1_3, NETSTANDARD1_2, NETSTANDARD1_1, NETSTANDARD1_0
.NET 5 (and .NET Core)	NET, NET5_0, NETCOREAPP, NETCOREAPP3_1, NETCOREAPP3_0, NETCOREAPP2_2, NETCOREAPP2_1, NETCOREAPP2_0, NETCOREAPP1_1, NETCOREAPP1_0

*/


/* -----------------------------------------
   Custom define values
----------------------------------------- */

/*

    Define values at the top of the file using #define and the value you want
    e.g. 
        #define DEBUG
    
    then throughout the script you can use:

*/

#if DEBUG
// this code compiles and executes when DEBUG is defined
#else
// this code compiles and executes when DEBUG is not defined
#endif

