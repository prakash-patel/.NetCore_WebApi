using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using hackMT.UserMgmt.Repoitory;
using hackMT.UserMgmt.model;

namespace hackMT.UserMgmt.Controllers
{
    public class UserController : Controller
    {
        static List<User> Users = new List<User>();
        UserRepository repo = new UserRepository();
        [HttpGet()]
        [Route("api/User/Users")]
        public List<User> GetAll()
        {
            return repo.GetAllUsers();
        }

        [HttpPost()]
        [Route("api/User/User")]
        public int Post([FromBody] User newUser)
        {
            if (newUser != null)
            {
                return repo.AddUser(newUser);
            }
            return -1;
        }

        [HttpPut()]
        [Route("api/User/{id}")]
        public int Put(int id, [FromBody] User UserToUpdate)
        {
            return repo.UpdateUser(id, UserToUpdate);
        }

        [HttpDelete()]
        [Route("api/User/{id}")]
        public bool Delete(int id)
        {
            bool isDeleteSuccessful = false;
            try
            {
                repo.DeleteUser(id);
                isDeleteSuccessful = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
            return isDeleteSuccessful;
        }
    }
}
