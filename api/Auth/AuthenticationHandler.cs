using api.Context;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Auth
{
    public class AuthenticationHandler
    {
        private PasswordManager manager;
        private DatabaseContext context;
        private JWTHandler jwt;

        public AuthenticationHandler(PasswordManager manager, DatabaseContext context, JWTHandler jwt)
        {
            this.manager = manager;
            this.context = context;
            this.jwt = jwt;
        }

        public string LoginUser(UserLogin login)
        {
            User userToVerify = (User)context.User.Where(u => u.Username == login.Username);
            if (manager.ComparePassword(userToVerify, login.Password))
            {
                userToVerify.Password = "";
                return jwt.GenerateToken(userToVerify, "GdhwhhdhJdsghh", "webshop");
            }
            throw new Exception("Invalid password");
        }


        public User CreateUser(UserCreate create)
        {
            string hashedPassword = manager.HashPassword(create.Password);

            context.User.Add(new User { Username = create.Username, Password = create.Password, Email = create.Email, Phone = create.Phone, Role =  create.Role});

            //User createdUser = _employeeRepository.Create(new EmployeeCreateDTO(createDTO.Name,
            //    hashedPassword, createDTO.Email, createDTO.Admin));
            //return createdUser;
            return null;

        }
    }
}
