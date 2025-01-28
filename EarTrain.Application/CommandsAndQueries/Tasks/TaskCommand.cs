using EarTrain.Core.Enums;

namespace EarTrain.Application.CommandsAndQueries.Tasks
{
    public abstract record TaskCommand(TaskCategory TaskCategory, SoundCategory SoundCategory, string OGSoundSrc, string ChangedSoundSrc, string Answer);
}
