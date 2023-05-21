using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICartService
    {
        Task InitializeCart(string userId);

        Task AddToCart(string userId, int advertId, int amount);

        Task<Cart> GetByIdAsync(int id);

        Task<Cart> GetCartByUserId(string userId);

    }
}
