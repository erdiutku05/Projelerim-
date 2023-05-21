using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICartItemService
    {
        Task ChangeAmountAsync(int cartItemId, int amount);

        Task<CartItem> GetByIdAsync(int Id);

        void Delete(CartItem cartitem);

        void ClearCart(int cartId);
    }
}
