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

    public class RecipeService : IRecipeservice
    {
     
        private  IRepository<Recipes> _reciperepository;

       

        public RecipeService(IRepository<Recipes> Reciperepository)
        {
            _reciperepository = Reciperepository;

        }

         public IEnumerable<Recipes> GetRecipe()
        
        {
            return ( _reciperepository
                .GetAll(include: "Ingredients")
                );
        }

        public Recipes GetRecipe(int id)
        {
            return _reciperepository.Get(id);
        }

        public void InsertRecipe(Recipes R)
        {
            _reciperepository.Insert(R);
        }
      

        public void DeleteRecipe(int id)
        {

            Recipes R = GetRecipe(id);
            _reciperepository.Remove(R);
            _reciperepository.SaveChanges();
        }

        public void updateR (Recipes request)
        {
          _reciperepository.Updatex(request);
            _reciperepository.SaveChanges();
        }

      

    }
}

   