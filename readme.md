ProxyGen
========

Introduction
------------

ProxyGen is a code generation tool for generating proxies to classes,
methods and procedures exposed by the OpenROAD Server.

The concept behind ProxyGen is that it can take the metadata describing
an OpenROAD Application Server Application (ASA) and turn that into
proxy classes using templates designed for a specific language.

ProxyGen is appropriate for generating code for Java, C\# and other
languages.

ProxyGen has already been used on large commercial projects to
significantly reduce development time.

### ProxyGen features

-   It greatly reduces the need to hand crank calls to OpenROAD
    applications by wrapping the low level drivers with easy-to-use
    application-specific classes.
-   It makes calls to OpenROAD procedures and methods in a consistent
    and object oriented way.
-   It generates code which complies with language and project
    coding standards.
-   It easily regenerates your proxies if your OpenROAD application or
    requirements change.
-   It directly reads metadata from your OpenROAD Application Server or
    from disk.
-   It has a simple and easy to use GUI and XML configuration file.
-   It can run in batch mode as part of a build (see Tips).
-   And much more, such as renameing classes, attributes, parameters via
    configuration files.

Requirements
------------

Both Ingres and OpenROAD (6.2) will need to be installed.
To use the Java templates you will need Java 5 or above.

Getting Started
---------------

Sequence of steps:

  * import code
  * build code
  * run image

### Windows example

    createdb proxygen
    cd src
    w4gldev backupapp in proxygen ProxyGen ProxyGen.xml -nREPLACE
    cd ..
    w4gldev makeimage proxygen ProxyGen ProxyGen.img
    set PROXYGEN=%CD%
    proxygen.bat


You may want to study the examples found by following the links below
for a brief tutorial and demonstration of some of ProxyGen's
capabilities.

  * [Java Example 1](java/examples/example1/index.html)
  * [C\# Example 1](csharp/examples/example1/index.html)

Tips
----

It is advisable to make a copy of the default templates or configuration
files before applying any changes. In this way it is possible to revert
back to the default settings at any time.

The "Edit Template" view can be a useful debugging tool for your
templates showing what blocks of code will be written to generated
files. Select a template from the "Template Jobs:" table and click the
table control (top right of table) then "Edit Template...".

ProxyGen can be run in batch mode by using the
`-/appflags jobfile=\[location of config XML file\]`
switch at the command line.
Running proxygen.bat simplifies this by taking an optional single
argument which will be used as a jobfile.

Known Issues
------------

Template files must have at least one empty line at the top of the file.

The Java template file is a simple foundation template. Further
templates will be made available.

The template editor is a work-in-progress and so should only be used to
view existing templates and not for template creation.

In batch mode the current working directory is not set to the location
of the config file as it is when using the GUI. For this reason relative
paths in your config file may not be correct. To avoid this either use
only absolute paths or run proxygen.bat from the same directory as your
config file.

History
-------

Version 1.0 release 1

Initial Open Source release with Java templates and examples.

Version 1.0 release 2

Simplified Installer process. Added C\# templates and example.
Documentation converted to HTML.
