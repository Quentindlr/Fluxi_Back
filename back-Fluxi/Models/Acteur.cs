using System.ComponentModel.DataAnnotations.Schema;

namespace back_Fluxi.Models
{
    [Table("acteur")]
    public class Acteur
    {
        private int id;
        private string name;

        public Acteur()
        {
        }
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("name")]
        public string Name { get => name; set => name = value; }

        public IList<VideoActeur> VideoActeurs { get; set; }
    }
}
