using System;
using System.Collections.Generic;
using System.Text;

namespace backend_school_api.Models
{
    public class UserCreate
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        
        public UserCreate(string username, string password, string email, string phone)
        {
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
            Role = "user";
        }
    }
}
