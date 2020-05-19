using Microsoft.AspNetCore.Hosting;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Model.Store;
using Mobile_Store_MS.ViewModel.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Repositeries
{
    public class StoreRepositery : IStoreRepositery
    {
        public ApplicationDbContext context;
        public utilities util;
        public StoreRepositery(ApplicationDbContext _context, IHostingEnvironment hostingEnvironment)
        {
            context = _context;
            util = new utilities(_context, hostingEnvironment);
        }
        public int addStore(StoreViewModel c)
        {
            Store model = new Store()
            {
              StoreName= c.StoreName,
              City= c.City,
              Date= c.Date,
              Ref_No= util.GenerateStoreRef(c.City),
              Lat= c.Lat,
              Lng= c.Lng,
              SupportNo=c.SupportNo,
              Address= c.CompleteAddress
            };
            context.Stores.Add(model);
            context.SaveChanges();
            return model.store_id;
        }

        public bool delete(int id)
        {
            try
            {
                Store c = new Store()
                {
                    store_id = id
                };
                context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public StoreViewModel GetDetail(int id)
        {
            var result = context.Stores.Select(x => new StoreViewModel()
            {
                store_id = x.store_id,
                City= x.City,
                CityName = util.getCities().FirstOrDefault(v => v.id == x.City).city,
                Date = x.Date,
                Lat = x.Lat,
                Lng = x.Lng,
                Ref_No= x.Ref_No,
                StoreName = x.StoreName +'#'+ x.Ref_No,
                SupportNo = x.SupportNo,
                CompleteAddress=x.Address
            }).FirstOrDefault(x => x.store_id == id);
            return result;
        }

        public List<StoreViewModel> GetDetails()
        {
            var result = context.Stores.Select(x => new StoreViewModel()
            {
               store_id= x.store_id,             
               CityName= util.getCities().FirstOrDefault(v => v.id== x.City).city,
               Date= x.Date,
               Lat=x.Lat,
               Lng= x.Lng,
               StoreName= x.StoreName+x.Ref_No,
               SupportNo= x.SupportNo,
               CompleteAddress= x.Address
            }).ToList();
            return result;
        }

        public int Update(StoreViewModel model)
        {
            var result = new Store();
            result.store_id = model.store_id;
            result.City = model.City;
            result.Lat = model.Lat;
            result.Lng = model.Lng;
            result.StoreName = model.StoreName;
            result.SupportNo = model.SupportNo;
            result.Address = model.CompleteAddress;
            result.Ref_No = model.Ref_No;
            context.Stores.Update(result);
            context.SaveChanges();
            return result.store_id;
        }
    }
}
