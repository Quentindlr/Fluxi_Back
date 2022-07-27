using System.ComponentModel.DataAnnotations.Schema;

namespace back_Fluxi.Models
{
    [Table("video")]
    public class Video
    {

        private int id;
        private string name;
        private int categorieId;
        private string acteurId;

        [Column("id")]
        public int Id { get => id; set => id = value; }

        [Column("name")]
        public string Name { get => name; set => name = value; }

        [Column("categorie_id")]
        public int CategorieId { get => categorieId; set => categorieId = value; }

        [ForeignKey("CategorieId")]
        public Categorie Categorie { get; set; }

        public IList<VideoActeur> VideoActeurs { get; set; }

    }
}
