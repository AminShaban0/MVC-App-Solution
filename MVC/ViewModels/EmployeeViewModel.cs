using MVC_DAL.Models;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace MVC_BL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Max Length Of Name Is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length Of Name Is 5 Chars")]
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        [Range(22, 50)]
        public int Age { get; set; }
        public string Adress { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        public string ImageName { get; set; }
        public IFormFile Image { get; set; }
        //navigational property
        public Department department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
