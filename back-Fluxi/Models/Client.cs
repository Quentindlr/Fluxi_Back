using System.ComponentModel.DataAnnotations.Schema;

namespace back_Fluxi.Models
{
    [Table("client")]

    public class Client
    {
        private int id;

        private string email;

        private string mdp;

        

        public Client()
        {


        }

        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("email")]
        public string Email { get => email; set => email = value; }
        [Column("password")]
        public string Mdp { get => mdp; set => mdp = value; }
       

        public List<Utilisateur> utilisateurs { get; set; }   
    }

}
