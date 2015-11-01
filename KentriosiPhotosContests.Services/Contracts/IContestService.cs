namespace KentriosiPhotosContests.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KentriosiPhotoContest.Models;

    public interface IContestService
    {
        IEnumerable<Contest> GetPagedPublicContests(int contestPageSize, int page);
        Contest returnContest(int id);
    }
}
