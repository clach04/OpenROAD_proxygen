Java Example 1
==============

Running The Example Code.
-------------------------

1.  Open OpenROAD Workbench Classic.
2.  Create a new Application in Workbench "Example1".
3.  Add to it three 4GL procedures "Capitalise", "HelloWorld"
    and "Swap".
4.  Make sure "Generate SCP" is selected and the SCP name is the same as
    the procedure name prefixed with "SCP\_"
5.  Copy the following code to the relevant procedures just created:

        PROCEDURE Capitalise
        (
            b_v_test = VARCHAR(50) NOT NULL WITH DEFAULT,
        ) =
        DECLARE
        ENDDECLARE
        BEGIN
            b_v_test = UPPER(b_v_test);
            CurProcedure.Trace('**** Capitalise called ****');
        END

        PROCEDURE HelloWorld
        (
            b_v_test = VARCHAR(14) NOT NULL WITH DEFAULT,
        ) =
        DECLARE
        ENDDECLARE
        BEGIN
            b_v_test = 'Hello World!';
            CurProcedure.Trace('**** HelloWorld called ****');
        END

        PROCEDURE Swap
        (
            b_v_test1 = VARCHAR(50) NOT NULL WITH DEFAULT,
            b_v_test2 = VARCHAR(50) NOT NULL WITH DEFAULT,
        ) =
        DECLARE
            v_temp    = VARCHAR(50) NOT NULL WITH DEFAULT,
        ENDDECLARE
        BEGIN
            v_temp    = b_v_test1;
            b_v_test1 = b_v_test2;
            b_v_test2 = v_temp;
            CurProcedure.Trace('**** Swap called ****');
        END

6.  Add a ghost frame as the entry point of your application.
    1.  Click "File" &gt; "New" &gt; "Ghost Frame".
    2.  Name it "Example1" and click "Create".
    3.  Click "View" &gt; "Application Properties".
    4.  Click the button next to "Starting Component" and select
        "Example1" from the list click "OK".
    5.  Click "Apply" , then "Close".

7.  Click "Tools" &gt; "Make Image".
8.  Tick "Force Compilation", "Generate SCPs" and "Generate
    SCP Metadata".
9.  Export it as Example1.img to "%II\_W4GLAPPS\_DIR%" directory which
    by defaul is "%II\_SYSTEM%\\w4glapps".
10. Run Visual OpenROAD Server Administrator (VOSA) and register
    the image.
    1.  In the tree expand your computer and then Local.
    2.  Click "Edit" &gt; "Register".
    3.  In the right pane hange "Name" to Example1 and "Image"
        to Example1.img.
    4.  Click "File" &gt; "Save".

11. Run ProxyGen and load the ConfigJavaExample1.xml file.
12. Click the "Generate" icon or click "Generate" &gt; "Run" from
    the menu.
13. Open a command shell and change directory to the Java
    example1 directory.
14. In the command shell run "build.bat" by typing "build".
15. In the command shell type "run", you should see the following output

        Called HelloWorld got: "Hello World!"
        Called Capitalise with HelloWorld result got: "HELLO WORLD!"
        Called Swap with "String 1" and "String 2" got: "String 2" and "String 1"

If you get an Exception you may be able to find help on the Ingres
community forums or wiki:\
 <http://community.ingres.com/wiki/Main_Page>\
 <http://community.ingres.com/forums/>\

