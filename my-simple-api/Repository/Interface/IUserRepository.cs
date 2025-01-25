public interface IUserRepository
{
    List<UserModel> GetUsers();
    UserModel? GetUserById(int id);
    bool RemoveUserById(int id);
    bool UpdateUser(int id, UserModel user);
    bool InsertUser(UserModel user);
}
