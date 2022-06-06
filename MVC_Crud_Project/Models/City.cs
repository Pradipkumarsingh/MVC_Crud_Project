using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Crud_Project.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public State State { get; set; }

      
    }
}
