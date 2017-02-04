using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using hackMT.UserMgmt.Repository;
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

        [HttpGet()]
        [Route("users/v1/{id}")]
        public User GetUser(int id){
            return repo.GetUser(id);
        }

        [HttpPost()]
        [Route("users/v1")]
        public IActionResult Post([FromBody] User newUser)
        {
            var users = new UserCreateResponse();
            try {
                if (newUser != null)
                {
                    var addUser = repo.AddUser(newUser);
                    if(addUser > 0)
                    {
                        users.message = "user created.";
                        users.status = "success";                   
                    }
                }else{
                        users.message = "Not a valid user.";
                        users.status = "failed"; 
                        return BadRequest(users);
                }
            }
            catch {
                    users.message = "Something went wrong, please try again.";
                    users.status = "failed"; 
                    return BadRequest(users);
            }
            return Ok(newUser);
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
