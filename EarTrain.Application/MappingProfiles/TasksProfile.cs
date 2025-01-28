using AutoMapper;
using EarTrain.Application.CommandsAndQueries.Tasks.GetTasks;
using EarTrain.Core.Models;

namespace EarTrain.Application.MappingProfiles
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<TrainTask, GetTasksResponse>()
                .ForMember(p => p.OGSoundSrc, opt => opt.MapFrom(p => p.OGSound.SoundSrc))
                .ForMember(p => p.ChangedSoundSrc, opt => opt.MapFrom(p => p.ChangedSound.SoundSrc))
                .ForMember(p => p.Answer, opt => opt.MapFrom(p => p.Answer));

        }
    }
}
