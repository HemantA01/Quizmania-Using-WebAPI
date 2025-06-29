using Microsoft.EntityFrameworkCore;
using Quizmania1.Data.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Data.DBContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public virtual DbSet<TblUserLogin> tblUserLogin { get; set; }
        public virtual DbSet<TblUserRegistration> tblUserRegistration { get; set; }
        public virtual DbSet<TblStateMaster> tblStateMaster { get; set; }
        public virtual DbSet<TblCountryMaster> tblCountryMaster { get; set; }
        public virtual DbSet<TblEmploymentTypeMaster> tblEmploymentTypeMaster { get; set; }
        public virtual DbSet<TblSubjectMaster> tblSubjectMaster { get; set; }
        public virtual DbSet<TblEmployeeDetails> tblEmployeeDetails { get; set; }
        public virtual DbSet<TblQuizQuestionMaster> tblQuizQuestionMaster { get; set; }

        
    }
}
