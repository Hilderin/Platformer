@ECHO OFF

ECHO Copy game files...
XCOPY bin\Release\*.* Build\*.* /S /Y

ECHO Copy game content
XCOPY Content\*.* Build\Content\*.* /S /Y





