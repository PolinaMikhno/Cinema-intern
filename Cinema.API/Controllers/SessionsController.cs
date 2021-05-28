using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.DAL.EF;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;
using Cinema.Services.Models;
using Cinema.Services.Models.Sessions;
using Cinema.Services.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    public class SessionsController : Controller
    {
        private readonly Service<SessionModel, SessionEntity> _sessionService;

        public SessionsController(IRepository<SessionEntity> repository, IMapper mapper,
            IWebHostEnvironment environment)
        {
            _sessionService = new Service<SessionModel, SessionEntity>(repository, mapper, environment);
        }

        // TODO: authorizen
        [HttpPost("/addSession")]
        public async Task<ActionResult> CreateSession([FromForm] SessionModel sessionModel)
        {
            SessionModel dbModel = await _sessionService.CreateAsync(sessionModel);
            if (dbModel == null)
            {
                return BadRequest(
                    $"Error while trying to add session ({sessionModel.FilmModel.Name}, {sessionModel.Id})");
            }

            return Ok("");
        }


        [HttpPost("/addSessions")]
        public async Task<ActionResult> CreateSessions(IEnumerable<SessionModel> sessionModels)
        {
            foreach (var sessionModel in sessionModels)
            {
                var result = await _sessionService.CreateAsync(sessionModel);
                if (result == null)
                    return BadRequest($"Error while creating model with id: {sessionModel.Id}");
            }

            return Ok("Ok");
        }

        [HttpPost("/sessions")]
        public async Task<IEnumerable<SessionModel>> FindSessions(string searchText, DateTime? day, int? freePlaces)
        {
            freePlaces ??= 1;

            if (!day.HasValue)
            {
                // what
            }

            IEnumerable<SessionModel> sessions;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                sessions = await _sessionService.GetAsync(
                    session => session.FilmEntity.Name.Contains(searchText)
                               || session.FilmEntity.Description.Contains(searchText)
                               || session.TheaterEntity.Name.Contains(searchText)
                               || session.TheaterEntity.City.Contains(searchText)
                               || session.HallEntity.Places.Select(p => !p.IsBooked).Count() >= freePlaces
                );
            }
            else
            {
                sessions = await _sessionService.GetAsync();
            }

            return sessions;
        }

        private bool Intersects(DateTime dateTimeStart1, DateTime dateTimeEnd1, DateTime dateTimeStart2,
            DateTime dateTimeEnd2)
        {
            return IsInsideRange(dateTimeStart1, dateTimeStart2, dateTimeEnd2)
                   || IsInsideRange(dateTimeEnd1, dateTimeStart2, dateTimeEnd2)
                   || IsInsideRange(dateTimeStart2, dateTimeStart1, dateTimeEnd1)
                   || IsInsideRange(dateTimeEnd2, dateTimeStart1, dateTimeEnd1);
        }

        private bool IsInsideRange(DateTime dateTime, DateTime start, DateTime end)
        {
            return DateTime.Compare(dateTime, start) > 0
                   && DateTime.Compare(dateTime, end) < 0;
        }

        //TODO: remove and edit sessions
    }
}