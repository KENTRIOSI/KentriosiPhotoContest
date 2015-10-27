namespace KentriosiPhotosContests.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using KentriosiPhotoContest.Models;
    using KentriosiPhotoContest.Data;

    public class ContestService : BaseService, IContestService
    {
        public ContestService(IKentriosiPhotoData kentriosiPhotoData) :
            base(kentriosiPhotoData)
        {
        }

        public IEnumerable<Contest> GetPagedPublicContests(int contestPageSize, int page)
        {
            var pagedPublicContests = this.Data.Contests
                .All()
                .OrderBy(c => c.DateCreated)
                .Skip(contestPageSize * page - 1)
                .Take(contestPageSize);
            return pagedPublicContests;
        }
    }
}
