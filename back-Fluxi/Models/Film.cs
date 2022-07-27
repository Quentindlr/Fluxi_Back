using System.ComponentModel.DataAnnotations.Schema;

namespace back_Fluxi.Models
{
    [Table("film")]
    public class Film
    {
        private int id;
        private string urlVideo;
        private string urlImage;
        private string urlImageBack;
        private int videoId;

        public Film()
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
        [Column("video_id")]
        public int VideoId { get => videoId; set => videoId = value; }


        public Video Video { get; set; }
    }
}
