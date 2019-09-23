using Alphaleonis.Win32.Filesystem;
using ApprovalTests.Reporters.TestFrameworks;

namespace ApprovalTests.Tests.Reporters
{
    public class NUnitReporterWithCleanup : NUnitReporter
    {
        public override void Report(string approved, string received)
        {
            try
            {
                base.Report(approved, received);
            }
            finally
            {
                File.Delete(received);
            }
        }
    }
}