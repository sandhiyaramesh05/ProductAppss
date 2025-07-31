using Microsoft.AspNetCore.Mvc;
using ProductApi.Repository;
using WebAPI.Model;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => Ok(_repository.GetAll());

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            _repository.Add(product);
            _repository.Save();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _repository.GetById(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product updated)
        {
            var existing = _repository.GetById(id);
            if (existing == null) return NotFound();

            existing.Name = updated.Name;
            existing.Price = updated.Price;
            existing.Description = updated.Description;

            _repository.Update(existing);
            _repository.Save();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();

            _repository.Delete(product);
            _repository.Save();

            return Ok(product);
        }
    }
}
