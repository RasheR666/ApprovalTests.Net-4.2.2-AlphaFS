using System.Text;
using Alphaleonis.Win32.Filesystem;

namespace ApprovalUtilities.Utilities
{
    public class FileUtilities
    {
        public static void EnsureFileExists(string file)
        {
            if (!File.Exists(file))
            {
                File.WriteAllText(file, " ", Encoding.UTF8);
            }
        }

        public static void EnsureFileExistsAndMatchesEncoding(string file, string matchEncodingFrom)
        {
            if (!File.Exists(file))
            {
                File.WriteAllText(file, " ", GetEncodingFor(matchEncodingFrom));
            }
        }

        public static Encoding GetEncodingFor(string file)
        {
            using (var fs = File.Open(file, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var sr = new System.IO.StreamReader(fs, true))
                {
                    for (var i = 0; i < 4 && sr.Peek() >= 0; i++)
                    {
                        sr.Read();
                    }

                    return sr.CurrentEncoding;
                }
            }
        }
    }
}