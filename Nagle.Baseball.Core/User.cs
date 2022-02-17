namespace Nagle.Baseball
{
    public class User
    {
        public string Username { get; private set; }

        public User(string username)
        {
            Username = username;
        }

        private User() { }
    }
}