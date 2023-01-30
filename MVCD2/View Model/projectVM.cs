using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCD2.View_Model
{
    public class projectVM
    {

            [Key]
            public int Number { get; set; }
            [Required]
            [MinLength(5)]
            [Display(Name = "Project Name")]
            public string? Name { get; set; }

            [Display(Name = "Project Location")]
            [Required]
            [Remote("ValidateLocation", "customValidation", ErrorMessage = "Location Must be Cairo or Giza or Alex")]
            public string? Location { get; set; }


            [Compare("Location")]
            public string? confirmLocation { get; set; }
        
    }
}
