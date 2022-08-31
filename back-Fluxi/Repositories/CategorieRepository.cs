using back_Fluxi.Models;
using back_Fluxi.Services;

namespace back_Fluxi.Repositories
{
    public class CategorieRepository : BaseRepository<Categorie>
    {
        public CategorieRepository(DataContextService dataContextService) : base(dataContextService)
        {
        }

        public override bool Add(Categorie entity)
        {
            _dataContextService.Categories.Add(entity);
            return Update() && entity.Id > 0;
        }

        public override bool Delete(Categorie entity)
        {
            _dataContextService.Categories.Remove(entity);
            return Update();
        }

        public override Categorie Find(Func<Categorie, bool> predicate)
        {
            return _dataContextService.Categories.ToList().FirstOrDefault(u => predicate(u));
        }

        public override List<Categorie> FindAll(Func<Categorie, bool> predicate)
        {
            return _dataContextService.Categories.Where(predicate).ToList();
        }
    }
}
