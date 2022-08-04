using back_Fluxi.Models;
using back_Fluxi.Services;
using Microsoft.EntityFrameworkCore;

namespace back_Fluxi.Repositories
{
    public class ClientRepository : BaseRepository<Client>
    {

        private BaseRepository<Utilisateur> _utilisateurRepository;
        public ClientRepository(DataContextService dataContextService, BaseRepository<Utilisateur> utilisateurRepository) : base(dataContextService)
        {
            _utilisateurRepository = utilisateurRepository;
        }

        public override bool Add(Client entity)
        {
            _dataContextService.Clients.Add(entity);
            return Update() && entity.Id > 0;
        }

        public override bool Delete(Client entity)
        {
            _dataContextService.Clients.Remove(entity);
            return Update();
        }

        public override Client Find(Func<Client, bool> predicate)
        {
            return _dataContextService.Clients.Include(a => a.Utilisateurs).ToList().FirstOrDefault(u => predicate(u));
        }

        public override List<Client> FindAll(Func<Client, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
