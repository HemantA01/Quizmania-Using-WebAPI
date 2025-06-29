using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Data.DBModel
{
    public class TblUserRegistration
    {
        [Key]
        public int Id { get; set; }
        public string? UserFName { get; set; }
        public string? UserLName { get; set; }
        public string? UserContact { get; set; }
        public string? UserEmailId { get; set; }
        public DateTime? DOB { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? TemporaryAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string? City { get; set; }
        public int? EmploymentTypeId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
