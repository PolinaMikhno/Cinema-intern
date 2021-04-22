using System;
using System.Collections.Generic;
using Cinema.DAL.EF;
using Cinema.Services.DTO;
using Serilog;

namespace Cinema.Services.Services
{
    public class FilmService: IService<FilmModel>
    {
        private Repository<FilmModel> _repository;

        public FilmService(Repository<FilmModel> repository)
        {
            _repository = repository;
        }

        public IEnumerable<FilmModel> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<FilmModel> Get(Func<FilmModel, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(FilmModel filmModel)
        {
            if (!IsFilmDTOValid(filmModel))
            {
                return false;
            }

            try
            {
                _repository.Create(filmModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(FilmModel filmModel)
        {
            if (!IsFilmDTOValid(filmModel))
            {
                return false;
            }

            try
            {
                _repository.Remove(filmModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(FilmModel filmModel)
        {
            if (!IsFilmDTOValid(filmModel))
            {
                return false;
            }

            try
            {
                _repository.Update(filmModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }



        private bool IsFilmDTOValid(FilmModel filmModel)
        {
            return DateTime.Compare(filmModel.Start, filmModel.End) < 0;
        }
    }
}