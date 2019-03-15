namespace Shop.Web.Controllers.API
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Shop.Web.Data;

    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProduducts()
        {
            return Ok(this.productRepository.GetAll());
        }
    }
}
