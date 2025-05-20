using Entities;
using System.Xml.Linq;

namespace WebApiTestDemo.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                Id=1,
                Name="Acer",
                Price=3200,

            },
            new Product
            {
                Id=2,
                Name="Apple",
                Price=4200,

            }
        };
        public Product Add(Product product)
        {
            _products.Add(product);
            return product;
        }

        public bool Delete(int productId)
        {
            var item = _products.FirstOrDefault(p => p.Id == productId);
            if (item == null) return false;
            return _products.Remove(item);
        }

        public Product? GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        public IEnumerable<Product> GetProducts(int top = 0)
        {
            return top == 0 ? _products : (_products.Count > 0 ? _products.Take(top) : new List<Product>());
        }

        public Product Update(Product product)
        {
            var item = _products.FirstOrDefault(p => p.Id == product.Id);
            if (item != null)
            {
                
                item.Name = product.Name;
                item.Price = product.Price;
            }

            return product;
        }
    }
}
