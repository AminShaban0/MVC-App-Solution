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
    public class EmployeeRepository : GenerricRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext):base(dbContext)
        {
            
        }
        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
           return _dbContext.Employees.Where(E=>E.Adress.ToLower().Contains( address.ToLower()));
        }

        public IQueryable<Employee> GetEmployeeByName(string name)
        {
            return _dbContext.Employees.Where(E=>E.Name.ToLower().Contains( name.ToLower()));
        }
    }
}
