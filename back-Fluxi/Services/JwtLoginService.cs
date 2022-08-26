using back_Fluxi.Interfaces;
using back_Fluxi.Models;
using back_Fluxi.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace back_Fluxi.Services
{
    public class JwtLoginService : ILogin
    {

        private BaseRepository<Client> _clientRepository;
        public JwtLoginService(BaseRepository<Client> utilisateurRepository)
        {
            _clientRepository = utilisateurRepository;
        }
        public bool IsLogged()
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string Login(UserDTO userDTO)
        {
            Client u = _clientRepository.Find(u => u.Email == userDTO.Username && u.Mdp == userDTO.Password);
            if (u != null)
            {
                return CreateToken(u);
            }
            return null;
        }

        private string CreateToken(Client client)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bonjour je suis la chaine de crypto")), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "m2i",
                Audience = "m2i",
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("role", client.Role),
                        //new Claim("username", client.Email)
                })
            };

            SecurityToken token = tokenHandler.CreateToken(securityTokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}