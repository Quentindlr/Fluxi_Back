using System.ComponentModel.DataAnnotations.Schema;

namespace back_Fluxi.Models
{
    [Table("categorie")]
    public class Categorie
    {
        private int id;
        private string name;

        public Categorie()
        {
        }
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("name")]
        public string Name { get => name; set => name = value; }
    }
}