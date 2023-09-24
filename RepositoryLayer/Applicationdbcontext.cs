
using Domainlayer.Model;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Applicationdbcontext : IdentityDbContext<IdentityUser>

    {
        public Applicationdbcontext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            roles(builder);
      
        
        
        }


        private static void roles (ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1",NormalizedName="Admin"},
                 new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                 

                );
        }



    }





    
}
