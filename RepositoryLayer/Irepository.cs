using Domainlayer;
using Domainlayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable <T> GetAll(string include = "");
        T Get(int id);
        void Insert(T entity);
      
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
        void Updatex(Recipes r);

       
      
    }
}
