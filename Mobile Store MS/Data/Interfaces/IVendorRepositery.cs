using Mobile_Store_MS.ViewModel.VendorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Interfaces
{
    public interface IVendorRepositery
    {
        List<VendorViewModel> GetDetails();
        VendorViewModel GetDetail(int id);
        int addVendor(VendorViewModel c);
        int Update(int id,VendorViewModel model);
        bool delete(int id);
    }
}
