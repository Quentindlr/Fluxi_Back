using back_Fluxi.Models;
using back_Fluxi.Services;
using Microsoft.EntityFrameworkCore;

namespace back_Fluxi.Repositories
{
    public class VideoRepository : BaseRepository<Video>
    {
        private BaseRepository<Film> _filmRepository;
        private BaseRepository<Serie> _serieRepository;
        public VideoRepository(DataContextService dataContextService, BaseRepository<Film> filmRepository, BaseRepository<Serie> serieRepository) : base(dataContextService)
        {
            _filmRepository = filmRepository;
            _serieRepository = serieRepository;
        }

        public override bool Add(Video entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Video entity)
        {
            throw new NotImplementedException();
        }

        public override Video Find(Func<Video, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override List<Video> FindAll(Func<Video, bool> predicate)
        {
            return _dataContextService.Videos.Include(f => f.Film).Include(s => s.Series).ToList().Where(a => predicate(a)).ToList();
        }
    }
}
