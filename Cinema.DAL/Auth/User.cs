namespace Cinema.DAL.Auth
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        // admin, user
        // cinema admin???
        public string Role { get; set; }
    }
}