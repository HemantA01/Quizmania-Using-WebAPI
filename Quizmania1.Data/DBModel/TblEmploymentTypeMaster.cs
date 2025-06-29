using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Data.DBModel
{
    public class TblEmploymentTypeMaster
    {
        [Key]
        public int Id { get; set; }
        public string? EmploymentType { get; set; }
        public bool IsActive { get; set; }
    }
}
