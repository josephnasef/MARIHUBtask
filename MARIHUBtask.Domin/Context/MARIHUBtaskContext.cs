using MARIHUBtask.Domin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Domin.Context
{
    public class MARIHUBtaskContext : IdentityDbContext
    {
        public MARIHUBtaskContext(DbContextOptions<MARIHUBtaskContext> options)
         : base(options)
        {
        }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDeatails> OrderDeatails { get; set; }
    }
}
