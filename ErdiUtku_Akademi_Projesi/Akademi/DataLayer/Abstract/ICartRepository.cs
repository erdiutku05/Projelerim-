using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task AddToCard(string userId, int advertId, int amount);

        Task<Cart> GetCartByUserId(string userId);
    }
}
