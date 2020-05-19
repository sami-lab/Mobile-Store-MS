using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Model.Vendor;
using Mobile_Store_MS.ViewModel.VendorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Repositeries
{
    public class VendorRepositery : IVendorRepositery
    {
        public ApplicationDbContext context;

        public VendorRepositery(ApplicationDbContext _context)
        {
            context = _context;
        }
        public int addVendor(VendorViewModel c)
        {
            Vendor model = new Vendor()
            {
               ven_name= c.ven_name,
               ven_phone=c.ven_phone,
               PhoneId=c.PhoneId
            };
            context.Vendor.Add(model);
            context.SaveChanges();
            return model.ven_id;
        }

        public bool delete(int id)
        {
            try
            {
                Vendor c = new Vendor()
                {
                    ven_id = id
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

        public VendorViewModel GetDetail(int id)
        {
            var result = (from v in context.Vendor
                         join
                          Ph in context.CompanyModel
                          on v.PhoneId equals Ph.Phoneid
                          where v.ven_id == id
                          select new VendorViewModel()
                         {
                             ven_id = v.ven_id,
                             ven_name = v.ven_name,
                             ven_phone = v.ven_phone,
                             ven_comName = Ph.Com_name,
                             PhoneId= v.PhoneId
                         }).FirstOrDefault(x => x.ven_id == id); ;
           
            return result;
        }

        public List<VendorViewModel> GetDetails()
        {
            var result = (from v in context.Vendor
                          join
                           Ph in context.CompanyModel
                           on v.PhoneId equals Ph.Phoneid
                          select new VendorViewModel()
                          {
                              ven_id = v.ven_id,
                              ven_name = v.ven_name,
                              ven_phone = v.ven_phone,
                              ven_comName = Ph.Com_name,
                              PhoneId = v.PhoneId
                          }).ToList();

            return result;
          
        }

        public int Update(int id,VendorViewModel model)
        {
            Vendor c = new Vendor()
            {
                ven_id = id
            };
            c.ven_name = model.ven_name;
            c.ven_phone = model.ven_phone;
            c.PhoneId = model.PhoneId;

            context.Vendor.Update(c);
           // var vendor = context.Vendor.Update(c);
            //vendor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return c.ven_id;
        }
    }
}
