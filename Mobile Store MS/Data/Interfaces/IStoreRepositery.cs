using Mobile_Store_MS.ViewModel.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Interfaces
{
    public interface IStoreRepositery
    {
        List<StoreViewModel> GetDetails();
        StoreViewModel GetDetail(int id);
        int addStore(StoreViewModel c);
        int Update(StoreViewModel model);
        bool delete(int id);
    }
}
