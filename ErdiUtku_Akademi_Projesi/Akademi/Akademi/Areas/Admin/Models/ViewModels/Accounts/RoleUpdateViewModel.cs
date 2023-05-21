using EntityLayer.Concrete.Identity;

namespace Akademi.Areas.Admin.Models.ViewModels.Accounts
{
    public class RoleUpdateViewModel
    {
        public Role Role { get; set; }
        public List<User> Members { get; set; }
        public List<User> NonMembers { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToRemove { get; set; }
    }
}
