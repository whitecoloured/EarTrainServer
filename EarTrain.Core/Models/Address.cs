﻿using EarTrain.Core.Enums;

namespace EarTrain.Core.Models
{
    public class Address
    {
        public StreetType StreetType { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
    }
}
