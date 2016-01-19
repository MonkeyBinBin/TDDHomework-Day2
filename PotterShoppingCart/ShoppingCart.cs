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
        private readonly Dictionary<int, double> _discount = new Dictionary<int, double>() { { 2, 0.95 }, { 3, 0.9 }, { 4, 0.8 }, { 5, 0.75 }, { 1, 1 } };

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            List<List<Product>> productsGroup = GetProductsGroups();

            foreach (var group in productsGroup)
            {
                totalPrice += group.Select(o => o.Price * GetDiscount(group.Count())).Sum();
            }

            return totalPrice;
        }

        private double GetDiscount(int episodeCount)
        {
            double discount = 1;
            _discount.TryGetValue(episodeCount, out discount);
            return discount;
        }

        private List<List<Product>> GetProductsGroups()
        {
            List<List<Product>> productsGroup = new List<List<Product>>();
            var groups = _products.GroupBy(p => p.ProductId);

            for (int i = 0; i < groups.Max(g => g.Count()); i++)
            {
                productsGroup.Add(new List<Product>());
            }

            foreach (var product in _products.OrderBy(o => o.ProductId))
            {
                foreach (var group in productsGroup)
                {
                    if (!group.Any(o => o.ProductId == product.ProductId))
                    {
                        group.Add(product);
                        break;
                    }
                }
            }
            return productsGroup;
        }

        public void AddProducts(List<Product> products)
        {
            this._products.AddRange(products);
        }
    }
}
