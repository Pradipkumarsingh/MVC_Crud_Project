using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_Crud_Project.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
       /* [Required]
        [MinLength(3)]
        [MaxLength(10)]*/
        public string Name { get; set; }
        /*[Required]

        [MaxLength(10)]
        [RegularExpression("/^+?[1-9][0-9]{7,14}$/")]*/
        public string Mobile { get; set; }
      /* [Required]

      
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")]*/
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
      

        public int CountryId { get; set; }
       
        public int StateId { get; set; }
       
        public int CityId { get; set; }

    }
}
