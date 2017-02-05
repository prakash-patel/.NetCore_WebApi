using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using hackMT.UserMgmt.Repository;
using hackMT.UserMgmt.model;
using Microsoft.AspNetCore.JsonPatch;
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
                    Guid guid = Guid.NewGuid();
                    newUser.api_token = guid.ToString();
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
            catch (Exception ex){
                    users.message = ex.InnerException.Message;
                    users.status = "failed"; 
                    return BadRequest(users);
            }
            return Ok(newUser);
        }

        [HttpPatch] 
        [Route("users/v1/{id}")]
        public IActionResult Patch(int id, [FromBody] UpdateUser UserToUpdate) 
        {
            var response = new UpdateUserResponse(); 
            try { 
                    if (UserToUpdate != null) 
                    { 
                        var updateUserId = repo.UpdateUser(id, UserToUpdate); 
                        if(updateUserId > 0) 
                        { 
                            response.user_id = updateUserId; 
                            response.message = "Password successfully changed."; 
                            response.status = "success";                    
                        }else{ 
                            response.user_id = id;
                            response.message = "Your entry for 'old password' is incorrect."; 
                            response.status = "failed";  
                            return BadRequest(response); 
                        }
                    }else{ 
                            response.user_id = id;
                            response.message = "Your entry for 'old password' is incorrect."; 
                            response.status = "failed";  
                            return BadRequest(response); 
                    } 
            } 
            catch { 
                    response.message = "Something went wrong, please try again."; 
                    response.status = "failed";  
                    return BadRequest(response); 
            } 
 
            return Ok(response); 

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