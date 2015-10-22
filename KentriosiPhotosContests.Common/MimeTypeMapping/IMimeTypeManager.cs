namespace KentriosiPhotosContests.Common
{
    using System.Collections.Generic;

    public interface IMimeTypeManager
    {
        string GetMimeType(string extension);

        bool IsFileTypeAllowed(string extension, IEnumerable<string> allowedMimeTypes);
    }
}
