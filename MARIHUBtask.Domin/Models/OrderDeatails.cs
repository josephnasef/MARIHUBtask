using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Domin.Models
{
    public class OrderDeatails
    {
        [Key]
        public int ID { get; set; }
        public string productName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderID { get; set; }
        public Order order { get; set; }
    }
}
