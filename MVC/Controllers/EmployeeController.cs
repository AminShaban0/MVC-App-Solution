using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_BL.Helpers;
using MVC_BL.ViewModels;
using MVC_BLL.InterfaceRepository;
using MVC_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_BL.Controllers
{
	[Authorize]
	public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnit_Of_Work _unitOfWork;
        //private readonly IEmployeeRepository _employeeRepos;

        public EmployeeController(IMapper mapper ,IUnit_Of_Work unit_Of_Work )
        {
            _mapper = mapper;
            _unitOfWork = unit_Of_Work;
            
        }
        public async Task<IActionResult> Index(string SearchInp)
        {
            var employee =Enumerable.Empty<Employee>();
            if (string.IsNullOrEmpty(SearchInp))
                 employee = await _unitOfWork.employeeRepository.GetAllAsync();
            else
                employee =_unitOfWork.employeeRepository.GetEmployeeByName(SearchInp);

            var empmap = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employee);

            return View(empmap);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                string ImageName = DocumentFiles.UplodeFile(employeeVM.Image, "Images");
                employeeVM.ImageName = ImageName;
                var empmap = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                await _unitOfWork.employeeRepository.AddAsync(empmap);
                var count = await _unitOfWork.CompleteAsync();
                if (count > 0)
                    TempData["massage"] = "Employee Is Created";
                else
                    TempData["massage"] = "Employee Is Not Created";

                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);

            //return View();
        }
        public async Task< IActionResult> Details(int? id, string ActionName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();
            var employee =await _unitOfWork.employeeRepository.GetAsync(id.Value);
            if (employee is null)
                return NotFound();
            var empmap =_mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(ActionName, empmap);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, EmployeeViewModel employeeVm)
        {
            if (id != employeeVm.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    string OldPath = employeeVm.ImageName;
                    if(employeeVm.Image is not null)
                    {
                        employeeVm.ImageName =DocumentFiles.UplodeFile(employeeVm.Image , "Images");
                    }
                    var empmap = _mapper.Map<EmployeeViewModel, Employee>(employeeVm);

                    _unitOfWork.employeeRepository.Update(empmap);
                   int count =await _unitOfWork.CompleteAsync();
                    if (count > 0 && !string.IsNullOrEmpty(OldPath)&& employeeVm.Image is not null)
                    {
                        DocumentFiles.DeleteFile(OldPath, "Images");
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employeeVm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            return await Details(id, "Delete");

        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            try
            {

                var empmap = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                _unitOfWork.employeeRepository.Delete(empmap);
               int count =await _unitOfWork.CompleteAsync();
                if (count > 0 && !string.IsNullOrEmpty(employeeVM.ImageName))
                {
                    DocumentFiles.DeleteFile(employeeVM.ImageName, "Images");

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(employeeVM);
            }



        }
    }
}
