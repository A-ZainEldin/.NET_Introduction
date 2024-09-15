using ASP.Net.Models;

namespace ASP.Net.repo
{
    public interface IProductRepo
    {
        public List<Product> GetProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
