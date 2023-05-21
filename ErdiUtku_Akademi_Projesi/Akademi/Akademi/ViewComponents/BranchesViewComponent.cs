using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Akademi.Models.ViewModels;

namespace Akademi.ViewComponents
{
    public class BranchesViewComponent : ViewComponent
    {
        private IBranchService _branchService;

        public BranchesViewComponent(IBranchService branchService)
        {
            _branchService = branchService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Branch> branches = await _branchService.GetBranchesAsync(true);
            List<BranchViewModel> branchViewModels = new List<BranchViewModel>();

            foreach (var branch in branches)
            {
                branchViewModels.Add(
                     new BranchViewModel
                     {
                         Id=branch.Id,
                         BranchName=branch.BranchName,
                         Description=branch.Description,
                         Url=branch.Url
                     });
            }
            if (RouteData.Values["branchurl"] != null)
            {
                ViewBag.SelectedBranchName = RouteData.Values["branchurl"];
            }
            return View(branchViewModels);
        }
    }
}
