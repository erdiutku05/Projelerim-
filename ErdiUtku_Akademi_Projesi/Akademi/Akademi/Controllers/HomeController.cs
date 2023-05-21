using Akademi.Models;
using Akademi.Models.ViewModels;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Akademi.Controllers
{
    public class HomeController : Controller
    {
        private ITeacherService _teacherService;
        private IBranchService _branchService;
        private IAdvertService _advertService;

        public HomeController(ITeacherService teacherService, IBranchService branchService, IAdvertService advertService)
        {
            _teacherService = teacherService;
            _branchService = branchService;
            _advertService = advertService;
        }

        public  IActionResult Index()
        {
            return View();  
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> GetAllTeachers(string branchurl)

        {
            List<Teacher> teachers = await _teacherService.GetAllTeachersFullDataAsync(true, branchurl);

            List<TeacherModel> teacherModelList = new List<TeacherModel>();
            teacherModelList = teachers.Select(t => new TeacherModel
            {
                Id = t.Id,
                FirstName =t.User.FirstName,
                LastName=t.User.LastName,
                Graduation = t.Graduation,
                
                Url = t.Url,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsApproved = t.IsApproved,
                UserId = t.UserId,
                Image=t.User.Image,
               
                Branches = t.TeacherBranches.Select(tb => tb.Branch).ToList(),
                Students = t.TeacherStudents.Select(tb => tb.Student).ToList(),
               


            }).ToList();

            if (RouteData.Values["branchurl"] != null)
            {
                ViewBag.SelectedBranchName = await _branchService.GetBranchNameByUrlAsync(RouteData.Values["branchurl"].ToString());
            }
            return View(teacherModelList);
           

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdverts(AdvertListViewModel advertListViewModel)
        {
            List<Advert> advertList;
            if (advertListViewModel.Adverts == null)
            {
                advertList = await _advertService.GetAllAdvertsAsync(advertListViewModel.ApprovedStatus);
                List<AdvertViewModel> adverts = new List<AdvertViewModel>();
                foreach (var advert in advertList)
                {
                    adverts.Add(new AdvertViewModel
                    {
                        Id = advert.Id,
                        FirstName = advert.Teacher.User.FirstName,
                        LastName = advert.Teacher.User.LastName,
                        CreatedDate = advert.CreatedDate,
                        UpdatedDate = advert.UpdatedDate,
                        IsApproved = advert.IsApproved,
                        Graduation = advert.Teacher.Graduation,
                        Price = advert.Price,
                        Description = advert.Description,
                        Url = advert.Url,
                        Image = advert.Teacher.User.Image,
                        //Teacher=advert.Teacher
                    });
                }
                advertListViewModel.Adverts = adverts;
            }
            return View(advertListViewModel);
        }


        public async Task<IActionResult> TeacherDetails(string url)
        {
            var teacherId = await _teacherService.GetByUrlAsync(url);
            Teacher teacher = await _teacherService.GetTeacherFullDataAsync(teacherId);

            TeacherModel teacherModel = new TeacherModel()
            {
                Id = teacher.Id,
                FirstName = teacher.User.FirstName,
                LastName = teacher.User.LastName,
                Graduation = teacher.Graduation,
                Url = teacher.Url,
                User = teacher.User,
                Branches = teacher.TeacherBranches.Select(t => t.Branch).ToList(),
                Students = teacher.TeacherStudents.Select(t => t.Student).ToList(),
                Image = teacher.User.Image,
            };
            return View(teacherModel);
        }

        [HttpGet]
        public async Task<IActionResult> AdvertDetails(string url)
        {
            var advertId = await _advertService.GetByUrlAsync(url);
            Advert advert = await _advertService.GetAdvertFullDataAsync(advertId);

            AdvertViewModel advertViewModel = new AdvertViewModel()
            {
                Id = advert.Id,
                FirstName = advert.Teacher.User.FirstName,
                LastName = advert.Teacher.User.LastName,
                Graduation = advert.Teacher.Graduation,
                Image = advert.Teacher.User.Image,
                Description = advert.Description,
                Price = advert.Price,
                CreatedDate = advert.CreatedDate,
                UpdatedDate = advert.UpdatedDate,
                Url = advert.Url,
                IsApproved = advert.IsApproved,
                BranchName=advert.Branch.BranchName
                
            };
            return View(advertViewModel);
        }

        



    }
}