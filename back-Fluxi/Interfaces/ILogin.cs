namespace back_Fluxi.Interfaces
{
    public interface ILogin
    {
        public bool Login(string username, string password);
        public string Login(UserDTO userDTO);
        public bool IsLogged();
    }

    public record UserDTO(string Username, string Password);
}
