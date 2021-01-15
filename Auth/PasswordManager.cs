using backend_school_api.Models;
using System;

namespace backend_school_api.Auth
{
    public class PasswordManager
    {
        public bool ComparePassword(User userToVerify, string rawPassword)
        {

            if (userToVerify == null)
            {
                throw new Exception("Wrong combination of username and password");
            }
            return BCrypt.Net.BCrypt.Verify(rawPassword, userToVerify.Password);
        }

        public string HashPassword(string rawPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(rawPassword);
        }
    }
}
