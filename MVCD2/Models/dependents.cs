using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCD2.Models
{
    public class dependents
    {

        public int id { get; set; }
        public string? Name { get; set; }
        public string? Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        public string? Relationship { get; set; }

        [ForeignKey("employee")]
        public int ESSN { get; set; }
        public employee? Employee { get; set; }
    }
}

