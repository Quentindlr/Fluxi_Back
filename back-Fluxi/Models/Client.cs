using System.ComponentModel.DataAnnotations.Schema;

namespace back_Fluxi.Models
{
    [Table("client")]

    public class Client
    {
        private int id;

        private string username;

        private string email;

        private string password;

        private string role;



        public Client()
        {
            Role = "user";
        }

        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("email")]
        public string Email { get => email; set => email = value; }
        [Column("username")]
        public string Username { get => username; set => username = value; }
        [Column("password")]
        public string Password { get => password; set => password = value; }

        [Column("role")]
        public string Role { get => role; set => role = value; }

    }

}
