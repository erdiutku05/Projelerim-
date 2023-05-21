using BusinessLayer.Abstract;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CartItemManager : ICartItemService
    {
        ICartItemRepository _cartItemRepository;


        public CartItemManager(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task ChangeAmountAsync(int cartItemId, int amount)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            await _cartItemRepository.ChangeAmountAsync(cartItem, amount);
        }

        public void ClearCart(int cartId)
        {
            _cartItemRepository.ClearCart(cartId);
        }

        public void Delete(CartItem cartitem)
        {
            _cartItemRepository.Delete(cartitem);
        }

        public async Task<CartItem> GetByIdAsync(int Id)
        {
            return await _cartItemRepository.GetByIdAsync(Id);
        }
    }
}
