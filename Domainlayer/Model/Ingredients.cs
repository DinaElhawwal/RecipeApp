using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Model
{
     public class Ingredients
    {
        [Key]
        public int Id { get; set; }
        public String name { get; set; } = string.Empty;

        [ForeignKey("Recipe_ID")]
        public Recipes Recipe { get; set; }
        public int Recipe_ID { get; set; }
    }
}
