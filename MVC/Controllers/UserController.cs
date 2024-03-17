using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_BL.ViewModels;
using MVC_DAL.Data.Migrations;
using MVC_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_BL.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<MVC_DAL.Models.AccountUser> _userManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<MVC_DAL.Models.AccountUser> userManager , IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
               var users =await _userManager.Users.Select(U=> new UserViewModel()
               {
                   Id =U.Id,
                   FName = U.FName,
                   LName = U.LName,
                   Email = U.Email,
                   PhoneNumber = U.PhoneNumber,
                   Roles =_userManager.GetRolesAsync(U).Result,

               }).ToListAsync();
                return View(users);
            }
            else
            {
                var users =await _userManager.FindByEmailAsync(SearchValue);
                if(users is null)
                {
                    return View(new List<UserViewModel>());
                }
                var usermapper = new UserViewModel ()
                {
                    Id = users.Id,
                    FName = users.FName,
                    LName = users.LName,
                    Email = users.Email,
                    PhoneNumber = users.PhoneNumber,
                    Roles = _userManager.GetRolesAsync(users).Result,

                };
                return View(new List<UserViewModel>() { usermapper });
            }
            
        }
        public async Task<IActionResult> Details(string id , string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
          var user= await _userManager.FindByIdAsync(id);
            if(user is null)
                return NotFound();
            var usermap = _mapper.Map<AccountUser, UserViewModel>(user);
            return View(ViewName , usermap);
        }
        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit( UserViewModel user ,[FromRoute]string id)
        {
            if(id != user.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                  var User=  await _userManager.FindByIdAsync(id);
                    User.FName = user.FName;
                    User.LName = user.LName;
                    User.PhoneNumber = user.PhoneNumber;
                   await _userManager.UpdateAsync(User);
                    return RedirectToAction("Index");
                }catch(Exception  ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(user);
        }
        
        public async Task<IActionResult> Delete(string id)
        {
           return await Details (id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(string Id )
        {
            if(Id is null)
                return BadRequest();
            try
            {
             var user=  await _userManager.FindByIdAsync(Id);
               await _userManager.DeleteAsync(user);
                return RedirectToAction("Index");
            }catch(Exception EX)
            {
                ModelState.AddModelError (string.Empty, EX.Message);
               return RedirectToAction("Error","Home");
            }
        }
    }
}
