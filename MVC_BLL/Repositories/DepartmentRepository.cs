using Microsoft.EntityFrameworkCore;
using MVC_BLL.InterfaceRepository;
using MVC_DAL.Data;
using MVC_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BLL.Repositories
{
    public class DepartmentRepository :GenerricRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext dbContext):base(dbContext) 
        {
            
        }

    }
}
