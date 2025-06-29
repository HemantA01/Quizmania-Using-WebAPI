using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Data.DBModel
{
    public class TblStateMaster
    {
        [Key]
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string? StateName { get; set; }
        public bool IsActive { get; set; }
    }
}
