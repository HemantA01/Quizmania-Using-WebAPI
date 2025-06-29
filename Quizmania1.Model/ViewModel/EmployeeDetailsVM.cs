using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Model.ViewModel
{
    public class EmployeeDetailsVM
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? DOB { get; set; }
        public string? Gender { get; set; }
        public string? HighestQualification { get; set; }
        public string? CompanyServing { get; set; }
        public int? TotalExperience { get; set; }
        public int? Package { get; set; }
    }
}
