using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace vbsp
{
    class Program
    {
        static void Main()
        {
            //Call alternate compilers
            var ccTagIntermediateCompilerProcess = new Process();
            ccTagIntermediateCompilerProcess.StartInfo.FileName = "CCTagIntermediateCompiler.exe";
            ccTagIntermediateCompilerProcess.StartInfo.Arguments = Environment.GetCommandLineArgs().Last() + ".vmf";
            ccTagIntermediateCompilerProcess.Start();
            ccTagIntermediateCompilerProcess.WaitForExit();


            //Call standard compiler
            var portal2Process = new Process();
            portal2Process.StartInfo.FileName = "vbsp_original.exe";
            portal2Process.StartInfo.Arguments = Environment.CommandLine.Substring(Environment.CommandLine.IndexOf("exe\"") + 4).Trim();
            portal2Process.Start();
            portal2Process.WaitForExit();
        }
    }
}
