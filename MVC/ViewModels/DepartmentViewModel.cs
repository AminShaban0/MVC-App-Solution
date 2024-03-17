using MVC_DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace MVC_BL.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code Of Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name Of Required")]

        public string Name { get; set; }
        [Display(Name = "Date Of Creation")]
        public DateTime DateOfCreation { get; set; }
        public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();
    }
}
