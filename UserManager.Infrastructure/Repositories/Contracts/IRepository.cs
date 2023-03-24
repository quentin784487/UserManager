namespace UserManager.Infrastructure.Repositories
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(object id);
    }
}
