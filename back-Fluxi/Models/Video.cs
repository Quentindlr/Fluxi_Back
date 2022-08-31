using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace back_Fluxi.Models
{
    [Table("video")]
    public class Video
    {

        private int id;
        private string name;
        private int categorieId;
        private int filmId;
        private string urlImage;
        private string urlImageBack;
        private string urlVideo;

        public Video()
        {
            
        }

        [Column("id")]
        public int Id { get => id; set => id = value; }

        [Column("name")]
        public string Name { get => name; set => name = value; }
        
        [Column("categorie_id")]
        public int CategorieId { get => categorieId; set => categorieId = value; }

        [ForeignKey("CategorieId")]
        public Categorie Categorie { get; set; }

        [Column("url_video")]
        public string UrlVideo { get => urlVideo; set => urlVideo = value; }
        [Column("url_image")]
        public string UrlImage { get => urlImage; set => urlImage = value; }
        [Column("url_image_back")]
        public string UrlImageBack { get => urlImageBack; set => urlImageBack = value; }

        //public Image Images { get; set; }

        //[Column("film_id")]
        //public int FilmId { get => filmId; set => filmId = value; }

        //[ForeignKey("FilmId")]
        //public Film Film { get; set; }

        //public List<Serie> Series { get; set; }
        //public IList<VideoActeur> VideoActeurs { get; set; }



    }

    
}
