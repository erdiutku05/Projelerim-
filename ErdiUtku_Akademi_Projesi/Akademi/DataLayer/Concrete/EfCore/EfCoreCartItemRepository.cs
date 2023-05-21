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
    public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem>, ICartItemRepository
    {
        public EfCoreCartItemRepository(AkademiContext _appContext) : base(_appContext)
        {
        }
        AkademiContext AppContext
        {
            get { return _dbContext as AkademiContext; }
        }

        public async Task ChangeAmountAsync(CartItem cartItem, int amount)
        {
            cartItem.Amount = amount;
            AppContext.CartItems.Update(cartItem);
            await AppContext.SaveChangesAsync();
        }

        public void ClearCart(int cartId)
        {
            AppContext
                .CartItems
                .Where(ci => ci.CartId == cartId)
                .ExecuteDelete();
        }
    }
}
