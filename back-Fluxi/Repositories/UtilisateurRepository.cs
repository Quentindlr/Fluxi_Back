using back_Fluxi.Models;
using back_Fluxi.Services;

namespace back_Fluxi.Repositories
{
    public class UtilisateurRepository : BaseRepository<Utilisateur>
    {
        public UtilisateurRepository(DataContextService dataContextService) : base(dataContextService)
        {
        }

        public override bool Add(Utilisateur entity)
        {
            _dataContextService.Utilisateurs.Add(entity);
            return Update() && entity.Id > 0;
        }

        public override bool Delete(Utilisateur entity)
        {
            _dataContextService.Utilisateurs.Remove(entity);
            return Update();
        }

        public override Utilisateur Find(Func<Utilisateur, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override List<Utilisateur> FindAll(Func<Utilisateur, bool> predicate)
        {
            return _dataContextService.Utilisateurs.Where(u => predicate(u)).ToList();
        }
    }
}
