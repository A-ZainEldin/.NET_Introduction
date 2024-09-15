using ASP.Net.Models;

namespace ASP.Net.repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly Context context;
        public ProductRepo(Context c)
        {
            context = c;
        }

        public void AddProduct(Product product)
        {
            context.products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var x = context.products.FirstOrDefault(a => a.Id == id);
            if (x is not null) { context.products.Remove(x); }
            context.SaveChanges();
        }

        public Product? GetProductById(int id)
        {
            var x = context.products.FirstOrDefault(a => a.Id == id);
            if (x is not null) { return x; }
            else return null;
        }

        public List<Product> GetProducts()
        {
            return context.products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = context.products.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.stock = product.stock;
                context.SaveChanges();
            }
        }
    }
}
