using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly DataContext _context;
        private object recipe;

      //  public object?[]? Name { get; private set; }

        public RecipesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Recipes>>> Get()
        {
            return Ok(await _context.Allrecipes.ToListAsync());
        }

        [HttpGet("{Name}")]
        
        public async Task<ActionResult<Recipes>> Get(string Name)
        {
            var recipe = await _context.Allrecipes.FindAsync(Name);
            if (recipe != null)
                return Ok(recipe);
            return BadRequest("Hero not found.");
        }


        //  public List <Recipes> Search  (string Name)
        //.Where(a => a.Name == Name).ToList();
        

        [HttpPost]
        public async Task<ActionResult<List<Recipes>>> AddHero(Recipes recipe)
        {
            _context.Allrecipes.Add(recipe);
            await _context.SaveChangesAsync();

            return Ok(await _context.Allrecipes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Recipes>>> UpdateHero(Recipes request)
        {
            var dbrecipe = await _context.Allrecipes.FindAsync(request.Name);
            if (dbrecipe == null)
                return BadRequest("Hero not found.");

            dbrecipe.Name = request.Name;
            dbrecipe.Ingredients = request.Ingredients;
            dbrecipe.Steps = request.Steps;
            dbrecipe.Category = request.Category;


            await _context.SaveChangesAsync();

            return Ok(await _context.Allrecipes.ToListAsync());
        }
        [HttpDelete("{Name}")]
        public async Task<ActionResult<List<Recipes>>> Delete(string Name)
        {
            var dbrecipe = await _context.Allrecipes.FindAsync(Name);
            if (dbrecipe == null)
                return BadRequest("Hero not found.");

            _context.Allrecipes.Remove(dbrecipe);
            await _context.SaveChangesAsync();

            return Ok(await _context.Allrecipes.ToListAsync());
        }



    }
}
