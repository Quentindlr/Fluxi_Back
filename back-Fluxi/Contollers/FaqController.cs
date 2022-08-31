using back_Fluxi.Models;
using back_Fluxi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_Fluxi.Contollers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FaqController : ControllerBase
    {
        private BaseRepository<Faq> _faqRepository;

        public FaqController(BaseRepository<Faq> faqRepository)
        {
            _faqRepository = faqRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_faqRepository.FindAll(a => true));
        }

        [HttpPost]
        public IActionResult Post(Faq f)
        {
            _faqRepository.Add(f);
            return Ok(f);
        }
    }
}
