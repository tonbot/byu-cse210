class AuthenticationService
{
    private List<User> users = new List<User>();

    public void Register(User user)
    {
        users.Add(user);
    }

    public User Authenticate(string email, string password)
    {
        foreach (User user in users)
        {
            if (user.Email == email && user.Password == password)
            {
                return user;
            }
        }
        return null;
    }
}