using MVC_BLL.InterfaceRepository;
using MVC_BLL.Repositories;
using MVC_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BLL
{
    public class UnitOfWork : IUnit_Of_Work
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            employeeRepository = new EmployeeRepository(_dbContext);
            departmentRepository = new DepartmentRepository(_dbContext);
        }

        public IEmployeeRepository employeeRepository { get ; set; }
        public IDepartmentRepository departmentRepository { get ; set ; }

        public async Task<int> CompleteAsync()
        {
          return  await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
           _dbContext.Dispose();
        }
    }
}
