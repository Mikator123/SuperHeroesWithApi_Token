using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces
{
    public interface IAuthRepository<TEntity>
    {
        TEntity Login(string login, string password);
        void Register(TEntity entity);
    }
}
