using Identity.Identity;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class RoleAdminController : Controller
    {

        private RoleManager<IdentityRole> roleManager; // kendimize bir rol manager oluşturduk, IdentityRole tipinde. Bu sefer MyRole sınıfımızı kullanmadık
        private UserManager<MyUser> _userManager;
        public RoleAdminController()
        {
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityDataContext())); // RoleManager bir RoleStore (Custom role modeli generic alır) bekler ve RoleStore'da bir Context bekler
            _userManager = new UserManager<MyUser>(new UserStore<MyUser>(new IdentityDataContext()));
        }
        public ActionResult Index()
        {
            return View(roleManager.Roles);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                var result = roleManager.Create(new IdentityRole(name)); // usermanager'deki gibi değil burada bir IdentityRole nesnesi bekliyor
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item);
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var role = roleManager.FindById(id);
            if (role != null)
            {
                var result = roleManager.Delete(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "Role not found!" });
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var role = roleManager.FindById(id);
            var members = new List<MyUser>();
            var nonMembers = new List<MyUser>();

            foreach (var user in _userManager.Users.ToList())
            {
                var list = _userManager.IsInRole(user.Id, role.Name) ? members : nonMembers; // eğer user role içerisinde varsa members'a yoksa nonMembers'a yolla
                list.Add(user);
            }

            return View(new RoleEditViewModel()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public ActionResult Edit(RoleUpdateViewModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    result = _userManager.AddToRole(userId, model.RoleName); // userId'yi role'e ekler
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    result = _userManager.RemoveFromRole(userId, model.RoleName); // userId'yi role'den siler
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error", new string[] { "aranılan rol bulunamadı" });
        }
    }
}