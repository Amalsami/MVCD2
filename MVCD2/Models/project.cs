using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCD2.Models
{
    public class project
    {
        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        [ForeignKey("Department")]
        public int DeptNum { get; set; }
        public Department? Department { get; set; }

        public List<workOn>? WorksOnProjects { get; set; }
    }
}
