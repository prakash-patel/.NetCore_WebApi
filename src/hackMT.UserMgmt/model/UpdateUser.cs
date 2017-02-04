 namespace hackMT.UserMgmt.model 
{ 
  
    public class UpdateUser { 
        public int user_id { get; set; } 
            public string username { get; set; } 
            public string old_password { get; set; } 
            public string new_password {get; set; } 
    } 
    public class UpdateUserResponse { 
        public int user_id { get; set; } 
            public string status { get; set; } 
            public string message { get; set; } 
             
    } 
     
}
