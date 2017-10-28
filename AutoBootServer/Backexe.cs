using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace AutoBootServer
{
    class Backexe
    {
        public const string cs = "c#";
        public const string vb = "vb";
        public const string py = "python";

        public static string cscDir = getFromRunE(@"csc.exe");
        public static string vbcDir = getFromRunE(@"vbc.exe");
        public static string pyDir = getPython();
        public static Dictionary<string, string> Compilers = DictionaryG();
        public static string actual = cs; 

        public static Dictionary<string, string> DictionaryG()
        {
            Dictionary<string, string> c = new Dictionary<string, string>();
            c.Add(cs, cscDir);
            c.Add(vb, vbcDir);
            c.Add(py, pyDir);
            return c;
        }

        public static void Analize(string msg)
        {
            if (msg.Equals(cs) || msg.Equals(vb) || msg.Equals(py))
                actual = msg;
            else
                UseCode(msg);
        }

        private static string getFromRunE(string file)
        {
            if (Environment.Is64BitOperatingSystem)
                return RuntimeEnvironment.GetRuntimeDirectory().Replace("Framework", "Framework64") + file;
            else
                return RuntimeEnvironment.GetRuntimeDirectory() + file;
        }

        private static string getPython()
        {
            if (Directory.Exists(@"C:\Python27"))
                return @"C:\Python27\python.exe";
            else
                return "nulldir";
        }

        public static void UseCode(string code)
        {
            if (actual == cs || actual == vb)
                CompileCode(code, Compilers[actual], "autobootsource.exe", "autobootsource.cs", "\"/out:" + Path.GetTempPath() + "autobootsource.exe\" " + Path.GetTempPath() + "autobootsource.cs");
            else if (actual == py)
                CompileCode(code, Compilers[actual], "autobootsource.py");
        }

        public static void CompileCode(string code, string compiler, string name, string prname, string args)
        {
            if (File.Exists(Path.GetTempPath() + name))
                File.Delete(Path.GetTempPath() + name);
            File.WriteAllText(Path.GetTempPath() + prname, code);
            Process.Start(compiler, args);
            Thread.Sleep(2000);
            Process.Start(Path.GetTempPath() + name);
        }

        public static void CompileCode(string code, string compiler, string name)
        {
            File.WriteAllText(Path.GetTempPath() + name, code);
            Process.Start(compiler, Path.GetTempPath() + name);
        }
    }
}
