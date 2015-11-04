namespace KentriosiPhotosContests.Common
{
    using System.IO;
    using DropNet;
    using KentriosiPhotoContest.Models;

    public class DropnetRepository : IDropboxRepository
    {
        private DropNetClient client;

        public DropnetRepository(string appKey, string appSecret, string accessToken)
        {
            this.client = new DropNetClient(appKey, appSecret, accessToken);
            this.client.UseSandbox = true;
        }

        public string Upload(int imageId, string fileName, Stream fileStream)
        {
            string fullFileName = imageId + "_" + fileName;
            this.client.UploadFile("/", fullFileName, fileStream);
            return fullFileName;
        }

        //public string Download(string path)
        //{
        //    return client.GetMedia(path).Url;
        //}

        public Image Download(string path)
        {
            Image img = new Image();
            var metadata = this.client.GetMetaData(path, null, false, true);
            if (null != metadata)
            {
                img.Name = metadata.Name;
                img.Path = metadata.Path;
                img.Extension = metadata.Extension;
                img.Content = this.client.GetFile(path);
            }

            return img;
        }
    }
}
