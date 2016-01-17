using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        private List<Product> _products = new List<Product>();

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            if (_products.Count == 1)
            {
                totalPrice = _products.Select(x => x.Price * 1).Sum();
            }
            return totalPrice;
        }
        
        public void AddProducts(List<Product> products)
        {
            this._products.AddRange(products);
        }
    }
}
