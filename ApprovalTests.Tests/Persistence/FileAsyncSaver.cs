using System.Threading.Tasks;
using Alphaleonis.Win32.Filesystem;
using ApprovalUtilities.Persistence;

namespace ApprovalTests.Tests.Persistence
{
    public class FileAsyncSaver : ISaverAsync<string>
    {
        private readonly FileInfo file;

        public FileAsyncSaver(FileInfo file)
        {
            this.file = file;
        }


        public async Task<string> Save(string objectToBeSaved)
        {
            using (var fileStream = file.OpenWrite())
            {
                using (var writer = new System.IO.StreamWriter(fileStream))
                {
                    await writer.WriteAsync(objectToBeSaved);
                    return objectToBeSaved;
                }
            }
        }
    }
}