using back_Fluxi.Models;
using back_Fluxi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_Fluxi.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private BaseRepository<Categorie> _categorieRepository;

        public TestController(BaseRepository<Categorie> categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }

        [HttpPost]
        [Authorize]
        [Authorize("admin")]
        public IActionResult Post([FromBody] Categorie c)
        {
            _categorieRepository.Add(c);
            return Ok(c);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categorieRepository.FindAll(a => true));
        }

    }
}
