using Microsoft.AspNetCore.Hosting;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Model.Customer;
using Mobile_Store_MS.ViewModel.CustomerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Repositeries
{
    public class CustomerRepositery : ICustomerRepositery
    {

        public ApplicationDbContext context;
        utilities util;
        public CustomerRepositery(ApplicationDbContext _context, IHostingEnvironment hostingEnvironment)
        {
            context = _context;
            util = new utilities(_context,hostingEnvironment);
        }
        public int addCustomer(CustomerViewModel c)
        {
            Customer model = new Customer()
            {
                cus_name = c.cus_name,
                cus_phone = c.cus_phone,
                CustRef = c.CustRef
            };
            if (c.Address != null)
            {
                model.Address = new Address()
                {
                    City = util.getCities().FirstOrDefault(p => p.id == c.Address.cityId).city,
                    Country = c.Address.Country,
                    State = c.Address.State,
                    StreetAddress = c.Address.StreetAddress
                };
            }
            context.Customer.Add(model);
            context.SaveChanges();
            return model.cus_id;
        }

        public bool delete(int id)
        {
            try
            {
                var c = context.Customer.Find(id);
                context.Customer.Remove(c);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CustomerViewModel GetDetail(int id)
        {
            var x = context.Customer.Find(id);
            CustomerViewModel c = new CustomerViewModel()
            {
                cus_id = x.cus_id,
                cus_name = x.cus_name,
                cus_phone = x.cus_phone,
                CustRef = x.CustRef,
            };
            if (x.Address != null)
            {
                c.Address = new AddressViewModel()
                {
                    City = x.Address.City,
                    cityId = util.getCities().FirstOrDefault(p => p.city == x.Address.City).id,
                    Country = x.Address.Country,
                    State = x.Address.State,
                    StreetAddress = x.Address.StreetAddress
                };
            }      
            return c;
        }

        public List<CustomerViewModel> GetDetails()
        {
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            var data = context.Customer;
            foreach (var d in data)
            {
                CustomerViewModel c = new CustomerViewModel()
                {
                    cus_id = d.cus_id,
                    cus_name = d.cus_name,
                    cus_phone = d.cus_phone,
                    CustRef = d.CustRef,
                };
                if (d.Address != null)
                {
                    c.Address = new AddressViewModel()
                    {
                        AddressId = d.Address.AddressId,
                        City = d.Address.City,
                        StreetAddress = d.Address.StreetAddress
                    };
                }
                result.Add(c);
            }

            return result;
        }

        public int Update(CustomerViewModel model)
        {
            var cus = context.Customer.FirstOrDefault(x => x.cus_id == model.cus_id);

            cus.cus_id = model.cus_id;
            cus.cus_name = model.cus_name;
            cus.cus_phone = model.cus_phone;
            cus.CustRef = model.CustRef;

            if (model.Address != null)
            {
                cus.Address = new Address()
                {
                    Country = model.Address.Country,
                    State = model.Address.State,
                    City = util.getCities().FirstOrDefault(p => p.id == model.Address.cityId).city,
                    StreetAddress = model.Address.StreetAddress
                };
            }
            context.Customer.Update(cus);
            context.SaveChanges();
            return cus.cus_id;
        }
    }
}
