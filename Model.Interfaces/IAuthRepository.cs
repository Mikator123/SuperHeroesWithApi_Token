using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces
{
    public interface IAuthRepository<TEntity>
    {
        TEntity Login(TEntity entity);
        void Register(TEntity entity);
    }
}
