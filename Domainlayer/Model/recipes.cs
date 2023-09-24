//using Microsoft.WindowsAzure.MediaServices.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Model
{
    
   
        public class Recipes 


        {

            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Ingredients> Ingredients { get; set; }
            public string Steps { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;



        }

    
}
