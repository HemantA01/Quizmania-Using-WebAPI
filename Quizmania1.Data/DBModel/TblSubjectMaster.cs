using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Data.DBModel
{
    [Table("tbl_SubjectMaster")]
    public class TblSubjectMaster
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Subject { get; set; } = "";
        public bool IsActive { get; set; } = false;
    }
}
