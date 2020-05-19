using Mobile_Store_MS.ViewModel.CompanyViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Interfaces
{
    public interface ICompanyRepositories
    {
        List<CompanyViewModel> GetDetails();
        CompanyViewModel GetDetail(int id);
        int addCompany(CompanyViewModel c);
        int Update(EditCompanyViewModel emp);
        bool delete(int id);
    }
}
