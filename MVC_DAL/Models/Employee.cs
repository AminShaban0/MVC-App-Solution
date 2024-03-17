using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DAL.Models
{
    public class Employee : ModelBase
    {
        
       
        public string Name { get; set; }
        
        public int Age { get; set; }
        public string Adress { get; set; }
         
        public decimal Salary { get; set; }
        
        public bool IsActive { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public DateTime HireDate { get; set; }
        public string ImageName { get; set; }

        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        //navigational property
        public Department department { get; set; }
        public int? DepartmentId { get; set; }

    }
}
