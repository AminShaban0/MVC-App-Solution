using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_BL.ViewModels;
using MVC_BLL.InterfaceRepository;
using MVC_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_BL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnit_Of_Work _unitofwork;
        //private readonly IDepartmentRepository _departmentRepos;

        public DepartmentController(IMapper mapper ,IUnit_Of_Work unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            //_departmentRepos = departmentRepos;
        }
        public async Task<IActionResult> Index()
        {
            var department =await _unitofwork.departmentRepository.GetAllAsync();
            var depemp = _mapper.Map<IEnumerable< Department>,IEnumerable< DepartmentViewModel>>(department);

            return View(depemp);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel departmentVM)
        {
            if(ModelState.IsValid)
            {
              var depmap=  _mapper.Map<DepartmentViewModel,Department> (departmentVM);
                 await _unitofwork.departmentRepository.AddAsync(depmap);
                int count = await _unitofwork.CompleteAsync();
                if (count > 0)
                    TempData["massage"] = "Department Is Created";
                else
                    TempData["massage"] = "Department Is Not Created";
                return RedirectToAction(nameof(Index));
            }
            return View(departmentVM);

            //return View();
        }
        public async Task<IActionResult> Details( int? id ,string ActionName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();
            var department =await _unitofwork.departmentRepository.GetAsync(id.Value);
            if(department is null)
                return NotFound();
            var depemp = _mapper.Map<Department, DepartmentViewModel>(department);
            return View(ActionName, depemp);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
        
            return await Details( id ,"Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit( [FromRoute]int id ,DepartmentViewModel departmentVM)
        {
            if(id != departmentVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var depmap = _mapper.Map<DepartmentViewModel, Department>(departmentVM);

                    _unitofwork.departmentRepository.Update(depmap);
                    await _unitofwork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }return View(departmentVM);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
           
            return await Details( id ,"Delete");

        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id ,DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.Id)
                return BadRequest();
            try
            {
                var depmap = _mapper.Map<DepartmentViewModel, Department>(departmentVM);

                _unitofwork.departmentRepository.Delete(depmap);
                await _unitofwork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty , ex.Message);
                return View(departmentVM);
            }
           
            

        }

    }
}
