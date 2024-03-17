using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BLL.InterfaceRepository
{
    public interface IUnit_Of_Work:IDisposable
    {
        public IEmployeeRepository employeeRepository { get; set; }
        public IDepartmentRepository departmentRepository { get; set; }

        Task<int> CompleteAsync();
    }
}
