using E_Commerce_SystemERD_Models.Models;
using E_Commerce_SystemERD_Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce_SystemERD_Models.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;
        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public bool RegisterUser(
            string username,
            string email,
            string password,
            string fullName,
            string phoneNumber,
            string address)
        {
            if (userRepository.UsernameExists(username))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                return false;
            }
            if (userRepository.EmailExists(email))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return false;
            }

            User newUser = new User
            {
                username = username,
                email = email,
                passwordHash = password,
                fullName = fullName,
                phoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber,//validation tenery operator
                address = string.IsNullOrWhiteSpace(address) ? null : address,
                registrationDate = DateTime.Now,
                isActive = true
            };
            userRepository.Add(newUser);
            return true;
        }
        }
    }
