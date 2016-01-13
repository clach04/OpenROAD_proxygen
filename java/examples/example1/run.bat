@echo off
cd bin
java -Djava.library.path="%II_SYSTEM%\ingres\bin" -classpath ".;%II_SYSTEM%\ingres\orjava\openroad.jar;%PROXYGEN%\java\library" ExampleOne
cd ..
