The latest version of this document is available at:
[[URL]]http://community.ingres.com/wiki/ProxyGenReadMe

Introduction.
-------------

ProxyGen is a code generation tool for generating proxies to classes, methods
and procedures exposed by the OpenROAD Server.

The concept behind ProxyGen is that it can take the metadata about an OpenROAD
Application Server Application (ASA) and turn that into proxy objects which
are native classes using templates designed for a specific language.

ProxyGen is appropriate for generating code for both Java, C# and other
languages.

ProxyGen has already been used on large commercial projects to significantly
reduce development time.

ProxyGen features:
    * It greatly reduces the need to hand crank calls to OpenROAD server
        applications by wrapping the low level drivers with easy to use
        application-specific classes.

    * It allows you to call OpenROAD procedures and methods in a consistent and
        object orientated way.

    * It generates code which complies with language and project coding
        standards.

    * It easily regenerates your proxies if your OpenROAD application or
        requirements change.

    * It directly reads metadata from your OpenROAD application or from disk.

    * It has a simple and easy to use GUI and XML configuration file.

    * It can run in batch mode as part of a build.

    * And much more, such as renameing classes, attributes, parameters, etc...


Requirements.
-------------

Both Ingres 2006 and OpenROAD 2006 will need to be installed.
To use the Java templates you will need Java 5 or above.


Installation.
-------------

Copy the contents of the release to a directory.
You will have to create a new enviroment variable %PROXYGEN% set to this
directory.


Files.
------

| proxygen.bat                  - Start ProxyGen.
| ProxyGen.img                  - ProxyGen OpenROAD image.
| README.TXT                    - This file.
+ java
|   | jproxy1.tpl               - Default Java Template file for Classes.
|   | jproxy2.tpl               - Default Java Template file for Server Call
|   |                             Procedures SCPs.
|   | ConfigJavaDefault.xml     - Default Java ProxyGen configuration.
|   + library                   - Source for the Java code used in the
|                                 templates.
|   + examples
|   |   + example1              - Basic example using the Java templates.
|   |   + example2              - Generating proxies for Meeting Point.


Getting Started.
----------------

ProxyGen is started by clicking the proxygen.bat icon in explorer or by running
it from a command prompt.

You may want to do the example in java\examples\example1 for a brief tutorial.

Notes.
------

This release only contains example template files for Java, C# templates
will be released shortly.


Tips.
-----

It is advisable to make a copy of the default templates or configuration files
before  applying any changes. In this way it is possible to revert back to the
default settings at any time.

The "Edit Template" view can be a useful debugging tool for your templates
showing what blocks of code will be written to generated files. Select a
template from the "Template Jobs:" table and click the table control (top right
 of table) then "Edit Template...".

Check [[URL]]http://community.ingres.com/wiki/ProxyGen for updates and news on
ProxyGen.


Known Issues.
-------------

Template files must have at least one empty line at the top of the file.

The Java template file is a simple foundation template. Further templates will
be made available.

The template editor is a 'work-in-progress' and so should only be used to view
existing templates and not for template creation.




3 April 2008 - Anthony Simpson (Luminary - An Ingres Company).
