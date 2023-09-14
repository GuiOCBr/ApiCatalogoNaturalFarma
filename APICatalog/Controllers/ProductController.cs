using APICatalog.Context;
using APICatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    [Route("api/[controller]")] // [Route("api/[controller]/{action}") aqui indica que ele vai olhar o controlador e {} indica uma variavel que representa a action que vai acionar
    [ApiController] // usando isso não preciso usar os FROM versões mais novas não precisa usar o ModelState pois faz automaticamente
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Product.AsNoTracking().ToList(); // retornando todos os produtos

            if(products is null)
            {
                return NotFound("Produtos não encontrados ...");
            }

            return products;
        }

        [HttpGet("{id:int}", Name = "GetProductById")]

        public ActionResult<Product> GetProductById(int id)
        {
            var product = _context.Product.AsNoTracking().FirstOrDefault(p => p.ProductId == id);

            if(product is null)
            {
                return NotFound("Produto não cadastrado!");
            }

            return product;
        }

        [HttpPost]
         public ActionResult Post(Product product)
         {
             if(product is null)
             {
                 return BadRequest("Informe os dados que deseja alterar corretamente!");
             }

             _context.Product.Add(product);
             _context.SaveChanges();

             return new CreatedAtRouteResult("GetProductById", new { id = product.ProductId }, product);
         }
        
         [HttpPut("{id:int}")]

         public ActionResult Put(int id, Product product)
         {
             if(id != product.ProductId)
             {
                 return BadRequest("Informe os dados que deseja alterar corretamente!");
             }

             _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
             _context.SaveChanges();

             return Ok(product);
         }

         [HttpDelete("{id:int}")]

         public ActionResult Delete(int id)
         {
             var product = _context.Product.AsNoTracking().FirstOrDefault(p => p.ProductId == id);
             // var product = _context.Product.Find(id)

             if(product is null)
             {
                 return NotFound("Produto não localizado ...");
             }

             _context.Product.Remove(product);
             _context.SaveChanges();

             return Ok(product);
         }

    }
}
