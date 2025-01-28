using EarTrain.Core.Enums;
using System;

namespace EarTrain.Core.Models
{
    public class ChangedSound
    {
        public Guid Id { get; set; }
        public string SoundSrc { get; set; }
        public SoundCategory Category { get; set; }
        public TrainTask Task { get; set; }
        public int? TaskID { get; set; }

        public static ChangedSound Create(string SoundSrc, SoundCategory Category)
        {
            return new()
            {
                SoundSrc = SoundSrc,
                Category = Category
            };
        }
    }
}
