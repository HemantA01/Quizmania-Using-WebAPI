using Quizmania1.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Interface
{
    public interface ISubjectMaster
    {
        Task<List<SubjectMasterVM>> GetSubject();
        Task<int> AddSubject(SubjectMasterVM country);
        Task<int> UpdateSubject(int? Id, SubjectMasterVM model);
        Task<int> UpdateSubjectStatus(int? Id, bool status);
        Task<int> DeleteSubject(int? Id);
    }
}
