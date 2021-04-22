using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;

namespace Cinema.Services.DTO.Sessions
{
    public class SessionModel
    {
        [Required] public Guid Id { get; set; }
        [Required] public FilmEntity FilmEntity { get; set; }
        [Required] public TheaterEntity TheaterEntity { get; set; }
        [Required] public HallEntity HallEntity { get; set; }
        [Required] public DateTime Start { get; set; }
        [Required] public IEnumerable<AdditionalProductEntity> AdditionalServices { get; set; }
    }
}