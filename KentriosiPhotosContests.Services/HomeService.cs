namespace KentriosiPhotosContests.Services
{
    using Contracts;
    using KentriosiPhotoContest.Data;

    public class HomeService : BaseService, IHomeService, IBaseService
    {
        public HomeService(IKentriosiPhotoData data)
            : base(data)
        {
        }
    }
}
