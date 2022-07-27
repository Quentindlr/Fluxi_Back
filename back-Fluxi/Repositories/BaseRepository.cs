using back_Fluxi.Services;

namespace back_Fluxi.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected DataContextService _dataContextService;
        public BaseRepository(DataContextService dataContextService)
        {
            _dataContextService = dataContextService;
        }
        public abstract bool Add(T entity);

        public abstract bool Delete(T entity);

        public abstract T Find(Func<T, bool> predicate);

        public abstract List<T> FindAll(Func<T, bool> predicate);

        public bool Update()
        {
            return _dataContextService.SaveChanges() > 0;
        }
    }
}

