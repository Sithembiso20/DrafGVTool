﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralValuationSubs.Controllers
{
  
 public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        /// 
        /// Injecting Role Manager
        /// 
        /// 
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
    }
}