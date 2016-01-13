Information about updates to this document are available at:
[[URL]]http://community.ingres.com/wiki/ProxyGen

Running The Example Code.
-------------------------

1.  Create a new Application in Workbench "Example1".

2.  Add to it three 4GL procedures "Capitalise", "HelloWorld" and "Swap".

3.  Copy the following code to the relevant procedures just created:

[CODE]
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
[CODE]

4.  Add a ghost frame as the entry point of your application.

5.  Click "Tools" > "Make Image".

6.  Tick "Force Compile", "Generate SCPs" and "Generate SCP Metadata".

7.  Save it as Example1.img in "%II_W4GLAPPS_DIR%" directory which by default
    is "%II_SYSTEM%\w4glapps".

8.  Register the image in Visual OpenROAD Server Administrator (VOSA) and test
    the application starts by connecting to it.

9.  Run ProxyGen and load the ConfigJavaExample1.xml file.

10. Click the "Generate" icon or click "Generate" > "Run" from the menu.

11. Open a command shell and CD to the %PROXYGEN%\java\examples\example1
    directory.

12. In the command shell type "build" to compile.

13. In the command shell type "run", you should see the following output

[...]
Called HelloWorld got: "Hello World!"
Called Capitalise with HelloWorld result got: "HELLO WORLD!"
Called Swap with "String 1" and "String 2" got: "String 2" and "String 1"
[...]

If you get an Exception you may be able to find help on the Ingres community
forums or wiki:
[[URL]]http://community.ingres.com/wiki/Main_Page
[[URL]]http://community.ingres.com/forums/



2 April 2008 - Anthony Simpson (Luminary - An Ingres Company).
