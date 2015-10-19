namespace KentriosiPhotoContest.Data
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;

    using Models;
    using Repositories;

    public interface IKentriosiPhotoData
    {
        IKentriosiPhotoRepository<Contest> Contests { get; }

        IKentriosiPhotoRepository<ContestStrategy> ContestStrategies { get; }

        IKentriosiPhotoRepository<Image> Images { get; }

        IKentriosiPhotoRepository<Prize> Prizes { get; }

        IKentriosiPhotoRepository<Vote> Votes { get; }

        IKentriosiPhotoRepository<Comment> Comments { get; }

        IKentriosiPhotoRepository<User> Users { get; }

        IEnumerable<DbEntityValidationResult> GetValidationErrors();

        int SaveChanges();
    }
}
