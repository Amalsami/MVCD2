using System.ComponentModel.DataAnnotations;

namespace MVCD2.Models
{
    public class Department
    {
        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }
        public int? employeeSSN { get; set; }

        public List<location>? DepartmentLocations { get; set; }
        public List<project>? Projects { get; set; }
        public employee? employee { get; set; }
        public List<employee>? employees { get; set; }

    }
}
