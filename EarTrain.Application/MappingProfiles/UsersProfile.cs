using AutoMapper;
using EarTrain.Application.CommandsAndQueries.Users.GetLeaderboardOfUsers;
using EarTrain.Application.CommandsAndQueries.Users.GetUserData;
using EarTrain.Core.Models;

namespace EarTrain.Application.MappingProfiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, GetUserDataResponse>()
                .ForMember(p => p.Login, opt => opt.MapFrom(p => p.Login))
                .ForMember(p => p.Email, opt => opt.MapFrom(p => p.Email))
                .ForMember(p => p.Address, opt => opt.MapFrom(p => p.Address))
                .ForMember(p => p.ETCoinsAmount, opt => opt.MapFrom(p => p.ETCoinsAmount))
                .ForMember(p => p.TrainingsCompletedAmount, opt => opt.MapFrom(p => p.TrainingsCompletedAmount))
                .ForMember(p => p.SuccessfullyCompletedTrainingsAmount, opt => opt.MapFrom(p => p.SuccessfullyCompletedTrainingsAmount));

            CreateMap<User, GetLeaderboardOfUsersResponse>()
                .ForMember(p => p.ID, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.UserLogin, opt => opt.MapFrom(p => p.Login))
                .ForMember(p => p.SuccessfulTrainingsAmount, opt => opt.MapFrom(p => p.SuccessfullyCompletedTrainingsAmount));
        }
    }
}
