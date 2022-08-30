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

        public Image Images { get; set; }

        //[Column("film_id")]
        //public int FilmId { get => filmId; set => filmId = value; }

        //[ForeignKey("FilmId")]
        //public Film Film { get; set; }

        //public List<Serie> Series { get; set; }
        //public IList<VideoActeur> VideoActeurs { get; set; }



    }

    
}
