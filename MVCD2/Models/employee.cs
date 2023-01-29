using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCD2.Models
{
    public class employee
    {

        [Key]
        public int SSN { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "money")]
        public int? Salary { get; set; }
        public List<workOn>? WorksOnProjects { get; set; }

        public List<dependents>? Dependents { get; set; }

        public employee? SuperVisor { get; set; }

        public List<employee>? Employees { get; set; }

        [ForeignKey("Department")]
        public int? deptid { get; set; }

        public Department? Department { get; set; }

        public Department? Department2 { get; set; }

    }
}
