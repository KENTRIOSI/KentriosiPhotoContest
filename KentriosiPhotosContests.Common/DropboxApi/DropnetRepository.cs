namespace KentriosiPhotosContests.Common
{
    using System.IO;
    using DropNet;

    public class DropnetRepository : IDropboxRepository
    {
        private DropNetClient client;

        public DropnetRepository(string appKey, string appSecret, string accessToken)
        {
            this.client = new DropNetClient(appKey, appSecret, accessToken);
        }

        public string Upload(int imageId, string fileName, Stream fileStream)
        {
            string fullFileName = imageId + "_" + fileName;
            this.client.UploadFile("/", fullFileName, fileStream);
            return fullFileName;
        }

        public string Download(string path)
        {
            return client.GetMedia(path).Url;
        }
    }
}
