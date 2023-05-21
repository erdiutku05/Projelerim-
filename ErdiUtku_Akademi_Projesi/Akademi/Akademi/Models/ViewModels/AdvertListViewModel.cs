namespace Akademi.Models.ViewModels
{
    public class AdvertListViewModel
    {
        public List<AdvertViewModel> Adverts { get; set; }
        public bool ApprovedStatus { get; set; } = true;
    }
}
