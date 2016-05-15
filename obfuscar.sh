#!/bin/sh
if ! [ -f "./nuget.exe" ]; then
	wget "https://www.nuget.org/nuget.exe"
fi
mono "nuget.exe" "restore" "ClassLibrary2.sln"
xbuild "ClassLibrary2.sln" "/p:Configuration=Release" "/p:OutDir=.\\bin\\Release\\"

mono ".\\packages\\Obfuscar.2.2.0\\tools\\Obfuscar.Console.exe" "obfuscar_linux.xml"