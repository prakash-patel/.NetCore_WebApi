using System.Linq;
using System.Collections.Generic;
using hackMT.UserMgmt.model;

namespace hackMT.UserMgmt.Repository
{
    public class UserRepository
    {
    public UserRepository()
    {

    }
    public int AddUser(User newUser)
    {
        int UserIndex;
        using (UserDbContext context = new UserDbContext())
        {
            context.User.Add(newUser);
            context.SaveChanges();
            UserIndex = context.User.ToList().IndexOf(newUser);
        }
        return UserIndex;
    }
    public List<User> GetAllUsers()
    {
        using (UserDbContext context = new UserDbContext())
        {
            return context.User.ToList();
        }
    }

    public User GetUser(int userId)
    {
        using (UserDbContext context = new UserDbContext())
        {
            return context.User.Where(User => User.user_id == userId).FirstOrDefault();
        }

    }
    public int UpdateUser(int index, User UserToUpdate)
    {
        using (UserDbContext context = new UserDbContext())
        {
            var updatingUser = context.User.Where(User => User.user_id == index).FirstOrDefault();
            updatingUser.avatar_url = UserToUpdate.avatar_url;
            updatingUser.email = UserToUpdate.email;
            context.SaveChanges();
            return index;
        }
    }
    public bool DeleteUser(int index)
    {
        using (var context = new UserDbContext())
        {
            var UserToRemove = context.User.ToList()[index];
            context.User.Remove(UserToRemove);
            context.SaveChanges();
            return true;
        }
    }
}
}