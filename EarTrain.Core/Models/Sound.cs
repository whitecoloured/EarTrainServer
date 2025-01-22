using EarTrain.Core.Enums;
using System;
using System.Collections.Generic;

namespace EarTrain.Core.Models
{
    public class Sound
    {
        public Guid Id { get; set; }
        public string SoundSrc { get; set; }
        public SoundCategory Category { get; set; }
        public ICollection<TrainTask> Tasks { get; set; }
    }
}
