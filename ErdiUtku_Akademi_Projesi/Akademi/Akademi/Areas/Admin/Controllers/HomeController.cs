using Akademi.Areas.Admin.Models.ViewModels.Accounts;
using EntityLayer.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Akademi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]

    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly RoleManager<Role> _roleManager;

        public HomeController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }



        public async Task<IActionResult> Index() 
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserViewModel userViewModel = new UserViewModel
            {
               
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            };
                


            return View(userViewModel);
        }




    }
    
}
