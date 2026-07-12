using E_Commerce_SystemERD_Models.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using E_Commerce_SystemERD_Models.Models;

namespace E_Commerce_SystemERD_Models.Repositories
{
    public class UserRepository
    {
        private readonly ECommerceContext context;
            public UserRepository(ECommerceContext context)
        {
            this.context = context;

        }
        public bool UsernameExists(string username)
        {
            // Check if username already exists
           return context.Users.Any(u => u.username == username);

        }
        public bool EmailExists(string email)
        {
            return context.Users.Any(u => u.email == email);
        }
        public void Add(User user)
        {
            // Add user to database
            context.Users.Add(user);
            // Save changes to execute INSERT
            context.SaveChanges();


        }
    }
}
