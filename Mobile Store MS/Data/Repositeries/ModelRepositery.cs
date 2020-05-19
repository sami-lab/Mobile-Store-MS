using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Model;
using Mobile_Store_MS.Data.Model.Company;
using Mobile_Store_MS.ViewModel.CompanyViewModel;
using Mobile_Store_MS.ViewModel.ModelsViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Repositeries
{
    public class ModelRepositery : IModelRepositery
    {
        public ApplicationDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;
        utilities util;
        public ModelRepositery(ApplicationDbContext _context, IHostingEnvironment hostingEnvironment)
        {
            context = _context;
            this.hostingEnvironment = hostingEnvironment;
            util = new utilities(context, hostingEnvironment);
        }
        public List<ModelViewModel> GetDetails()
        {
            var result = (from br in context.BrandModel
                          join
                           Ph in context.CompanyModel
                          on br.PhoneId equals Ph.Phoneid
                          select new ModelViewModel()
                          {
                              modelId = br.modelId,
                              model_name = br.model_name,
                              mob_type = br.mob_type,
                              RAM = br.RAM.Substring(0, br.RAM.Length - 2),
                              RAMCapacity = br.RAM.Substring(br.RAM.Length - 2),
                              internal_storage = br.internal_storage.Substring(0, br.internal_storage.Length - 2),
                              ROMCapacity = br.RAM.Substring(br.RAM.Length - 2),
                              Display = br.Display,
                              Battery = br.Battery,
                              Price = br.Price,
                              SimType = br.SimType, //require end
                              back_cam = br.back_cam,
                              Front_Cam = br.Front_Cam,
                              front_flash = br.front_flash,
                              FingerPrint = br.FingerPrint,
                              Networktype = br.Networktype,
                              LaunchDate=br.LaunchDate,
                              ProcessorName= br.ProcessorName,
                              PhoneId = Ph.Phoneid,
                              CompanyName = Ph.Com_name,
                              Android = br.Android,
                              ImageName = (from im in context.Images
                                           where im.modelId == br.modelId
                                           select im.Image_Path).FirstOrDefault()
                          }).ToList();

            return result;
        }

        public ModelViewModel GetDetail(int id)
        {
            var result = (from br in context.BrandModel
                          join
                          Ph in context.CompanyModel
                          on br.PhoneId equals Ph.Phoneid
                          //join im in context.Images
                          //on br.modelId equals im.modelId
                          where br.modelId == id
                          select new ModelViewModel()
                          {
                              modelId = br.modelId,
                              model_name = br.model_name,
                              mob_type = br.mob_type,
                              RAM = br.RAM.Substring(0, br.RAM.Length - 2),
                              RAMCapacity = br.RAM.Substring(br.RAM.Length - 2),
                              internal_storage = br.internal_storage.Substring(0, br.internal_storage.Length - 2),
                              ROMCapacity = br.RAM.Substring(br.RAM.Length - 2),
                              Display = br.Display,
                              Battery = br.Battery,
                              Price = br.Price,                          
                              SimType = br.SimType, //require end
                              back_cam = br.back_cam,
                              Front_Cam = br.Front_Cam,
                              front_flash = br.front_flash,
                              FingerPrint = br.FingerPrint,
                              Networktype = br.Networktype,
                              PhoneId = Ph.Phoneid,
                              CompanyName = Ph.Com_name,
                              LaunchDate=br.LaunchDate,
                              ProcessorName= br.ProcessorName,
                              Android = br.Android,
                              Images = (from im in context.Images
                                        where im.modelId == br.modelId
                                        select new imagesViewModel()
                                        {
                                            imageId = im.imageId,
                                            Image_Path = im.Image_Path,
                                            modelId = im.modelId,
                                        }).ToList()
                          }).FirstOrDefault(x => x.modelId == id);


            return result;
        }
        public int addModel(ModelViewModel model)
        {

            BrandModel m = new BrandModel()
            {
                model_name = model.model_name,
                mob_type = model.mob_type,
                RAM = model.RAM + " " + model.RAMCapacity,
                internal_storage = model.internal_storage + " " + model.ROMCapacity,
                Display = model.Display,
                Battery = model.Battery,
                Price = model.Price,           
                SimType = model.SimType, //require end
                back_cam = model.back_cam,
                Front_Cam = model.Front_Cam,
                front_flash = model.front_flash,
                FingerPrint = model.FingerPrint,
                Networktype = model.Networktype,
                PhoneId = model.PhoneId,
                ProcessorName=model.ProcessorName,
                LaunchDate= model.LaunchDate,
                Android = model.Android
            };
            context.BrandModel.Add(m);
            context.SaveChanges();

            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                // Loop thru each selected file
                foreach (IFormFile photo in model.Photos)
                {
                    // The file must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the injected
                    // IHostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "image");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    ModelImages i = new ModelImages()
                    {
                        modelId = m.modelId,
                        Image_Path =uniqueFileName,
                    };
                    context.Images.Add(i);
                    context.SaveChanges();
                  
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
            }
            return m.modelId;

        }

        public int Update(EditViewModel model)
        {
            BrandModel b = new BrandModel();
            b.modelId = model.modelId;
            b.model_name = model.model_name;
            b.mob_type = model.mob_type;
            b.RAM = model.RAM + " " + model.RAMCapacity;
            b.internal_storage = model.internal_storage + " " + model.ROMCapacity;
            b.Display = model.Display;
            b.Battery = model.Battery;
            b.Price = model.Price;          
            b.SimType = model.SimType;
            b.back_cam = model.back_cam;
            b.Front_Cam = model.Front_Cam;
            b.front_flash = model.front_flash;
            b.FingerPrint = model.FingerPrint;
            b.Networktype = model.Networktype;
            b.LaunchDate = model.LaunchDate;
            b.ProcessorName = model.ProcessorName;
            b.PhoneId = model.PhoneId;
            b.Android = model.Android;

            //Handling Images Uploading  ExistingImages.Length - UpcomingPhotos.Length more Images
            if (model.Photos != null && model.Photos.Count > 0)
            {
                string uniqueFileName = null;
                int length = context.Images.Count(x => x.modelId == model.modelId);
                int ImagesLength = model.Photos.Count;
                if (length + ImagesLength > 4)
                {

                    foreach (IFormFile photo in model.Photos)
                    {
                        if (4 - length == 0)
                        {
                            break;
                        }
                        else
                        {
                            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "image");
                            uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                            ModelImages i = new ModelImages()
                            {
                                modelId = model.modelId,
                                Image_Path = uniqueFileName,
                            };
                            context.Images.Add(i);
                            context.SaveChanges();
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            // Use CopyTo() method provided by IFormFile interface to
                            // copy the file to wwwroot/images folder
                            photo.CopyTo(new FileStream(filePath, FileMode.Create));
                            length++;
                        }
                    }

                }
                else
                {
                    foreach (IFormFile photo in model.Photos)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "image");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        ModelImages i = new ModelImages()
                        {
                            modelId = model.modelId,
                            Image_Path = uniqueFileName,

                        };
                        context.Images.Add(i);
                        context.SaveChanges();
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        // Use CopyTo() method provided by IFormFile interface to
                        // copy the file to wwwroot/images folder
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }
            }
            context.BrandModel.Update(b);
            context.SaveChanges();
            return b.modelId;
        }
        public bool delete(int id)
        {
            try
            {
                BrandModel b = new BrandModel()
                {
                    modelId = id,
                };
                context.Entry(b).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
