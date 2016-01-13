C# Example 1
============

Running The Example Code.
-------------------------

1.  Follow Java example1 steps 1 to 10 if you have not done so already.
2.  Run ProxyGen and load the ConfigCSharpExample1.xml file.
3.  Click the "Generate" icon or click "Generate" &gt; "Run" from
    the menu.
4.  Open Visual Studio 2005 and click "File" &gt; "New" &gt; "Project
    From Existing Code..."
5.  Select "Visual C#" from the drop down. Click Next.
6.  Select the C# Example1 directory as the code location and call the
    project Example1. The project type should default to
    Console Application. Click Finish.
7.  Delete the following files CreateASOSessionSCPW.cs,
    DefineBPMSCPW.cs, DestroyASOSessionSCPW.cs and PingSCPW.cs as they
    are not required.
8.  Right click on your solution and click "Add" &gt; "Existing
    Project...", select the C# ProxyGen library project (it is located
    in the "library" directory under the "csharp" directory) and add a
    reference to it from your Example1 project.
9.  Add a reference to the COM library "OpenROAD Remote Server Type
    Library 1.0" to the Example1 project.
10. Run the Example1 project. Your should get the following output:

        Called SCP_HelloWorld got: "Hello World!"
        Called SCP_Capitalise with SCP_HelloWorld result got: "HELLO WORLD!"
        Called SCP_Swap with "String 1" and "String 2" got: "String 2" and "String 1"
        Press Enter To Continue...

If you get an Exception you may be able to find help on the Ingres
community forums or wiki:\
 <http://community.ingres.com/wiki/Main_Page>\
 <http://community.ingres.com/forums/>\

