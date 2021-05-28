using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;

namespace Cinema.Services.Models.Sessions
{
    public class SessionModel
    {
        [Required] public Guid Id { get; set; }
        [Required] public FilmModel FilmModel { get; set; }
        [Required] public TheaterModel TheaterModel { get; set; }
        [Required] public HallModel HallModel { get; set; }
        [Required] public DateTime Start { get; set; }
        [Required] public IEnumerable<AdditionalProductEntity> AdditionalServices { get; set; }
    }
}