using back_Fluxi.Models;
using back_Fluxi.Services;
using Microsoft.EntityFrameworkCore;

namespace back_Fluxi.Repositories
{
    public class VideoRepository : BaseRepository<Video>
    {
        //private BaseRepository<Film> _filmRepository;
        //private BaseRepository<Serie> _serieRepository;
        public VideoRepository(DataContextService dataContextService) : base(dataContextService)
        {
            //_filmRepository = filmRepository;
            //_serieRepository = serieRepository;
        }

        public override bool Add(Video entity)
        {
            _dataContextService.Videos.Add(entity);
            return Update() && entity.Id > 0;
        }

        public override bool Delete(Video entity)
        {
            _dataContextService.Videos.Remove(entity);
            return Update();
        }

        public override Video Find(Func<Video, bool> predicate)
        {
            return _dataContextService.Videos.ToList().FirstOrDefault(u => predicate(u));
        }

        public override List<Video> FindAll(Func<Video, bool> predicate)
        {
            //return _dataContextService.Videos.Include(c => c.Categorie).Include(i=> i.Images).ToList().Where(a => predicate(a)).ToList();
            return _dataContextService.Videos.Include(c => c.Categorie).ToList().Where(a => predicate(a)).ToList();
        }
    }
}
