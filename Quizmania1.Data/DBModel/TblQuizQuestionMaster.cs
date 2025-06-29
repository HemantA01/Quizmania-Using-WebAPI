using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quizmania1.Data.DBModel
{
    public class TblQuizQuestionMaster
    {
        [Key]
    public int Id { get; set; }
    [Required(ErrorMessage ="Please enter category id")]
    public int CategoryId { get; set; }
    [Required(ErrorMessage ="Enter question")]
    [MaxLength(250)]
    public string? Question { get; set; }
    [Required(ErrorMessage ="Enter Option 1")]
    [MaxLength(75)]
    public string? Option1 { get; set; }
    [Required(ErrorMessage = "Enter Option 2")]
    [MaxLength(75)]
    public string? Option2 { get; set; }
    [Required(ErrorMessage = "Enter Option 3")]
    [MaxLength(75)]
    public string? Option3 { get; set; }
    [Required(ErrorMessage = "Enter Option 4")]
    [MaxLength(75)]
    public string? Option4 { get; set; }
    [Required(ErrorMessage = "Enter OptionId as Correct Answer")]
    [RegularExpression("^\\d+$")]
    [MaxLength(1)]
    public int Answer { get; set; }
    public bool IsActive {  get; set; }
    public int? CreatedBy {  get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
