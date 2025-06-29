using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Model.ViewModel
{
    public class UserLoginVM
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class UserLoginDetailsVM
    {
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string? UserEmail { get; set; }
        public string? Token { get; set; }
        
    }
}
