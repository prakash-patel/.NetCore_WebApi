using System.ComponentModel.DataAnnotations;
namespace hackMT.UserMgmt.model
{
    public class UpdateUser
    {
        [Required]
        public int user_id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string old_password { get; set; }
        [Required]
        public string new_password { get; set; }
    }
    public class UpdateUserResponse
    {
        public int user_id { get; set; }
        public string status { get; set; }
        public string message { get; set; }

    }
}
