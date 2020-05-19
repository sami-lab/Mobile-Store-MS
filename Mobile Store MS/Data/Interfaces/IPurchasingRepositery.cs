using Mobile_Store_MS.ViewModel.PurchasingViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Interfaces
{
    public interface IPurchasingRepositery
    {
        List<PurchasingViewModel> GetDetails();
        PurchasingViewModel GetDetail(int id);
        int addPurchasing(PurchasingViewModel c);
        int Update(EditPurchasingViewModel emp);
        bool delete(int id);
    }
}
