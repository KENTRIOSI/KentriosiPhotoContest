namespace KentriosiPhotosContests.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDropboxRepository
    {
        string Upload(int imageId, string fileName, Stream fileStream);

        string Download(string path);
    }
}
