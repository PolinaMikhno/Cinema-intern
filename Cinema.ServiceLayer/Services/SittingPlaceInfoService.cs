﻿using System;
using System.Collections.Generic;
using Cinema.DAL.EF;
using Cinema.Services.DTO.Sessions;
using Serilog;

namespace Cinema.Services.Services
{
    public class SittingPlaceInfoService
    {
        private Repository<SittingPlaceInfoModel> _repository;

        public SittingPlaceInfoService()
        {
            _repository = new Repository<SittingPlaceInfoModel>();
        }

        public IEnumerable<SittingPlaceInfoModel> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<SittingPlaceInfoModel> Get(Func<SittingPlaceInfoModel, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public bool Create(SittingPlaceInfoModel sittingPlaceInfoModel)
        {
            if (!IsSittingPlaceInfoDTOValid(sittingPlaceInfoModel))
            {
                return false;
            }

            try
            {
                _repository.Create(sittingPlaceInfoModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Remove(SittingPlaceInfoModel sittingPlaceInfoModel)
        {
            if (!IsSittingPlaceInfoDTOValid(sittingPlaceInfoModel))
            {
                return false;
            }

            try
            {
                _repository.Remove(sittingPlaceInfoModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(SittingPlaceInfoModel sittingPlaceInfoModel)
        {
            if (!IsSittingPlaceInfoDTOValid(sittingPlaceInfoModel))
            {
                return false;
            }

            try
            {
                _repository.Update(sittingPlaceInfoModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }

            return true;
        }


        private bool IsSittingPlaceInfoDTOValid(SittingPlaceInfoModel sittingPlaceInfoModel)
        {
            return sittingPlaceInfoModel.Price > 0;
        }
    }
}