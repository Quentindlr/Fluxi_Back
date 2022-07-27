using System.ComponentModel.DataAnnotations.Schema;

namespace back_Fluxi.Models
{
    [Table("utilisateur")]
    public class Utilisateur
    {

        private int id;

        private string name;

        private string role;

        private int clientId;

        public Utilisateur()
        {
        }

        [Column("role")]
        public string Role { get => role; set => role = value; }
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("name")]
        public string Name { get => name; set => name = value; }

        [Column("client_id")]
        public int ClientId { get => clientId; set => clientId = value; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }
}