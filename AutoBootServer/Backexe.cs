using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AutoBootServer
{
    class Backexe
    {
        public static string cscDir = getCSC();

        private static string getCSC()
        {
            if (Environment.Is64BitOperatingSystem)
                return System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory().Replace("Framework", "Framework64") + @"csc.exe";
            else
                return System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory() + @"csc.exe";
        }

        public static void CompileCode(string code)
        {
            if (File.Exists(Path.GetTempPath() + "autobootsource.exe"))
                File.Delete(Path.GetTempPath() + "autobootsource.exe");
            File.WriteAllText(Path.GetTempPath() + "autobootsource.cs", code);
            Process.Start(cscDir,"\"/out:" + Path.GetTempPath() + "autobootsource.exe\" " + Path.GetTempPath() + "autobootsource.cs");
            Thread.Sleep(2000);
            Process.Start(Path.GetTempPath() + "autobootsource.exe");
        }
    }
}
