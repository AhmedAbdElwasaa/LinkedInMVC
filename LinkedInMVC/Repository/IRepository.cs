using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInMVC.Repository
{
    public interface Repository<TEntity>
    {
        List<TEntity> GetAll();
        
         TEntity GetById(params object[] id);
        TEntity Add(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
    }

}
