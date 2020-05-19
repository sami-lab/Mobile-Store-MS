using Mobile_Store_MS.ViewModel.Orders;
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
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Amount { get; set; }

        [Required]
        public int modelId { get; set; }

        [Required]
        public int cus_id { get; set; }

        [Required]
        public int store_id { get; set; }

        public Status status { get; set; }      
        public string TakenBy { get; set; }

        [Required]
        public PaymentMethods PaymentMethod { get; set; }       
        public string TransactionId { get; set; }

        [ForeignKey("TakenBy")]
        public  ApplicationUser user_Model { get; set; }

        [ForeignKey("modelId")]
        public BrandModel model { get; set; }

        [ForeignKey("cus_id")]
        public Customer.Customer Cus_model { get; set; }

        [ForeignKey("store_id")]
        public Store.Store Store_Model { get; set; }
    }

    public enum Status
    {       
        Pending,
        Processing,
        Completed,       
    }
}
