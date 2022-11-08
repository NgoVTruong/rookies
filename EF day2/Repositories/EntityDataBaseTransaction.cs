using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EF_day2.Repositories
{
    public class EntityDataBaseTransaction : IDataBaseTransaction
    {
        private IDbContextTransaction _transaction;

        public EntityDataBaseTransaction(DbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            //_transaction.Rollback();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}