using back_Fluxi.Models;
using back_Fluxi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_Fluxi.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private BaseRepository<Client> _clientRepository;

        public SignUpController(BaseRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clientRepository.Find(a => true));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client c)
        {
            _clientRepository.Add(c);

            return Ok(c);
        }
    }
}
