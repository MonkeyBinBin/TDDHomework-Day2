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
            List<List<Product>> producsGroup = GetProductsGroups();

            foreach (var group in producsGroup)
            {
                totalPrice += group.Select(o => o.Price * GetDiscount(group.Count())).Sum();
            }

            return totalPrice;
        }

        private double GetDiscount(int episodeCount)
        {
            switch (episodeCount)
            {
                case 2:
                    return 0.95;
                case 3:
                    return 0.9;
                case 4:
                    return 0.8;
                case 5:
                    return 0.75;
                case 1:
                default:
                    return 1;
            }
        }

        private List<List<Product>> GetProductsGroups()
        {
            List<List<Product>> producsGroup = new List<List<Product>>();
            var groups = _products.GroupBy(p => p.ProductId);

            for (int i = 0; i < groups.Max(g => g.Count()); i++)
            {
                producsGroup.Add(new List<Product>());
            }

            foreach (var product in _products.OrderBy(o => o.ProductId))
            {
                foreach (var group in producsGroup)
                {
                    if (!group.Any(o => o.ProductId == product.ProductId))
                    {
                        group.Add(product);
                        break;
                    }
                }
            }
            return producsGroup;
        }

        public void AddProducts(List<Product> products)
        {
            this._products.AddRange(products);
        }
    }
}
