﻿using Quizmania1.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmania1.Service.Interface
{
    public interface IStateMaster
    {
        Task<List<CountryStateMasterVM>> GetCountryStateList();
        Task<List<CountryMasterVM>> GetCountryList();
        Task<int> AddState(StateMasterVM model);
        Task<StateMasterVM> GetStateById(int? Id);
        Task<int> UpdateState(int? Id, StateMasterVM model);
        Task<int> UpdateStateStatus(StateMasterVM model);
    }
}
