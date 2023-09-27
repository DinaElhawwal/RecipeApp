using Domainlayer;
using Domainlayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Applicationdbcontext _context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(Applicationdbcontext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll(string include = "")
        {
            return include == "" ? entities.AsEnumerable() : entities.Include(include).AsEnumerable();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _context.SaveChanges();
        }
       

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }




        public void Updatex(Recipes r)
        {
            var recipe = _context.Recipes.Find(r.Id);

            if (recipe is not null)
            {
                recipe.recipe_name = r.recipe_name;
                recipe.Steps = r.Steps;
                recipe.Ingredients = r.Ingredients;
                recipe.Category = r.Category;
                _context.SaveChanges();


            }
        }

        
    }
}