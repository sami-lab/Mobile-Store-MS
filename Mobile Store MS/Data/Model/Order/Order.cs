using Mobile_Store_MS.ViewModel.Orders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mobile_Store_MS.Data.Model.Order
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public System.DateTime Date  { get; set; }

        public int cus_id { get; set; }

        [Required]
        public int store_id { get; set; }

        public Status status { get; set; }      
        public string TakenBy { get; set; }

      
        [Required]
        public PaymentMethods PaymentMethod { get; set; }       

        [ForeignKey("TakenBy")]
        public  ApplicationUser user_Model { get; set; }

       
        [ForeignKey("cus_id")]
        public Customer.Customer Cus_model { get; set; }

        [ForeignKey("store_id")]
        public Store.Store Store_Model { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<OrderCharges> Charges { get; set; }
    }
    public class Product
    {
        [Key]
        public int id { get; set; }
   
        public int modelId { get; set; }
        //public int Phoneid { get; set; }
        public int Quantity { get; set; }
        public double price { get; set; }
        public int order_id { get; set; }

        [ForeignKey("modelId")]
        public BrandModel BrandModel { get; set; }

      
       
        [ForeignKey("order_id")]
        public Order Order { get; set; }
    }
    public class OrderCharges
    {
        [Key]
        public int id { get; set; }
        public int order_id { get; set; }
        public string ChargeId { get; set; }
        public int priority { get; set; }

        [ForeignKey("order_id")]
        public Order Order { get; set; }
    }
    public enum Status
    {       
        Pending,
        Processing,
        Completed,       
    }
}
