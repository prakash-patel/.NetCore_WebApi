     
using System.ComponentModel.DataAnnotations;
namespace hackMT.UserMgmt.model
{
     public class User
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password {get; set; }
        public string old_password {get; set; }
        public string new_password {get; set; }
        public string avatar_url {get; set; }   
        public string api_token {get; set; }
    }

    public class UserCreateResponse : User{       
        public string message {get; set; }
        public string status {get; set; }  
    }
    public class UserExistsResponse {
        public int user_id {get; set; }
        public bool userExists {get; set; }
        public string message {get; set;}
        public string status {get; set; }  
        
    }
}