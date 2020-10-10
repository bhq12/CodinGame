# CSharpCodinGameCodeCompiler

Issue: The codingame in-browser editor only allows a single "file" of code to be entered, but I want to manage my code with sensible file/directory separation outside of the browser

This is a simple app to compile all C# files in a directory into a single file.

Purpose is to allow development of Codingame projects with separate files while still supporting the ability to copy/paste the project into the Codingame editor.


console app has 2 optional arguments:

1) project directory: this is a string representing the directory you want to extract all .cs files from (app will ignore /bin/ and /obj/)
	- Default: current directory

2) output directory: directory in which to write compiled single file C# code
	- Default: current directory

Output:

A single file called CompiledResult.cs will be produced in the output directory