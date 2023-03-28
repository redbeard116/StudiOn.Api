using Microsoft.EntityFrameworkCore;

namespace DatabaseModelsBase
{
    public abstract class BaseDataBaseContext : DbContext
    {
        protected BaseDataBaseContext(DbContextOptions options) : base(options)
        {
        }


        public override int SaveChanges()
        {
            ProcessingDeletedItems();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ProcessingDeletedItems();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessingDeletedItems();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ProcessingDeletedItems();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        #region Private methods
        private void ProcessingDeletedItems()
        {
            ChangeTracker.DetectChanges();
            foreach (var item in ChangeTracker.Entries().Where(w => w.State == EntityState.Deleted))
            {
                if (item.Entity is BaseDbM dbM)
                {
                    item.State = EntityState.Modified;
                    dbM.IsDeleted = true;
                }
            }
        }
        #endregion
    }
}
