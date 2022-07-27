using System.ComponentModel.DataAnnotations.Schema;

namespace back_Fluxi.Models
{
    [Table("video")]
    public class Video
    {
        private int id;

        [Column("categorie_id")]
        public int CategorieId { get ; set; }

        [ForeignKey("CategorieId")]
        public Categorie Categorie { get; set; }

        private string nameActeur;




    }
}
