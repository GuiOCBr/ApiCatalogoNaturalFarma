using APICatalog.Context;
using APICatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // ideal sempre definir uma rota diferente 
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
       
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        
        [HttpGet("product")] // ROTA PARA RETORNAR CATEGORIA QUE ESTEJA VINCULADA COM PRODUTOS / METODO INCLUDE FAZ ESSE RELACIONAMENTO

        public ActionResult<IEnumerable<Category>> GetCategoryProduct()
        {
            return _context.Category.Include(p=> p.Products).AsNoTracking().ToList();  
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var category = _context.Category.AsNoTracking().ToList(); 

            if (category is null)
            {
                return NotFound("Categoria não encontrados ...");
            }

            return category;
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]

        public ActionResult<Category> GetProductById(int id)
        {
            var category = _context.Category.AsNoTracking().FirstOrDefault(p => p.CategoryId == id);

            if (category is null)
            {
                return NotFound("Categoria não cadastrado!");
            }

            return Ok(category);
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (category is null)
            {
                return BadRequest("Informe os dados que deseja alterar corretamente!");
            }

            _context.Category.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCategoryById", new { id = category.CategoryId }, category);
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest("Informe os dados que deseja alterar corretamente!");
            }

            _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id)
        {
            var category = _context.Category.FirstOrDefault(p => p.CategoryId == id);
      

            if (category is null)
            {
                return NotFound("Categoria não localizado ...");
            }

            _context.Category.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }

        
    }
}
