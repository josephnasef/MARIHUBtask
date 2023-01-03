using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.DTO.DTOs
{
    public class OrderDeatailsDTO
    {
        public int ID { get; set; }
        public string productName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderId { get; set; }
    }
}
