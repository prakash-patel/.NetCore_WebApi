     
using System.ComponentModel.DataAnnotations;
namespace hackMT.UserMgmt.model
{
     public class user
    {
        [Key]
        public string user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password {get; set; }
        public string old_password {get; set; }
        public string new_password {get; set; }
        public string avatar_url {get; set; }
    }
}