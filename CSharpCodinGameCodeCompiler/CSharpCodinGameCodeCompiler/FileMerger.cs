using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpCodinGameCodeCompiler
{
    public class FileMerger
    {
        public string ProjectPath { get; set; }
        public string OutputFile { get; set; }

        public FileMerger(string projectPath, string outputFile) {
            ProjectPath = projectPath;
            OutputFile = outputFile;
        }

        public void Compile() {

            //get all c# files in directory
            var classFiles = Directory.GetFiles(ProjectPath, "*.cs", SearchOption.AllDirectories);

            //filter out auto generated files in /bin/ and /obj/ directories
            var filteredClassFiles = classFiles.Where(fileName => !fileName.Contains("\\bin\\") && !fileName.Contains("\\obj\\"));
            
            //split all c# files into lines
            var fileTextLines = filteredClassFiles.SelectMany(a => File.ReadAllText(a).Split(Environment.NewLine));

            //regex for "using" package import statements to filter to top of single merged file
            var usingLineRegex = new Regex(@"\s*using\s+.*;\s*"); ;

            //get all using statements
            var usingStatements = fileTextLines.Where(line => usingLineRegex.IsMatch(line)).Distinct();

            //get all code (i.e everything not a "using" statement)
            var codeLines = fileTextLines.Where(line => !usingLineRegex.IsMatch(line));

            //created merged file with using statements followed by code
            var mergedCode = string.Join("\n", usingStatements) + "\n" + string.Join("\n", codeLines);

            //Write result to output file
            File.WriteAllText(OutputFile, mergedCode);
        }
    }
}
