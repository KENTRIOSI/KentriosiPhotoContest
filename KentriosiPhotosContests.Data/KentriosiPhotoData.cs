namespace KentriosiPhotoContest.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Data.Entity;

    using Models;
    using Repositories;

    public class KentriosiPhotoData : IKentriosiPhotoData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public IKentriosiPhotoRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IKentriosiPhotoRepository<Contest> Contests
        {
            get
            {
                return this.GetRepository<Contest>();
            }
        }

        public IKentriosiPhotoRepository<ContestStrategy> ContestStrategies
        {
            get
            {
                return this.GetRepository<ContestStrategy>();
            }
        }

        public IKentriosiPhotoRepository<Image> Images
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }

        public IKentriosiPhotoRepository<Prize> Prizes
        {
            get
            {
                return this.GetRepository<Prize>();
            }
        }

        public IKentriosiPhotoRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IKentriosiPhotoRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            return this.context.GetValidationErrors();
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IKentriosiPhotoRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(KentriosiPhotoEFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IKentriosiPhotoRepository<T>)repositories[typeOfRepository];
        }
    }
}
