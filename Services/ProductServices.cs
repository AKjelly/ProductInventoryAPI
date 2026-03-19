using ProductInventoryAPI.Model;
using ProductInventoryAPI.Repositories;

namespace ProductInventoryAPI.Services
{
    public class ProductServices
    {
        private readonly ProductRepository _repository;

        public ProductServices(ProductRepository repository)
        {
            _repository = repository;
        }


        public List<Product> GetAll()=>_repository.GetAll();

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Product product) => _repository.Add(product);

        public void Update(Product product) => _repository.Update(product);
        public void Delete(int id)
        {
            _repository.Delete(id);
        }


    }
}
