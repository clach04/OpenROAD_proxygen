#region Code Header
/*
 * Copyright Luminary Solutions Limited
 *
 */

/*
* Description : Part of a simple example which uses generated code from ProxyGen
*               to connect to and call an OpenROAD application exposed by the
*               OpenROAD Application Server.
*
* Class : Code in te main method uses the generated facade and makes calls to
*         SCPs, the results of which are printed to the console (See HTML
*         Document).
*
* Class Name : Example1
*
* System Name : Example1
*
* Sub-System Name : Example
*
* File Name : Example1.cs
*
* Version History
*
* Version Date       Who Description
* ------- ---------- --- --------------
* 1.0     01/05/2008 ags Original Version
*/
#endregion

#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Text;
using Luminary.ProxyGen.Util;
using Luminary.ProxyGen.Examples.Example1.ApplicationServices.Facades;
#endregion

namespace Examples
{
    /// <summary>
    /// A simple example of using ProxyGen's generated code to talk to an OpenROAD
    /// application.
    /// </summary>
    class Example1
    {
        /// <summary>
        /// Program entry point. Expect no arguments (but doesn't check). Will connect to
        /// an OpenRoad Example appliction, call some methods and print the results then
        /// exit (See HTML Document).
        /// </summary>
        public static void Main()
        {
            //Connect to the Application server through the generated facade
            Example1Facade facade = new Example1Facade("Example1", null, null, null, ConnectionTypes.ASO);
            string test1 = "";
            string test2 = "String 1";
            string test3 = "String 2";

            facade.SCP_HelloWorld(ref test1);
            Console.WriteLine("Called SCP_HelloWorld got: \"{0}\"", test1);

            facade.SCP_Capitalise(ref test1);
            Console.WriteLine("Called SCP_Capitalise with SCP_HelloWorld result got: \"{0}\"", test1);

            facade.SCP_Swap(ref test2,ref test3);
            Console.WriteLine("Called SCP_Swap with \"String 1\" and \"String 2\" got: \"{0}\" and \"{1}\"",
                test2, test3);

            //Wait for user to continue
            Console.WriteLine("Press Enter To Continue...");
            Console.ReadLine();
        }
    }
}
