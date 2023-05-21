using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete.EfCore.Config
{
    public class TeacherBranchConfig : IEntityTypeConfiguration<TeacherBranch>
    {
        public void Configure(EntityTypeBuilder<TeacherBranch> builder)
        {
            builder.HasKey(tb => new { tb.TeacherId, tb.BranchId });
            builder.HasOne(t => t.Teacher).WithMany(t => t.TeacherBranches).HasForeignKey(t => t.TeacherId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.Branch).WithMany(t => t.TeacherBranches).HasForeignKey(t => t.BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new TeacherBranch { TeacherId = 1, BranchId = 1 },
                new TeacherBranch { TeacherId = 2, BranchId = 2 },
                new TeacherBranch { TeacherId = 3, BranchId = 3 },
                new TeacherBranch { TeacherId = 4, BranchId = 4 },
                new TeacherBranch { TeacherId = 5, BranchId = 5 },
                new TeacherBranch { TeacherId = 6, BranchId = 6 },
                new TeacherBranch { TeacherId = 7, BranchId = 7 },
                new TeacherBranch { TeacherId = 7, BranchId = 8 },
                new TeacherBranch { TeacherId = 7, BranchId = 9 },
                new TeacherBranch { TeacherId = 8, BranchId = 10 }
                );
        }

    }
}
