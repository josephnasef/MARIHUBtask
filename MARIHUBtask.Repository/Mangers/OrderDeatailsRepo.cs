using MARIHUBtask.Domin.Context;
using MARIHUBtask.Domin.Models;
using MARIHUBtask.Repository.Abstraction;
using MARIHUBtask.Repository.Concert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Repository.Mangers
{
    public class OrderDeatailsRepo : Repository<OrderDeatails>, IOrderDeatailsRepo
    {
        public OrderDeatailsRepo(MARIHUBtaskContext MARIHUBtaskContext) : base(MARIHUBtaskContext)
        {
        }
    }
}
