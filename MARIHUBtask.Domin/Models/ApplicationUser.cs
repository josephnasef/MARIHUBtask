using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Domin.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            orders = new HashSet<Order>();
        }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public int AccountID { get; set; }
        public Account account { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
