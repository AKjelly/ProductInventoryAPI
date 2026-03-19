using ProductInventoryAPI.Data;
using ProductInventoryAPI.Model;

namespace ProductInventoryAPI.Repositories
{
    public class ProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()=>_context.Products.ToList();
        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product= _context.Products.Find(id);
            if(product !=null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

    }
}
