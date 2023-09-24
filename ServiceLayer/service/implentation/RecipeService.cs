using Domainlayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using RepositoryLayer;
using ServiceLayer.service.contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.implentation
{
    public class RecipeService : Interface1
    {
        private readonly DataContext _context;
        public RecipeService(DataContext context) { 

            _context= context;
               
        }

        public async Task<ActionResult<List<Recipes>>> Add(Recipes recipe)
        {
            _context.Allrecipes.Add(recipe);
            await _context.SaveChangesAsync();

            return (await _context.Allrecipes.ToListAsync());
        }

        public async Task<ActionResult<List<Recipes>>> Delete(int id)
        {
            var dbrecipe = await _context.Allrecipes.FindAsync(id);
            if (dbrecipe is not null)
            {

                _context.Allrecipes.Remove(dbrecipe);
                await _context.SaveChangesAsync();

                return (await _context.Allrecipes.ToListAsync());
            }
            return (await _context.Allrecipes.ToListAsync());

        }



        public async Task<ActionResult<List<Recipes>>> Get()
        {
            return (await _context.Allrecipes.ToListAsync());
        }

        

        public async Task<ActionResult<IEnumerable<Recipes>>> search(string Name)
        {
            IQueryable<Recipes> query = _context.Allrecipes;
            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(a => a.Name.Contains(Name));

            }
            return await query.ToListAsync();

        }

        public async Task<ActionResult<List<Recipes>>> Update(Recipes request)
        {
             var recipe = await _context.Allrecipes.FindAsync(request.Id);

                if (recipe is not null)
                {
                    recipe.Name = request.Name;
                    recipe.Steps = request.Steps;
                    recipe.Ingredients = request.Ingredients;
                    recipe.Category = request.Category;

                    return await _context.Allrecipes.ToListAsync();


                }
             return await _context.Allrecipes.ToListAsync();




        }



    }
}
