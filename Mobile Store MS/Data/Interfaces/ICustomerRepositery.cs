using Mobile_Store_MS.ViewModel.CustomerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Interfaces
{
    public interface ICustomerRepositery
    {
        List<CustomerViewModel> GetDetails();
        CustomerViewModel GetDetail(int id);
        int addCustomer(CustomerViewModel c);
        int Update(CustomerViewModel emp);
        bool delete(int id);
    }
}
