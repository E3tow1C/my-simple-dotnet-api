public class UserRepository : IUserRepository
{
    private ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public UserModel? GetUserById(int id)
    {
        UserModel? user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
        return user;
    }
    public List<UserModel> GetUsers()
    {
        List<UserModel> users = _context.Users.ToList();
        return users;
    }

    public bool InsertUser(UserModel user)
    {
        bool status = false;
        try
        {
            user.Id = 0;
            _context.Users.Add(user);
            _context.SaveChanges();
            status = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return status;
    }

    public bool RemoveUserById(int id)
    {
        bool status = false;
        try
        {
            UserModel? _user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (_user != null)
            {
                _context.Users.Remove(_user);
                _context.SaveChanges();
                status = true;
            }
            else
            {
                Console.WriteLine($"User with id {id} not found.");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return status;
    }

    public bool UpdateUser(int id, UserModel user)
    {
        bool status = false;
        try
        {
            UserModel? _user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (_user != null)
            {
                _user.Name = user.Name;
                _user.Password = user.Password;
                _user.Username = user.Username;
                
                _context.Users.Update(_user);
                _context.SaveChanges();
                status = true;
            }
            else
            {
                Console.WriteLine($"User with id {id} not found.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return status;
    }

}