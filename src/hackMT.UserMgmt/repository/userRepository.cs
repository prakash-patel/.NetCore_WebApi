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
    public int UpdateUser(int index, UpdateUser UserToUpdate) 
    {
        using (UserDbContext context = new UserDbContext())
        {
            var updatingUser = context.User.Where(User => User.user_id == index).FirstOrDefault(); 
            if (UserToUpdate.username == updatingUser.username &&  
                UserToUpdate.old_password == updatingUser.password) 
            { 
                updatingUser.password = UserToUpdate.new_password; 
                context.SaveChanges(); 
                return index; 
            }else { 
                return 0; 
            } 
        }
    }
    public int DeleteUser(int index)
    {
        using (var context = new UserDbContext())
        {
            var UserToRemove = context.User.Where(User => User.user_id == index).FirstOrDefault();
            if(UserToRemove != null){
                context.User.Remove(UserToRemove);
                context.SaveChanges();
                return index;
            }else {
                return 0;
            }
        }
    }
    public UserExistsResponse DoesUserExist(string username)
    {
        using (var context = new UserDbContext())
        {
            var UserToRemove = context.User.Where(User => User.username == username).FirstOrDefault();
            if(UserToRemove != null){
                return new UserExistsResponse {
                    userExists = true,
                    user_id = UserToRemove.user_id,
                    message = "user found",
                    status = "success" 
                };
 
            }else {
                return new UserExistsResponse {
                    userExists = false,
                    user_id = 0,
                    message = "user not found",
                    status = "failed" 
                };
            }
        }
    }
}
}