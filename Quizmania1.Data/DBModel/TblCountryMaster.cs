using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Data.DBModel
{
    public class TblCountryMaster
    {
        [Key]
        public int Id { get; set; }
        public string? CountryName { get; set; }
        public string? CountryAbb { get; set; }
        public bool IsActive { get; set; }
    }
}
