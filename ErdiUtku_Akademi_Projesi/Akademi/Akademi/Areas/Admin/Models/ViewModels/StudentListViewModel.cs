using EntityLayer.Concrete;

namespace Akademi.Areas.Admin.Models.ViewModels
{
    public class StudentListViewModel
    {
        public List<StudentViewModel> Students { get; set; }
        public bool ApprovedStatus { get; set; } = true;
    }
}
