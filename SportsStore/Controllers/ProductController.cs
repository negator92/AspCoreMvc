using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repo)
            => repository = repo;
    }
}