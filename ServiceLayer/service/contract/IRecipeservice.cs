using Domainlayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.contract
{
   
        public interface IRecipeservice
        {
            IEnumerable<Recipes> GetRecipe();
          
            Recipes GetRecipe(int id);
            void InsertRecipe(Recipes R);
         
            void DeleteRecipe(int id);
            public void updateR(Recipes request);
        }
           


    
}
