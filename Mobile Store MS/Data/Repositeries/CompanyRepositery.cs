using Microsoft.AspNetCore.Hosting;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Model;
using Mobile_Store_MS.ViewModel.CompanyViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Repositeries
{
    public class CompanyRepositery : ICompanyRepositories
    {
        public ApplicationDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;
        utilities util;
        public CompanyRepositery(ApplicationDbContext _context, IHostingEnvironment hostingEnvironment)
        {
            context = _context;
            this.hostingEnvironment = hostingEnvironment;
            util = new utilities(context, hostingEnvironment);
        }
        public int addCompany(CompanyViewModel c)
        {
            string uniqueFileName = util.ProcessPhotoproperty(c.Photo);
            CompanyModel model = new CompanyModel()
            {
                Com_name = c.Com_name,
                com_country = c.com_country,
                com_Logo = uniqueFileName,
                isActive = true
            };
            context.CompanyModel.Add(model);
            context.SaveChanges();
            return model.Phoneid;
        }

       

        public List<CompanyViewModel> GetDetails()
        {
            
                var result = context.CompanyModel.Where(x => x.isActive == true).Select(x => new CompanyViewModel()
                {
                   Phoneid=x.Phoneid,
                   Com_name= x.Com_name,
                   Photopath= x.com_Logo,
                   com_country=x.com_country
                }).ToList();
                return result;            
        }

        public CompanyViewModel GetDetail(int id)
        {
            var result = context.CompanyModel.Where(x => x.isActive == true).Select(x => new CompanyViewModel()
            {
                Phoneid = x.Phoneid,
                Com_name = x.Com_name,
                Photopath = x.com_Logo,
                com_country = x.com_country, 
            }).FirstOrDefault(x => x.Phoneid == id); 
            return result;
        }

        public int Update(EditCompanyViewModel model)
        {
           
            var result = new CompanyModel();
            result.Phoneid = model.Phoneid;
            result.com_country = model.com_country;
            result.Com_name = model.Com_name;
            result.isActive = true;
            if (model.Photo != null)
            {
                if (model.Existingphotopath != null)
                {
                    string filepath = Path.Combine(hostingEnvironment.WebRootPath, "Image", model.Existingphotopath);
                    System.IO.File.Delete(filepath);
                }
                result.com_Logo = util.ProcessPhotoproperty(model.Photo);
            }
            else
            {
                result.com_Logo = model.Existingphotopath;
            }
            context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return result.Phoneid;

        }
        public bool delete(int id)
        {
            var result = context.CompanyModel.FirstOrDefault(u => u.Phoneid == id);
            if (result != null)
            {
                result.isActive = false;
                context.Entry(result).Property("isActive").IsModified = true;
                context.SaveChanges();
                return true;
            }
            return false;

        }
       
    }
}
