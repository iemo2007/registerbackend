using Registration.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Features.GovernateFeatures.Queries.GetGovernatesWithCities
{
    public class GetGovernatesWithCitiesDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CityDTO> Cities { get; set; }
    }
}
