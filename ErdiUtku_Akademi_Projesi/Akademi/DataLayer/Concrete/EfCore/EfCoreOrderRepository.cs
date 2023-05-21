using System;
using DataLayer.Abstract;
using DataLayer.Concrete.EfCore;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using DataLayer.Abstract;
using DataLayer.Concrete.EfCore.Context;
using DataLayer.Concrete;

namespace DataLayer.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {

        public EfCoreOrderRepository(AkademiContext _appContext) : base(_appContext)
        {
        }
        AkademiContext AppContext
        {
            get { return _dbContext as AkademiContext; }
        }

        public async Task<List<Order>> GetAllOrdersAsync(string userId = null, bool dateSort = false)
        {
            var orders = AppContext
                        .Orders
                        .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.Advert)
                        .ThenInclude(oi => oi.Teacher)
                        .AsQueryable();
            if (dateSort)
            {
                orders = orders.OrderByDescending(o => o.OrderDate);
            }
            else
            {
                orders = orders.OrderBy(o => o.OrderDate);
            }
            if (!String.IsNullOrEmpty(userId))
            {
                orders = orders.Where(o => o.UserId == userId);
            }
            return await orders.ToListAsync();
        }

        public async Task<List<Order>> SearchOrderByUser(string keyword, bool dateSort = false)
        {
            var orders = AppContext
        .Orders
        .Include(o => o.OrderItems)
        .ThenInclude(oi=> oi.Advert)
        .ThenInclude(oi => oi.Teacher)
        .ThenInclude(u => u.User)
        .ThenInclude(oi => oi.Image)
        .Where(o => o.NormalizedName.Contains(keyword))
        .AsQueryable();
            if (dateSort)
            {
                orders = orders.OrderByDescending(o => o.OrderDate);
            }
            else
            {
                orders = orders.OrderBy(o => o.OrderDate);
            }
            return await orders.ToListAsync();
        }


    }
}

