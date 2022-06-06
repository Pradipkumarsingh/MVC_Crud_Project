using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Crud_Project.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public Country Country { get; set; }

    }
}
