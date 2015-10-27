namespace KentriosiPhotosContests.Services.Contracts
{
    using KentriosiPhotoContest.Models;

    public interface IImagesService : IBaseService
    {
        Image ById(int id);
    }
}
