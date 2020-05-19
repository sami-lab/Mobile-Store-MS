using Mobile_Store_MS.ViewModel.ModelsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel
{
    public class GroupBYCompany
    {
            public string CompanyName { get; set; }
            public IEnumerable<ModelViewModel> Models { get; set; }       
    }
}
