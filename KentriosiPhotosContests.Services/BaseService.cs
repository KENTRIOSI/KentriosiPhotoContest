namespace KentriosiPhotosContests.Services
{
    using Contracts;
    using KentriosiPhotoContest.Data;

    public class BaseService : IBaseService
    {
        private IKentriosiPhotoData kentriosiPhotoData;

        public BaseService(IKentriosiPhotoData kentriosiPhotoData)
        {
            this.Data = kentriosiPhotoData;
        }

        public IKentriosiPhotoData Data
        {
            get
            {
                return this.kentriosiPhotoData;
            }
            private set
            {
                this.kentriosiPhotoData = value;
            }
        }
    }
}
