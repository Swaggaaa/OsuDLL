set EnableNuGetPackageRestore=true
set msBuildDir="C:\Program Files (x86)\MSBuild\14.0\Bin"
call %MSBuildDir%\msbuild ClassLibrary2.sln /p:Configuration=Release /p:OutDir=.\bin\Release

CALL packages\Obfuscar.2.2.0\tools\Obfuscar.Console.exe obfuscar.xml