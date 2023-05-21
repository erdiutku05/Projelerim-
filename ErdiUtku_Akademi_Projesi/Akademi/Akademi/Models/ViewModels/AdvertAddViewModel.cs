using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Akademi.Models.ViewModels
{
    public class AdvertAddViewModel
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş bırakılmamalıdır")]
        public string Description { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Fiyat alanı boş bırakılmamalıdır")]
        public decimal? Price { get; set; }

        public List<SelectListItem> SelectBranchList { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
