using Quizmania1.Data.DBContext;
using Quizmania1.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Interface
{
    public interface IDapperStateMaster
    {
        Task<List<CountryStateMasterVM>> GetAllStatesList();
        Task<List<CountryMasterVM>> GetActiveCountries();
    }
}
