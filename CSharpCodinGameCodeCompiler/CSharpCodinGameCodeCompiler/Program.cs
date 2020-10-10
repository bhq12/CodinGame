using System;
using System.IO;

namespace CSharpCodinGameCodeCompiler
{
    class Program
    {
        static void Main(string[] args) {

            var solutionDirectory = Directory.GetCurrentDirectory();

            if (args.Length > 0) {
                solutionDirectory = args[0];
            }

            Console.WriteLine("Compiling C# project at: " + solutionDirectory);

            var outputDirectory = Directory.GetCurrentDirectory();
            if (args.Length > 1) {
                outputDirectory = args[1];
            }

            Console.WriteLine("\n\nOutputing code to: " + outputDirectory);

            var compiledFileLocation =  outputDirectory + @"\CompiledResult.cs";
           
            var fileMerger = new FileMerger(solutionDirectory, compiledFileLocation);

            Console.WriteLine("\n\nMerging solution files to: " + compiledFileLocation);

            fileMerger.Compile();

            Console.WriteLine("\n\nCompleted!");
        }
    }
}
