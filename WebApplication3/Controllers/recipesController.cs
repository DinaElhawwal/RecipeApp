using Domainlayer.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.service.contract;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
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

       