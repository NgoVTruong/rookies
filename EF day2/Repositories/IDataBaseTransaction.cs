namespace EF_day2.Repositories
{
    public interface IDataBaseTransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}