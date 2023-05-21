using Akademi.Areas.Admin.Models.ViewModels;
using Akademi.Models.ViewModels;
using Akademi.Models.ViewModels.AccountModels;
using Akademi.Models.ViewModels.CartModels;
using AspNetCore;
using BusinessLayer.Abstract;
using CoreLayer;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.DependencyResolver;

namespace Akademi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICartService _cartService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IBranchService _branchService;
        private readonly IOrderService _orderService;

        public AccountController(UserManager<User> userManager, IOrderService orderService,SignInManager<User> signInManager, ICartService cartService, IStudentService studentService, ITeacherService teacherService, IBranchService branchService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartService = cartService;
            _studentService = studentService;
            _teacherService = teacherService;
            _branchService = branchService;
            _orderService = orderService;
           
        }


        #region Öğretmen Kayıt ol
        [HttpGet]
        public async Task<IActionResult> TeacherRegister()
        {
            TeacherRegisterViewModel teacherRegisterViewModel = new TeacherRegisterViewModel
            {
                Branches = await _branchService.GetBranchesAsync(true)

            };
            return View(teacherRegisterViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> TeacherRegister(TeacherRegisterViewModel teacherRegisterViewModel)
        {
            if (ModelState.IsValid)
            {

                User user = new User
                {
                    UserName = teacherRegisterViewModel.UserName,
                    Email = teacherRegisterViewModel.Email,
                    FirstName = teacherRegisterViewModel.FirstName,
                    LastName = teacherRegisterViewModel.LastName,
                    Gender = teacherRegisterViewModel.Gender,
                    DateOfBirth = teacherRegisterViewModel.DateOfBirth,
                    City = teacherRegisterViewModel.City,
                    Phone = teacherRegisterViewModel.Phone,
                    Image = new Image
                    {

                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsApproved = true,
                        Url = Jobs.UploadImage(teacherRegisterViewModel.Image)
                    }
                };


                var result = await _userManager.CreateAsync(user, teacherRegisterViewModel.Password);

                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "OGRETMEN");
                    await _cartService.InitializeCart(user.Id);
                    Teacher teacher = new Teacher
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        Graduation = teacherRegisterViewModel.Graduation,
                        User = user,
                        IsApproved = true,
                        UserId = user.Id,
                        Url = Jobs.GetUrl(teacherRegisterViewModel.FirstName + teacherRegisterViewModel.LastName),


                    };

                    await _teacherService.CreateTeacher(teacher, teacherRegisterViewModel.SelectedBranches);
                   

                    return RedirectToAction("Login", "Account");
                }


            }
            teacherRegisterViewModel.Branches = await _branchService.GetBranchesAsync(true);
            
            return View(teacherRegisterViewModel);
        }
        #endregion







        #region Öğrenci Kayıt Ol
        [HttpGet]
        public IActionResult StudentRegister()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> StudentRegister(StudentRegisterViewModel studentregisterViewModel)
        {
            if (ModelState.IsValid)
            {
                if (true)
                {
                    User user = new User
                    {
                        UserName = studentregisterViewModel.UserName,
                        Email = studentregisterViewModel.Email,
                        FirstName = studentregisterViewModel.FirstName,
                        LastName = studentregisterViewModel.LastName,
                        Gender = studentregisterViewModel.Gender,
                        DateOfBirth = studentregisterViewModel.DateOfBirth,
                        City = studentregisterViewModel.City,
                        Phone = studentregisterViewModel.Phone,
                        Image = new Image
                        {
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            IsApproved = true,
                            Url = Jobs.UploadImage(studentregisterViewModel.Image)
                        }
                    };

                    var result = await _userManager.CreateAsync(user, studentregisterViewModel.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "OGRENCI");
                        await _cartService.InitializeCart(user.Id);

                        Student student = new Student
                        {
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            User = user,
                            IsApproved = true,
                            UserId = user.Id,
                            Url = Jobs.GetUrl(studentregisterViewModel.FirstName + studentregisterViewModel.LastName),

                        };
                        await _studentService.CreateStudent(student);

                        //TempData["Message"] = Jobs.CreateMessage("Kayıt İşlemi", "Öğrenci Kaydınız Başarıyla gerçekleşmiştir.", "success");

                        return RedirectToAction("Login", "Account");

                    }
                }
            }
            TempData["Message"] = Jobs.CreateMessage("Hata", "Öğrenci Kayıt sırasında bir hata oluştu,lütfen tekrar deneyiniz.", "danger");
            return View(studentregisterViewModel);
        }

        #endregion

        #region Giriş
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginViewModel.UserName);

                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Bilgileri Hatalı!");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return Redirect(loginViewModel.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Kullanıcı adı ya da Parola hatalı");
            }
            return View(loginViewModel);
        }

        #endregion

        #region Çıkış

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Profil Düzenleme
        [HttpGet]
        public async Task<IActionResult> Manage(string id)
        {
            string name = id;

            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }

            User user = await _userManager.FindByNameAsync(name);

            if (User == null)
            {
                return NotFound();
            }

            List<SelectListItem> genderList = new List<SelectListItem>();

            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = user.Gender == "Kadın" ? true : false
            });

            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = user.Gender == "Erkek" ? true : false
            });
            UserManageViewModel userManageViewModel = new UserManageViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                City = user.City,
                Email = user.Email,
                GenderSelectList = genderList,
            };

            var orderList = await _orderService.GetAllOrdersAsync(user.Id);
            List<OrderViewModel> orders = orderList.Select(o => new OrderViewModel
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                City = o.City,
                
                Email = o.Email,
                Phone = o.Phone,
                OrderDate = o.OrderDate,
                //OrderItems = o.OrderItems.Select(oi => new CartItemViewModel
                //{
                //    CartItemId = oi.Id,
                //    AdvertId=oi.AdvertId,
                //    TeacherName = oi.Advert.Teacher.User.FirstName + oi.Advert.Teacher.User.LastName,
                //    TeacherGraduation=oi.Advert.Teacher.Graduation,
                //    BranchName=oi.Advert.Branch.BranchName,
                //    ItemPrice = oi.Price,
                //    Description=oi.Advert.Description,
                //    Amount = oi.Amount,
                //    ImageUrl = oi.Order.User.Image.Url,
                //    TeacherUrl = oi.Advert.Teacher.Url
                //}).ToList()
            }).ToList();

            userManageViewModel.Orders = orders;
            return View(userManageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(UserManageViewModel userManageViewModel)
        {
            if (userManageViewModel == null) { return NotFound(); }
            User user = await _userManager.FindByIdAsync(userManageViewModel.Id);
            bool logOut = !(user.UserName == userManageViewModel.UserName);
            user.FirstName = userManageViewModel.FirstName;
            user.LastName = userManageViewModel.LastName;
            user.Gender = userManageViewModel.Gender;
            user.UserName = userManageViewModel.UserName;
            user.City = userManageViewModel.City;
            user.Email = userManageViewModel.Email;
            user.DateOfBirth = userManageViewModel.DateOfBirth;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                if (logOut)
                {

                    TempData["Message"] = Jobs.CreateMessage("Başarılı", "Profiliniz başarıyla güncellenmiştir. Kullanıcı adınız değiştiği için yeniden giriş yapmalısınız!", "warning");
                    return RedirectToAction("Logout");
                }
                TempData["Message"] = Jobs.CreateMessage("Başarılı", "Profiliniz başarıyla güncellenmiştir.", "success");
                return Redirect("/Account/Manage/" + user.UserName);
            }

            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = user.Gender == "Erkek" ? true : false
            });

            userManageViewModel.GenderSelectList = genderList;

            return View(userManageViewModel);
        }

        #endregion


    }
}




