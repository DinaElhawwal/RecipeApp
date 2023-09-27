//using Microsoft.WindowsAzure.MediaServices.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Model
{
    
   
        public class Recipes :BaseEntity


        {

            
         
            public string? recipe_name { get; set; }
            public virtual List<Ingredients> Ingredients { get; set; }
            public string Steps { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;



        }

    
}
