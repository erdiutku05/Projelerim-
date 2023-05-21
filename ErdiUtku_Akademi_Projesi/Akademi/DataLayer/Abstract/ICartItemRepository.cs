using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        void ClearCart(int cartId);

        Task ChangeAmountAsync(CartItem cartItem, int amount);
    }
}
