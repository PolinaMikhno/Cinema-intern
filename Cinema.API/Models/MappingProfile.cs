using AutoMapper;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;
using Cinema.Services.Models;
using Cinema.Services.Models.Sessions;

namespace Cinema.API.Models
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<AdditionalProductModel, AdditionalProductEntity>();
            CreateMap<AdditionalProductEntity, AdditionalProductModel>();
            
            CreateMap<SessionModel, SessionEntity>();
            CreateMap<SessionEntity, SessionModel>();
            
            CreateMap<SittingPlaceInfoEntity, SittingPlaceInfoModel>();
            CreateMap<SittingPlaceInfoModel, SittingPlaceInfoEntity>();

            CreateMap<FilmModel, FilmEntity>();
            CreateMap<FilmEntity, FilmModel>();

            CreateMap<HallModel, HallEntity>();
            CreateMap<HallEntity, HallModel>();

            CreateMap<SittingPlaceEntity, SittingPlaceModel>();
            CreateMap<SittingPlaceModel, SittingPlaceEntity>();

            CreateMap<TheaterEntity, TheaterModel>();
            CreateMap<TheaterModel, TheaterEntity>();

            CreateMap<TicketEntity, TicketModel>();
            CreateMap<TicketModel, TicketEntity>();

            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, UserEntity>();
        }
    }
}