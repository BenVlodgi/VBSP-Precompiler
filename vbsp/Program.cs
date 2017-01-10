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
            //Call precompiler operation to ensure the STEAMID64 directory exists
            var ccEnsureSteamIDDirectoryExists = new Process();
            ccEnsureSteamIDDirectoryExists.StartInfo.FileName = "EnsureSteamIDDirectoryExists.exe";
            ccEnsureSteamIDDirectoryExists.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ccEnsureSteamIDDirectoryExists.Start();
            ccEnsureSteamIDDirectoryExists.WaitForExit();

            //Call alternate compilers
            var ccTagIntermediateCompilerProcess = new Process();
            ccTagIntermediateCompilerProcess.StartInfo.FileName = "PuntIntermediateCompiler.exe";
            ccTagIntermediateCompilerProcess.StartInfo.Arguments = string.Format("\"{0}\"", Environment.GetCommandLineArgs().Last());
            ccTagIntermediateCompilerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ccTagIntermediateCompilerProcess.Start();
            ccTagIntermediateCompilerProcess.WaitForExit();


            //Call standard compiler
            var portal2Process = new Process();
            portal2Process.StartInfo.FileName = "vbsp_original.exe";
            portal2Process.StartInfo.Arguments = Environment.CommandLine.Substring(Environment.CommandLine.IndexOf("exe\"") + 4).Trim();
            portal2Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            portal2Process.Start();
            portal2Process.WaitForExit();
        }
    }
}
