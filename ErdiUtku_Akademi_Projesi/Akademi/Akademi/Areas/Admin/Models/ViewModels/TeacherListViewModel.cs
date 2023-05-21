namespace Akademi.Areas.Admin.Models.ViewModels
{
    public class TeacherListViewModel
    {
        public List<TeacherViewModel> Teachers { get; set; }
        public bool ApprovedStatus { get; set; } = true;
    }
}
