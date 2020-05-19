﻿using Microsoft.AspNetCore.Mvc;
using Mobile_Store_MS.Data.Model;
using Mobile_Store_MS.Data.Model.Customer;
using Mobile_Store_MS.Data.Model.Order;
using Mobile_Store_MS.ViewModel.ModelsViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.Orders
{
    public class OrderViewModel
     {
        [Display(Name ="Order ID")]
        public int order_id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }
        [Required]
        [Remote(action:"quantityCheck",controller:"Order")]
        public int Quantity { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required(ErrorMessage ="Model Name is Required")]
        [Display(Name = "Model Name")]
        public int modelId { get; set; }

        [Display(Name = "Model Name")]
        public string model_name { get; set; }

        [Display(Name = "Company Name")]
        public string com_Name { get; set; }
        [Display(Name = "Company Name")]
        [Required]
        public int Phoneid { get; set; }

        [Required]
        [Display(Name = "Store Name")]
        public int store_id { get; set; }
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        public string StoreAdress { get; set; }
        public string StorePhone { get; set; }

        //[Required]
        public int cus_id { get; set; }
        [Display(Name = "Customer Name")]
        [Required]
        public string cus_name { get; set; }

        [Display(Name = "Customer Phone")]   
        [RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$",ErrorMessage ="Must be Phone No")]
        [Required]
        public string cus_phone { get; set; }
        
        [Display(Name = "Customer Reference No(Unique)")]
        [RegularExpression(@"^[0-9]*$")]
        [Required]
        public int CustRef { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        [Display(Name = "Complete Address")]
        public string StrretAddress { get; set; }


        public Status? orderStatus { get; set; }
        public string TakenBy { get; set; }

        [Display(Name = "Payment Method")]
        [Required]
        public PaymentMethods Method { get; set; }
        public string stripeToken { get; set; }
        public Address Address { get; set; }
       // public ModelViewModel model { get; set; }      
        //public CustomerViewModel.CustomerViewModel Cus_model { get; set; }
    }
    public enum PaymentMethods
    {
        CashOnDelievery,
        Stripe
    }
   
}
