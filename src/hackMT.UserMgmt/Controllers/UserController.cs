using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using hackMT.UserMgmt.Repository;
using hackMT.UserMgmt.model;
using System;

namespace hackMT.UserMgmt.Controllers
{
    public class UserController : Controller
    {
        static List<User> Users = new List<User>();
        UserRepository repo = new UserRepository();
        [HttpGet()]
        [Route("users/v1")]
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
        [Route("users/v1/")]
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

        [HttpGet()]
        [Route("users/v1/status")]
        public IActionResult apiStatus()
        {
            var status = new apiStatus();
                status.status = "online";
                status.user_count = repo.GetAllUsers().Count;
            return Ok(status);
        }

        [HttpDelete()]
        [Route("users/v1/{id}")]
        public IActionResult Delete(int id)
        {
            var users = new DeleteUserResponse();
            try {
                if (id > 0)
                {
                    var deleteUserId = repo.DeleteUser(id);
                    if(deleteUserId > 0)
                    {
                        users.user_id = deleteUserId;
                        users.message = "user deleted.";
                        users.status = "success";                   
                    }
                    else{
                        users.user_id = id;
                        users.message = "Not a valid user id.";
                        users.status = "failed"; 
                        return BadRequest(users);
                    }
                }else{
                        users.user_id = id;
                        users.message = "Not a valid user id.";
                        users.status = "failed"; 
                        return BadRequest(users);
                }
            }
            catch {
                    users.user_id = id;
                    users.message = "Something went wrong, please try again.";
                    users.status = "failed"; 
                    return BadRequest(users);
            }
            return Ok(users);
        }
    }
}