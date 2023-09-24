using Domainlayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryLayer
{
  
 
        public class DataContext :DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options) { }

            public DbSet<Recipes> Allrecipes { get; set; }
         //   public DbSet<user> Users { get; set; }
         }
    }
