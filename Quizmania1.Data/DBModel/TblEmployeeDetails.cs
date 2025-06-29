using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Data.DBModel
{
    public class TblEmployeeDetails
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(75)]
        public string? Email { get; set; }
        [MaxLength(10)]
        public DateTime? DOB { get; set; }
        [MaxLength(7)]
        public string? Gender { get; set; }
        [MaxLength(30)]
        public string? HighestQualification { get; set; }
        [MaxLength(100)]
        public string? CompanyServing { get; set; }
        public int? TotalExperience { get; set; }
        public int? Package { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
