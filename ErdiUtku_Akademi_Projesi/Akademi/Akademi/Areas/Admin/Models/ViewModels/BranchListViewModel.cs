namespace Akademi.Areas.Admin.Models.ViewModels.Accounts
{
    public class BranchListViewModel
    {
        public List<BranchViewModel> Branches { get; set; }

        public bool ApprovedStatus { get; set; } = true;
    }
}
