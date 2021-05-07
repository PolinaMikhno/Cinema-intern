using System;
using System.Collections.Generic;
using Cinema.DAL.Auth;
using Cinema.DAL.Entities;

namespace Cinema.Services.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        // admin, user
        // cinema admin???
        public string Role { get; set; }

        public IEnumerable<TicketEntity> Tickets { get; set; }

        public UserModel()
        {
            Role = "User";
        }
        public UserModel(string name, string password)
        {
            Name = name;
            PasswordHash = Cryptography.HashPassword(password);
            Role = "User";
        }

        public bool CheckPassword(string possiblePassword)
        {
            return Cryptography.VerifyHashedPassword(PasswordHash, possiblePassword);
        }
    }
}