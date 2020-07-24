namespace Model.Interfaces
{
    public interface IAuthRepository<TEntity>
    {
        TEntity Login(TEntity entity);
        void Register(TEntity entity);
    }
}
