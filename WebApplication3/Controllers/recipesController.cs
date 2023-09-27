using Domainlayer.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.service.contract;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeservice _recipeservice;

        // private readonly object DataContext;

        public RecipesController(IRecipeservice recipeservice)
        {
            _recipeservice = recipeservice;
        }



        [HttpGet]
        public ActionResult<List<Recipes>> Get()
        {

            
           
            var result = _recipeservice.GetRecipe().ToList();
            var obj = from rec in result
                      select new Recipes
                      {
                          Category = rec.Category,
                          Id = rec.Id,
                          recipe_name = rec.recipe_name,
                          Steps = rec.Steps,
                          Ingredients = (from ing in rec.Ingredients
                                         select new Ingredients
                                         {
                                             Id = ing.Id,
                                             name = ing.name,
                                             Recipe_ID = ing.Recipe_ID
                                         }).ToList()
                      };
            return Ok(obj);
         
        }
        [HttpGet("{search}")]

        public ActionResult<IEnumerable<Recipes>> search(string name)
        {
            var query = _recipeservice.GetRecipe();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.recipe_name.ToLower().Contains(name.ToLower()));


            }
            return query.ToList();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<List<Recipes>> Add([FromBody]Recipes R)
        {
            _recipeservice.InsertRecipe(R);
            var result = _recipeservice.GetRecipe().ToList();
            var obj = from rec in result
                      select new Recipes
                      {
                          Category = rec.Category,
                          Id = rec.Id,
                          recipe_name = rec.recipe_name,
                          Steps = rec.Steps,
                          Ingredients = (from ing in rec.Ingredients
                                         select new Ingredients
                                         {
                                             Id = ing.Id,
                                             name = ing.name,
                                             Recipe_ID = ing.Recipe_ID
                                         }).ToList()
                      };

            return Ok(obj);
        }

        [HttpPut]

        public ActionResult<List<Recipes>> Edit(Recipes R)
        {

            _recipeservice.updateR(R);
            var result = _recipeservice.GetRecipe().ToList();
            var obj = from rec in result
                      select new Recipes
                      {
                          Category = rec.Category,
                          Id = rec.Id,
                          recipe_name = rec.recipe_name,
                          Steps = rec.Steps,
                          Ingredients = (from ing in rec.Ingredients
                                         select new Ingredients
                                         {
                                             Id = ing.Id,
                                             name = ing.name,
                                             Recipe_ID = ing.Recipe_ID
                                         }).ToList()
                      };

            return Ok(obj);



        }

        [HttpDelete("{id}")]
        public ActionResult<List<Recipes>> Delete(int id)
        {
            _recipeservice.DeleteRecipe(id);
            var result = _recipeservice.GetRecipe().ToList();
            var obj = from rec in result
                      select new Recipes
                      {
                          Category = rec.Category,
                          Id = rec.Id,
                          recipe_name = rec.recipe_name,
                          Steps = rec.Steps,
                          Ingredients = (from ing in rec.Ingredients
                                         select new Ingredients
                                         {
                                             Id = ing.Id,
                                             name = ing.name,
                                             Recipe_ID = ing.Recipe_ID
                                         }).ToList()
                      };

            return Ok(obj);



        }













    }
}

        /**        [HttpPut]
        public async Task<ActionResult<List<Recipe>>> Edit(Recipe R)
        {
            var recipe=this.dataContext.Recipes.Find(R.Id);
            recipe = R;
            this.dataContext.Recipes.Update(recipe);
            await this.dataContext.SaveChangesAsync();

            return Ok(await this.dataContext.Recipes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Recipe>>> Delete(int id)
        {
            var dbrecipe = await this.dataContext.Recipes.FindAsync(id);
            if (dbrecipe == null)
                return BadRequest("recipe not found.");

            this.dataContext.Recipes.Remove(dbrecipe);
            await this.dataContext.SaveChangesAsync();

            return Ok(await this.dataContext.Recipes.ToListAsync());
        }
        //filter by ingredients

        public List<Recipe> filterIngredients(string ingredients)
        {
            ingredients = string.IsNullOrEmpty(ingredients) ? "" : ingredients.ToLower();
            var Lista=ingredients.Split(",");
            List<Recipe>filters =new List<Recipe>();
            var recipes = from R in this.dataContext.Recipes select R;
            foreach(var ingr in Lista)
            {
                recipes=recipes.Where(X => X.ingredients.ToString().ToLower().Contains(ingr));
            }
            return recipes.ToList();
        }
        //search
        public List<Recipe> filter(string nameORingredients)
        {
            nameORingredients = string.IsNullOrEmpty(nameORingredients) ? "" : nameORingredients.ToLower();
            List<Recipe> filters = new List<Recipe>();
            var recipes = (from R in this.dataContext.Recipes where nameORingredients==""||R.Recipe_name.ToLower().Contains(nameORingredients)
            select new Recipe
            {
                Id = R.Id,
                Recipe_name = R.Recipe_name,
                ingredients = R.ingredients,
                steps = R.steps,
            }
            );
            return recipes.ToList();
        }

        
        
        
        
        
        
        
        /*
        private readonly Interface1 _interface;

        public RecipesController(Interface1 interface1)
        {
          _interface= interface1;
            
        }



        [HttpGet]

        public async Task<ActionResult<List<Recipes>>> GetAll()
        {
            return Ok(await _interface.Get());
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Recipes>>> Search(string Name)
        {
            return Ok(await _interface.search(Name));

        }

        [HttpPost]

        public async Task<ActionResult<List<Recipes>>> AddRecipe(Recipes recipe)
        {
            return Ok(await _interface.Add(recipe));
        }

        [HttpPut]
        public async Task<ActionResult<List<Recipes>>> Update(Recipes request)
        {
            return Ok(await _interface.Update(request));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Recipes>>> delete(int id)
        {
            return Ok(await _interface.Delete(id));
        }










    }
}
*/
       