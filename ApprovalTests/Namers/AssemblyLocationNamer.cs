using System;
using System.Reflection;
using Alphaleonis.Win32.Filesystem;

namespace ApprovalTests.Namers
{
    public class AssemblyLocationNamer : UnitTestFrameworkNamer
    {
        private string AssemblyDirectory
        {
            get
            {
                // CodeBase is used because the NUnit test runner is otherwise quirky
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public override string SourcePath => Path.Combine(AssemblyDirectory, Subdirectory);
    }
}