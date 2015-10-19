namespace KentriosiPhotosContests.Services.Contracts
{
    using KentriosiPhotoContest.Data;

    public interface IBaseService
    {
        IKentriosiPhotoData Data { get; }
    }
}
