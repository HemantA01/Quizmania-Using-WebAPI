using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Model.ViewModel
{
    public class CountryMasterVM
    {
        public int Id { get; set; }
        public string? CountryName { get; set; }
        public string? CountryAbb { get; set; }
        public bool IsActive { get; set; }
    }
}
