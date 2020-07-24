using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces
{
    public interface ICRUDRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);

    }
}
