using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Repositeries
{
    public class StockRepositery : IStockRepositery
    {
        public ApplicationDbContext context;
        public StockRepositery(ApplicationDbContext _context)
        {
            context = _context;
        }
        public List<StockViewModel> BrandStock(int model_id)
        {
            var result = (from s in context.Stock
                          join
                           Br in context.BrandModel
                          on s.modelId equals Br.modelId
                          join
                          p in context.CompanyModel
                          on Br.PhoneId equals p.Phoneid
                          join
                          store in context.Stores
                          on s.store_id equals store.store_id
                          where s.modelId== model_id
                          select new StockViewModel()
                          {
                              id = s.id,
                              Com_name = p.Com_name,
                              Phoneid = p.Phoneid,
                              modelId = Br.modelId,
                              model_name = Br.model_name,
                              Quantity = s.Quantity,
                              store_id = store.store_id,
                              StoreName = store.StoreName+'#'+store.Ref_No,
                              RefNo = store.Ref_No
                          }).ToList();

            return result;
        }

        public List<StockViewModel> GetDetails()
        {
            var result = (from s in context.Stock
                          join
                           Br in context.BrandModel
                          on s.modelId equals Br.modelId
                          join 
                          p in context.CompanyModel
                          on Br.PhoneId equals p.Phoneid
                          join 
                          store in context.Stores
                          on s.store_id equals store.store_id
                          select new StockViewModel()
                          {
                            id = s.id,
                            Com_name= p.Com_name,
                            Phoneid= p.Phoneid,
                            modelId= Br.modelId,
                            model_name= Br.model_name,
                            Quantity= s.Quantity,
                            store_id= store.store_id,
                            StoreName= store.StoreName,
                            RefNo= store.Ref_No 
                          }).ToList();

            return result;
        }

        public StockViewModel StoreBrandStock(int store_id, int model_id)
        {
            var result = (from s in context.Stock
                          join
                           Br in context.BrandModel
                          on s.modelId equals Br.modelId
                          join
                          p in context.CompanyModel
                          on Br.PhoneId equals p.Phoneid
                          join
                          store in context.Stores
                          on s.store_id equals store.store_id
                          select new StockViewModel()
                          {
                              id = s.id,
                              Com_name = p.Com_name,
                              Phoneid = p.Phoneid,
                              modelId = Br.modelId,
                              model_name = Br.model_name,
                              Quantity = s.Quantity,
                              store_id = store.store_id,
                              StoreName = store.StoreName,
                              RefNo = store.Ref_No
                          }).FirstOrDefault(x => x.store_id == store_id && x.modelId == model_id);

            return result;
        }

   
    }
}
