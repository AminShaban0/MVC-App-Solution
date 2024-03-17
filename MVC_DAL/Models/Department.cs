using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DAL.Models
{
    public class Department: ModelBase
    {
        
       
        public string Code { get; set; }
        

        public string Name { get; set; }
        
        public DateTime DateOfCreation { get; set; }
        public ICollection<Employee> employees { get; set; }=new HashSet<Employee>();
    }
}
