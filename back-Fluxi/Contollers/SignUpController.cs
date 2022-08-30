using back_Fluxi.Models;
using back_Fluxi.Repositories;
using Microsoft.AspNetCore.Cors;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_clientRepository.Find(a => a.Id == id));
        }

        [HttpPost]
        public IActionResult Post(Client c)
        {
            _clientRepository.Add(c);

            return Ok(c);
        }
    }
}
