using DataLayer.Abstract;
using DataLayer.Concrete.EfCore.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete.EfCore
{
    public class EfCoreImageRepository : EfCoreGenericRepository<Image>, IImageRepository
    {
        public EfCoreImageRepository(AkademiContext _appContext) : base(_appContext)
        {
        }
        AkademiContext AppContext
        {
            get { return _dbContext as AkademiContext; }
        }
    }
}
