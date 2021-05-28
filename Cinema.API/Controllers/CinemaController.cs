using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.DAL.EF;
using Cinema.DAL.Entities;
using Cinema.Services.Models;
using Cinema.Services.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    public class CinemaController : Controller
    {
        private readonly Service<FilmModel, FilmEntity> _filmService;

        private const string PostersImagesPath = "FilmPosters";
        public CinemaController(IRepository<FilmEntity> repository, IMapper mapper, IWebHostEnvironment environment)
        {
            _filmService = new Service<FilmModel, FilmEntity>(repository, mapper, environment);
        }

        // TODO: authorizen
        [HttpPost("/addFilm")]
        public async Task<ActionResult> CreateFilm([FromForm]FilmModel filmModel)
        {
            string uploadedFileUniqueName = _filmService.UploadedFile(PostersImagesPath, filmModel.PosterImage);
            filmModel.PosterImageName = uploadedFileUniqueName;
            
            FilmModel dbModel = await _filmService.CreateAsync(filmModel);
            if (dbModel == null)
            {
                return BadRequest($"Error while trying to add film ({filmModel.Name}, {filmModel.Id})");
            }
            
            return Ok("");
        }

        [HttpPost("/filmByName")]
        public async Task<FilmModel> GetFilmByName(string filmName)
        {
            IEnumerable<FilmModel> models = await _filmService.GetAsync(film => film.Name.Equals(filmName));
            if (models.Count() == 0)
            {
                throw new Exception("Film Something Does Not Exist");
            } 
            return models.FirstOrDefault();
        }
        

        [HttpPost("/addFilms")]
        public async Task<ActionResult> CreateFilms(IEnumerable<FilmModel> filmModels)
        {
            foreach (var filmModel in filmModels)
            {
                var result = await _filmService.CreateAsync(filmModel);
                if (result == null)
                    return BadRequest($"Error while creating model with id: {filmModel.Id}");
            }

            return Ok("Ok");
        }
        
        

        [HttpPost("/films")]
        public async Task<IEnumerable<FilmModel>> FindFilms(string searchText, DateTime? start, DateTime? end)
        {
            if (start.HasValue && end.HasValue)
            {
                if (DateTime.Compare((DateTime) start, (DateTime) end) >= 0)
                    throw new Exception("Start date is later than end date");
            }
            else
            {
                start = DateTime.Now;
                end = DateTime.Now;
            }

            IEnumerable<FilmModel> films;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                films = await _filmService.GetAsync(
                    film =>
                        (film.Name.Contains(searchText)
                         || film.Description.Contains(searchText))
                        /*&& DateTime.Compare(film.Start, (DateTime) start) >= 0
                        && DateTime.Compare(film.End, (DateTime) end) <= 0
                        && Intersects(film.Start, film.End, (DateTime) start, (DateTime) end)*/
                );
            }
            else
            {
                films = await _filmService.GetAsync();
            }

            return films;
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

        //TODO: remove and edit films
    }
}