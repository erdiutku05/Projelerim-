using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Branch : IBaseEntity
    {
        public int Id { get; set; }

        public string BranchName { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }

        public List<TeacherBranch> TeacherBranches { get; set; }

        public List<Advert> Adverts { get; set; }
    }
}
