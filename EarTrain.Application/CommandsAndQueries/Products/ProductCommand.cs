using EarTrain.Core.Enums;
using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Products
{
    public record ProductCommand(string Name, string Desc, ProductsCategory Category, Guid BrandID, int Price, List<KeyValuePair<string, string>> Characteristics);
}
