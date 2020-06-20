using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Mobile_Store_MS.Data.Model.Company;
using Mobile_Store_MS.Data.Model.Stock;
using Mobile_Store_MS.ViewModel;
using Mobile_Store_MS.ViewModel.CompanyViewModel;
using Mobile_Store_MS.ViewModel.ModelsViewModel;
using Mobile_Store_MS.ViewModel.Orders;
using Mobile_Store_MS.ViewModel.PurchasingViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Mobile_Store_MS.Data.Model.Messages;
using Mobile_Store_MS.ViewModel.MessagesViewModel;

namespace Mobile_Store_MS.Data
{
    public class utilities
    {

        public ApplicationDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;
        public readonly IConfiguration Configuration;
        // public UserManager<ApplicationUser> UserManager;
        //public utilities(ApplicationDbContext _context,UserManager<ApplicationUser> userManager)
        //{
        //    context = _context;
        //    UserManager = userManager; 
        //}
        public utilities()
        {

        }

        public utilities(ApplicationDbContext _context)
        {
            context = _context;
        }
        public utilities(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public utilities(ApplicationDbContext _context, IHostingEnvironment hostingEnvironment)
        {
            context = _context;
            this.hostingEnvironment = hostingEnvironment;
        }
        public utilities(ApplicationDbContext _context, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            context = _context;
            this.hostingEnvironment = hostingEnvironment;
            Configuration = configuration;
        }

        //For Uploading Image
        public string ProcessPhotoproperty(IFormFile Photo)
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadedfile = Path.Combine(hostingEnvironment.WebRootPath, "Image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filepath = Path.Combine(uploadedfile, uniqueFileName);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    Photo.CopyTo(filestream);
                }
            }

            return uniqueFileName;
        }

        //To Check Available Stock of Single Product
        public bool checkingQuantitySingleProduct(int modelId, int quantitySelected, int StoreId)
        {
            var result = context.Stock.Select(x=> new { x.modelId,x.Quantity,x.store_id}).FirstOrDefault(x => x.modelId == modelId && x.store_id == StoreId);
            if(result != null)
            {
                if(result.Quantity - quantitySelected >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        //To Check Available Stock
        public List<Tuple<int, bool>> checkingquantity(List<Products> Items, int StoreId)
        {
            List<Tuple<int, bool>> qty = new List<Tuple<int, bool>>();
            var result = context.Stock.Select(x => new { x.modelId, x.Quantity, x.store_id }).Where(x => Items.Select(p => p.modelId).Contains(x.modelId) && x.store_id == StoreId).ToList();
            if (result == null) throw new Exception();
            foreach (var item in result)
            {
                int quan = item.Quantity;
                int quantitySelected = Items.FirstOrDefault(x => x.modelId == item.modelId).Quantity;
                if (quan - quantitySelected >= 0)
                {
                    qty.Add(new Tuple<int, bool>(item.modelId, true));
                }
                else
                {
                    qty.Add(new Tuple<int, bool>(item.modelId, false));
                }
            }
            return qty;
        }

        public bool updateSingleQuantity(int modelId,int quantitySelected, int StoreId, string operation)
        {
            try
            {
                var result = context.Stock.FirstOrDefault(x => x.modelId == modelId && x.store_id == StoreId);
                if(result != null)
                {
                    if (operation == "Add")
                    {
                        result.Quantity += quantitySelected;
                    }
                    else if (operation == "Subtract")
                    {
                        result.Quantity -= quantitySelected;
                    }
                    context.Stock.Attach(result);
                    context.Entry(result).Property("Quantity").IsModified = true;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        //Updating Stock after Successfull Order
        //Note : This Method just Update Quantity and never check whether that stock is exist or not
        public bool updatequan(List<Products> Items, int StoreId, string operation)
        {
            try
            {

                var result = context.Stock.Select(x => new Stock()
                {
                    id= x.id,
                    modelId = x.modelId,
                    Quantity = x.Quantity,
                    store_id = x.store_id
                }).Where(x=> Items.Select(p => p.modelId).Contains(x.modelId) && x.store_id==StoreId).ToList();

                //Debugging Require For this Line
                if (result.Count != Items.Count) throw new Exception();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        if (operation == "Add")
                        {
                            item.Quantity += Items.FirstOrDefault(x => x.modelId == item.modelId).Quantity;
                        }
                        else if (operation == "Subtract")
                        {
                            item.Quantity -= Items.FirstOrDefault(x => x.modelId == item.modelId).Quantity;
                        }
                    }

                    context.Stock.UpdateRange(result);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        //Get List of Companies
        public List<CompanyViewModel> GetAllCompany()
        {
            var result = context.CompanyModel.Where(x => x.isActive == true).Select(x => new CompanyViewModel()
            {
                Phoneid = x.Phoneid,
                Com_name = x.Com_name,
                Photopath = x.com_Logo,
                com_country = x.com_country
            }).ToList();
            return result;
        }

        //Get List of all Store
        public List<StoreList> GetAllStores()
        {
            var result = context.Stores.Select(x => new StoreList()
            {
                store_id = x.store_id,
                StoreName = x.StoreName + x.Ref_No
            }).ToList();
            return result;
        }

        //Get List of Model of Company
        public List<modelList> getModelList(int PhoneId)
        {
            var list = context.BrandModel.Where(x => x.PhoneId == PhoneId).Select(x => new modelList()
            {
                modelId = x.modelId,
                model_name = x.model_name
            }).Distinct().OrderBy(i => i.model_name).ToList();
            return list;
        }

        //Get All Cities List
        public List<cities> getCities()
        {
            string file_path = Path.Combine(hostingEnvironment.WebRootPath, "data", "cities.json");

            try
            {

                string file_data = System.IO.File.ReadAllText(file_path, Encoding.UTF8);
                if (string.IsNullOrEmpty(file_data) == true)
                {
                    return null;
                }

                // Get the document
                List<cities> doc = JsonConvert.DeserializeObject<List<cities>>(file_data);
                return doc.OrderBy(x => x.city).ToList();
            }
            catch
            {
                return null;
            }
        }

        //To Generate Unique Cus Ref Number
        public int GenerateCusRef()
        {
            int RefNo = 1;

            if (context.Customer.Any())
            {
                return context.Customer.Max(x => x.CustRef) + 1;
            }
            return RefNo;
        }

        //To Generate Unique  Store Ref Number
        public int GenerateStoreRef(int City)
        {
            int RefNo = 1;
            int count = context.Stores.Count(x => x.City == City);
            if (count >= 1)
            {
                return count + 1;
            }
            return RefNo;
        }

        //Calculate Price Based On Quantity
        public List<Tuple<int, int>> Price(int[] modelIds)
        {
            var result = context.BrandModel.Select(x => new { x.modelId, x.Price }).Where(x => modelIds.Contains(x.modelId)).Select(c => new Tuple<int, int>(c.modelId, c.Price)).ToList();
            return result;
        }

        //Get List of Vendors
        public List<VendorList> GetAllVendors(int PhoneId)
        {
            var list = context.Vendor.Where(x => x.PhoneId == PhoneId).Select(x => new VendorList()
            {
                vendorId = x.ven_id,
                vendor_name = x.ven_name
            }).Distinct().OrderBy(i => i.vendorId).ToList();
            return list;
        }

        //To Remove Old images of Brands
        public bool RemoveImage(int imageId)
        {
            var exist = context.Images.FirstOrDefault(x => x.imageId == imageId);
            if (exist == null)
            {
                return false;
            }
            try
            {
                ModelImages m = new ModelImages()
                {
                    imageId = imageId
                };
                context.Entry(m).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        //Get Nearby StoreId 
        public int getStoreId(double lat1, double lng1)
        {
            double minDistance = double.MaxValue;
            int storeid = 0;
            var stores = context.Stores;
            foreach (var store in stores)
            {
                double distance = Calc(lat1, lng1, store.Lat, store.Lng);
                if (distance < minDistance)
                {
                    storeid = store.store_id;
                    minDistance = distance;
                }
            }
            return storeid;
        }

        //Get Nearby StoreId  by user's city id
        public int getStoreId(int cityId)
        {
            double minDistance = double.MaxValue;
            var citydata = getCities().Select(x => new { x.id, x.lat, x.lng }).FirstOrDefault(x => x.id == cityId);
            int storeid = 0;
            var stores = context.Stores;
            foreach (var store in stores)
            {
                double distance = Calc(citydata.lat, citydata.lng, store.Lat, store.Lng);
                if (distance < minDistance)
                {
                    storeid = store.store_id;
                    minDistance = distance;
                }
            }
            return storeid;

        }

        //Send Mail through Smtp
        public void sendemail(string email, string subject, string body)
        {

            MailMessage message = new MailMessage();

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            message.From = new MailAddress(Configuration["Email"]);
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.IsBodyHtml = true; //to make message body as html  
            //BodyBuilder bodybuilder = new BodyBuilder();
            //bodybuilder.HtmlBody = body;//$"<h2>Here is the Confirmation Link</h2> <a></a>";
            message.Body = body;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential(Configuration["Email"], Configuration["Password"]);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }

        //Calculate Distqnces between two places
        public double Calc(double Lat1,
                  double Long1, double Lat2, double Long2)
        {
            /*
                The Haversine formula according to Dr. Math.
                http://mathforum.org/library/drmath/view/51879.html

                dlon = lon2 - lon1
                dlat = lat2 - lat1
                a = (sin(dlat/2))^2 + cos(lat1) * cos(lat2) * (sin(dlon/2))^2
                c = 2 * atan2(sqrt(a), sqrt(1-a)) 
                d = R * c

                Where
                    * dlon is the change in longitude
                    * dlat is the change in latitude
                    * c is the great circle distance in Radians.
                    * R is the radius of a spherical Earth.
                    * The locations of the two points in 
                        spherical coordinates (longitude and 
                        latitude) are lon1,lat1 and lon2, lat2.
            */
            double dDistance = Double.MinValue;
            double dLat1InRad = Lat1 * (Math.PI / 180.0);
            double dLong1InRad = Long1 * (Math.PI / 180.0);
            double dLat2InRad = Lat2 * (Math.PI / 180.0);
            double dLong2InRad = Long2 * (Math.PI / 180.0);

            double dLongitude = dLong2InRad - dLong1InRad;
            double dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                       Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) *
                       Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Asin(Math.Sqrt(a));

            // Distance.
            // const Double kEarthRadiusMiles = 3956.0;
            const Double kEarthRadiusKms = 6376.5;
            dDistance = kEarthRadiusKms * c;

            return dDistance;
        }

        //Add Notification to DB
        public async Task<bool> AddNotification(NotificationsViewModel model)
        {
            try
            {
                Notifications n = new Notifications()
                {
                    heading = model.heading,
                    Text = model.Text,
                    Url = model.Url,
                    UserId = model.UserId,
                    When = DateTime.Now,
                    read = false,
                };
                await context.Notification.AddAsync(n);
                //await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }


    }
    public struct modelList
    {
        public int modelId { get; set; }
        public string model_name { get; set; }
    }
    public struct VendorList
    {
        public int vendorId { get; set; }
        public string vendor_name { get; set; }
    }
    public struct cities
    {
        public int id { get; set; }
        public string city { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }
    public struct StoreList
    {
        public int store_id { get; set; }
        public string StoreName { get; set; }
    }
}
