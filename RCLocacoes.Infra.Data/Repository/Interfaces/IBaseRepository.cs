using RCLocacoes.Domain.Entities;
using System.Linq.Expressions;

namespace RCLocacoes.Infra.Data.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseModel
    {
        void Add(TEntity obj);
        void Delete(TEntity obj);
        IQueryable<TEntity> FilteredList(Expression<Func<TEntity, bool>> query);
        TEntity GetFirstByExp(Expression<Func<TEntity, bool>> query);
        IQueryable<TEntity> List();
        void Update(TEntity obj);
    }
}