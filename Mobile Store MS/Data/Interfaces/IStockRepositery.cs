using Mobile_Store_MS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Interfaces
{
    public interface IStockRepositery
    {
         List<StockViewModel> GetDetails();

         List<StockViewModel> BrandStock(int model_id);

        StockViewModel StoreBrandStock(int store_id, int model_id);
        bool AddStockManually(StockViewModel model);
    }
}
