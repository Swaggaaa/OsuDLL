set EnableNuGetPackageRestore=true
set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %MSBuildDir%\msbuild ClassLibrary2.sln /p:Configuration=Release /p:OutDir=.\bin\Release

CALL packages\Obfuscar.2.2.0\tools\Obfuscar.Console.exe obfuscar.xml