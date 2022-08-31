using back_Fluxi.Models;
using back_Fluxi.Services;

namespace back_Fluxi.Repositories
{
    public class FaqRepository : BaseRepository<Faq>
    {
        public FaqRepository(DataContextService dataContextService) : base(dataContextService)
        {
        }

        public override bool Add(Faq entity)
        {
            _dataContextService.Faqs.Add(entity);
            return Update() && entity.Id > 0;
        }

        public override bool Delete(Faq entity)
        {
            _dataContextService.Faqs.Remove(entity);
            return Update();
        }

        public override Faq Find(Func<Faq, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override List<Faq> FindAll(Func<Faq, bool> predicate)
        {
            return _dataContextService.Faqs.Where(predicate).ToList();
        }
    }
}
