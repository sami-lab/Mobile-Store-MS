using Microsoft.AspNetCore.Mvc;
using Mobile_Store_MS.Data.Model;
using Mobile_Store_MS.Data.Model.Vendor;
using Mobile_Store_MS.Data.Model.Store;
using System.ComponentModel.DataAnnotations;
using Mobile_Store_MS.Data;

namespace Mobile_Store_MS.ViewModel.PurchasingViewModel
{
    public class PurchasingViewModel
    {
        [Display(Name = "Purchase ID")]
        public int purchase_id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }
        [Required]
        [Remote(action: "quantityCheck", controller: "Order")]
        public int Quantity { get; set; }

        [Remote(action: "AmountCheck", controller: "Purchasing")]
        public int Amount { get; set; }

        [Required]
        [Display(Name ="Model ID")]
        public int modelId { get; set; }
        [Display(Name = "Model Name")]
        public string modelName { get; set; }

        [Display(Name = "Company Name")]
        public int Phoneid { get; set; }
        [Display(Name ="Company Name")]
        public string Com_name { get; set; }

        [Required(ErrorMessage ="Vendor Name is Required")]
        [Display(Name = "Vendor ID")]
        public int vendor_id { get; set; }
        [Display(Name ="Vendor Name")]
        public string VendorName { get; set; }
        public long VendorPhone { get; set; }

        [Display(Name = "Store Name")]
        [Required]
        public int store_id { get; set; }
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        public string StoreAdress { get; set; }
        public string StorePhone { get; set; }

   
        public string takenBy { get; set; }
        
        public BrandModel Brand_model { get; set; }     
        public Vendor Vendor_Model { get; set; }
        public Mobile_Store_MS.Data.Model.Store.Store Store_Model { get; set; }
    }
}
