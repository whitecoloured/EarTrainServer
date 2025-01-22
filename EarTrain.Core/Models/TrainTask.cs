﻿using EarTrain.Core.Enums;
using System;

namespace EarTrain.Core.Models
{
    public class TrainTask
    {
        public int Id { get; set; }
        public TaskCategory Category { get; set; }
        public Sound OGSound { get; set; }
        public Guid? OGSoundID { get; set; }
        public ChangedSound ChangedSound { get; set; }
        public Guid? ChangedSoundID { get; set; }
        public string Answer { get; set; }
    }
}
