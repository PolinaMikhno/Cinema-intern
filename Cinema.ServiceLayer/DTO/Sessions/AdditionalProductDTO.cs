using System;

namespace Cinema.Services.DTO.Sessions
{
    public class AdditionalProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}