using EntityLayer.Concrete;

namespace Akademi.Areas.Admin.Models.ViewModels
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public List<TeacherViewModel> Teachers { get; set; }
    }
}
