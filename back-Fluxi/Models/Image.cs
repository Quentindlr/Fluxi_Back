using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace back_Fluxi.Models
{
    public class Image
    {
        private int id;
        private string urlVideo;
        private string urlImage;
        private string urlImageBack;

        public Image()
        {
        }
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("url_video")]
        public string UrlVideo { get => urlVideo; set => urlVideo = value; }
        [Column("url_image")]
        public string UrlImage { get => urlImage; set => urlImage = value; }
        [Column("url_image_back")]
        public string UrlImageBack { get => urlImageBack; set => urlImageBack = value; }

        [JsonIgnore]
        [ForeignKey("filmId")]
        public Video Film { get; set; }
    }
}
