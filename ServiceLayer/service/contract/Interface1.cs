using Domainlayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.contract
{
    public interface Interface1

    {
       

        
        public Task<ActionResult<List<Recipes>>> Get();
        public Task<ActionResult<IEnumerable<Recipes>>> search(string Name);
        public Task<ActionResult<List<Recipes>>> Add(Recipes recipe);

        public Task<ActionResult<List<Recipes>>>Update(Recipes request);

        public Task<ActionResult<List<Recipes>>> Delete(int id);

     //   public Task<IActionResult> Register(user user);


    }
}
