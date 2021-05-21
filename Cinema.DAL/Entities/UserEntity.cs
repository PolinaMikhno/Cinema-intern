using System;
using System.Collections.Generic;
using Cinema.DAL.Auth;

namespace Cinema.DAL.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        // admin, user
        // cinema admin???
        public string Role { get; set; }

        public IEnumerable<TicketEntity> Tickets { get; set; }

        public UserEntity()
        {
            
        }
        
        public UserEntity(string name, string password)
        {
            Name = name;
            PasswordHash = Cryptography.HashPassword(password);
        }
        
        public bool CheckPassword(string possiblePassword)
        {
            return Cryptography.VerifyHashedPassword(PasswordHash, possiblePassword);
        }
    }
}