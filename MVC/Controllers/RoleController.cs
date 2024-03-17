using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MVC_BL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<IdentityRole> roleManager , IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string SearchInp)
        {
            if (string.IsNullOrEmpty(SearchInp))
            {
                var roles =await _roleManager.Roles.ToListAsync();
               var RoleMap= _mapper.Map<IEnumerable<IdentityRole>,IEnumerable<RoleViewModel>>(roles);
                return View(RoleMap);
            }
            else
            {
                var role =await _roleManager.FindByNameAsync(SearchInp);
                var RoleMap = _mapper.Map<IdentityRole, RoleViewModel>(role);

                return View(new List<RoleViewModel> { RoleMap });
            }
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
          if(ModelState.IsValid)
            {
                var Role = _mapper.Map<RoleViewModel, IdentityRole>(model);
                await _roleManager.CreateAsync(Role);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Details(string id , string ViewName ="Details")
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();
          var role =  await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();
            var rolrmap=_mapper.Map<IdentityRole,RoleViewModel>(role);
            return View(ViewName, rolrmap);
        }
        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel model ,[FromRoute] string id)
        {
            if(id != model.Id) 
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(id);
                    if (role == null)
                        return NotFound();
                    role.Name = model.RoleName;
                    await _roleManager.UpdateAsync(role);
                    return RedirectToAction(nameof(Index));
                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(RoleViewModel model ,string id)
        {
            if (id  != model.Id)
                return BadRequest();
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                    return NotFound();
                await _roleManager.DeleteAsync(role);
                return RedirectToAction(nameof(Index));
            }catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty , ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
