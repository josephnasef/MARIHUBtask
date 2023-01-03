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
    public class ApplicationUserRepo : Repository<ApplicationUser>, IApplicationUserRepo
    {
        public ApplicationUserRepo(MARIHUBtaskContext MARIHUBtaskContext) : base(MARIHUBtaskContext)
        {
        }
    }
}
