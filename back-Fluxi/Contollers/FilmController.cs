using back_Fluxi.Interfaces;
using back_Fluxi.Models;
using back_Fluxi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_Fluxi.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private IUpload _upload;
        private BaseRepository<Video> _videoRepository;

        public FilmController(IUpload upload, BaseRepository<Video> videoRepository)
        {
            _upload = upload;
            _videoRepository = videoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_videoRepository.FindAll(a => true));
        }

        [HttpPost]
        public IActionResult Post([FromBody] VideoDTO videoDTO)
        {
            Video video = new Video()
            {
                Name = videoDTO.Name,
                CategorieId = videoDTO.CategorieId,

            };
            _videoRepository.Add(video);
            return Ok(video);
        }

        [HttpPut("{id}/image")]
        public IActionResult PutImage(int id, [FromForm] IFormFile image, [FromForm] IFormFile imageBack)
        {
            Video video = _videoRepository.Find(a => a.Id == id);
            if (video != null)
            {
                video.Images = new Image()
                {
                    UrlImage = _upload.Upload(image),
                    UrlImageBack = _upload.Upload(imageBack),
                };
                _videoRepository.Update();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
    public record VideoDTO(string Name, int CategorieId);
}
