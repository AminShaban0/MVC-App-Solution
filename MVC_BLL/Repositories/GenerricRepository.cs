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
    public class GenerricRepository<T> : IGenericRepository<T>where T:ModelBase 
    {
        private protected readonly AppDbContext _dbContext;

        public GenerricRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T entity)
        {
           await _dbContext.Set<T>().AddAsync(entity);
            
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task< IEnumerable<T>> GetAllAsync()
        {
            if(typeof(T)==typeof (Employee))
                return(IEnumerable<T>) await _dbContext.Employees.Include(E => E.department).AsNoTracking().ToListAsync();
            else
                return await _dbContext.Set<T>().AsNoTracking().ToListAsync();





        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            
        }
    }
}
