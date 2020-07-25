using System;
using BulletinBoard.DAL.DbContext.Contracts;
using BulletinBoard.DAL.EntitiesConfiguration.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.DAL.DbContext
{
    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly DbContextOptions _options;
        private readonly IEntityConfigurationsContainer _entityConfigurationsContainer;

        public ApplicationDbContextFactory(
            DbContextOptions options,
            IEntityConfigurationsContainer entityConfigurationsContainer)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (entityConfigurationsContainer == null)
                throw new ArgumentNullException(nameof(entityConfigurationsContainer));

            _options = options;
            _entityConfigurationsContainer = entityConfigurationsContainer;
        }

        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext(_options, _entityConfigurationsContainer);
        }
    }
}