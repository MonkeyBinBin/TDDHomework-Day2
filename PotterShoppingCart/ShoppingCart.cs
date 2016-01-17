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

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            if (_products.Count == 1)
            {
                totalPrice = _products.Select(x => x.Price * 1).Sum();
            }
            else if (_products.Count == 2 && _products.Select(o => o.ProductId).Distinct().Count() == 2)
            {
                totalPrice = _products.Select(x => x.Price * 0.95).Sum();
            }
            else if (_products.Count == 3 && _products.Select(o => o.ProductId).Distinct().Count() == 3)
            {
                totalPrice = _products.Select(x => x.Price * 0.9).Sum();
            }
            else if (_products.Count == 4)
            {
                if (_products.Select(o => o.ProductId).Distinct().Count() == 4)
                    totalPrice = _products.Select(x => x.Price * 0.8).Sum();
                else if (_products.Select(o => o.ProductId).Distinct().Count() == 3)
                    totalPrice = _products.Take(3).Select(o => o.Price * 0.9).Sum() + _products.Take(1).Select(o => o.Price * 1).Sum();
            }
            else if (_products.Count == 5)
            {
                if (_products.Select(o => o.ProductId).Distinct().Count() == 5)
                    totalPrice = _products.Select(x => x.Price * 0.75).Sum();
                else if (_products.Select(o => o.ProductId).Distinct().Count() == 3)
                    totalPrice = _products.Take(3).Select(o => o.Price * 0.9).Sum() + _products.Take(2).Select(o => o.Price * 0.95).Sum();
            }
            return totalPrice;
        }

        public void AddProducts(List<Product> products)
        {
            this._products.AddRange(products);
        }
    }
}
