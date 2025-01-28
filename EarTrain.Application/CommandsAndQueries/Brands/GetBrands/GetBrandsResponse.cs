using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Brands.GetBrands
{
    public class GetBrandsResponse
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
    }
}
