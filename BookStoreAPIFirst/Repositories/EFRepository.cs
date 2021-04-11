using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BookStoreAPI.Interface;
using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace BookStoreAPI.Repository
{
  public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
      where TContext : DbContext
      where TEntity : class, IEntity {
    protected readonly TContext context;
    public EfCoreRepository(TContext context) {
      this.context = context;
    }

    public TEntity Add(TEntity entity) {
      context.Set<TEntity>().Add(entity);
      context.SaveChanges();
      return entity;
    }

    public TEntity Delete(int id) {
      var entity = context.Set<TEntity>().Find(id);
      if (entity == null) {
        return entity;
      }

      context.Set<TEntity>().Remove(entity);
      context.SaveChanges();
      return entity;
    }

    public TEntity FindById(int id)
    {
      return context.Set<TEntity>().Find(id);
    }

    public List<TEntity> FindAll()
    {
      return context.Set<TEntity>().ToList();
    }

    public List<TEntity> FindWhere(Func<TEntity, bool> predicate) {
      return context.Set<TEntity>().Where(predicate).ToList();
    }

    public TEntity Update(TEntity entity)
    {
      DetachAll();
      context.Set<TEntity>().Update(entity);
      context.SaveChanges();
      return entity;
    }

    public void DetachAll()
    {
      foreach (EntityEntry dbEntityEntry in context.ChangeTracker.Entries().ToArray())
        if (dbEntityEntry.Entity != null)
          dbEntityEntry.State = EntityState.Detached;
    }

  }
}