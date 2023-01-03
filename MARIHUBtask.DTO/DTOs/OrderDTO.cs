using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.DTO.DTOs
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ApplicationUserId { get; set; }
        public int AccountId { get; set; }
    }
}
