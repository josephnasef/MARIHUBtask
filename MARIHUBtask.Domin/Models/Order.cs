using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Domin.Models
{
    public class Order
    {
        public Order()
        {
            orderDeatails = new HashSet<OrderDeatails>();
        }
        [Key]
        public int ID { get; set; }
        public DateTime OrderDate{ get; set; }
        public decimal TotalPrice{ get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public int AccountID { get; set; }
        public Account account { get; set; }
        public ICollection<OrderDeatails>  orderDeatails { get; set; }
    }
}
