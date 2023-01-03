using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Domin.Models
{
    public class Account
    {
        public Account()
        {
            applicationUsers = new HashSet<ApplicationUser>();
            orders = new HashSet<Order>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }    
        public ICollection<ApplicationUser> applicationUsers { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
