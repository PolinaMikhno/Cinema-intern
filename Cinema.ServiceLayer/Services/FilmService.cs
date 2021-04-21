using System;
using System.Collections.Generic;
using Cinema.DAL.EF;
using Cinema.Services.DTO;
using Serilog;

namespace Cinema.Services.Services
{
    public class FilmService
    {
        private Repository<FilmDTO> _repository;

        public FilmService()
        {
            _repository = new Repository<FilmDTO>();
        }

        public IEnumerable<FilmDTO> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<FilmDTO> Get(Func<FilmDTO, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(FilmDTO filmDto)
        {
            if (!IsFilmDTOValid(filmDto))
            {
                return false;
            }

            try
            {
                _repository.Create(filmDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(FilmDTO filmDto)
        {
            if (!IsFilmDTOValid(filmDto))
            {
                return false;
            }

            try
            {
                _repository.Remove(filmDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(FilmDTO filmDto)
        {
            if (!IsFilmDTOValid(filmDto))
            {
                return false;
            }

            try
            {
                _repository.Update(filmDto);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }



        private bool IsFilmDTOValid(FilmDTO filmDto)
        {
            return DateTime.Compare(filmDto.Start, filmDto.End) < 0;
        }
    }
}