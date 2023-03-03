using Microsoft.EntityFrameworkCore;
using RCLocacoes.Domain.Entities;
using RCLocacoes.Infra.Data.Context;
using RCLocacoes.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            dbSet.Add(obj);
            contexto.SaveChangesAsync();
        }
        public virtual void Delete(TEntity obj)
        {
            dbSet.Remove(obj);
        }
        public virtual void Update(TEntity obj)
        {
            dbSet.Update(obj);
        }
        public virtual IQueryable<TEntity> List()
        {
            return dbSet.AsQueryable();
        }
        public virtual TEntity GetFirstByExp(Expression<Func<TEntity, bool>> query)
        {
            return dbSet.FirstOrDefault(query);
        }
        public virtual IQueryable<TEntity> FilteredList(Expression<Func<TEntity, bool>> query)
        {
            return dbSet.Where(query);
        }
    }
}
