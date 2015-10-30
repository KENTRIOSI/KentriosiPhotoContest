namespace KentriosiPhotosContests.Services.Contracts
{
    using KentriosiPhotoContest.Models;

    public interface IAccountService : IBaseService
    {
        User GetCurrentApplicationUser();
    }
}