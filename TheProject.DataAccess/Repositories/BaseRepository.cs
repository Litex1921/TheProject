using TheProject.DB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TheProject.DataAccess.Repositories
{
 
        public abstract class BaseRepository<T> : IBaseRepository<T>
           where T : BaseEntity
        {
            private TheProjectDbContext Context;

            public DbSet<T> DBSet
            {
                get
                {
                    return Context.Set<T>();
                }
            }

            public BaseRepository() =>
                // this constructor is automatically invoked when the default child constructor is called
                Context = new TheProjectDbContext();

            public List<T> GetAll() => Context.Set<T>().ToList();
            public T GetByID(int id) => Context.Set<T>().Find(id);
            public void Create(T item)
            {
                Context.Set<T>().Add(item);
                Context.SaveChanges();
            }
            public void Update(T item, Func<T, bool> findByIDPredecate)
            {
                var local = Context.Set<T>()
                             .Local
                             .FirstOrDefault(findByIDPredecate);// (f => f.ID == item.ID);
                if (local != null)
                {
                    Context.Entry(local).State = EntityState.Detached;
                }

                Context.Entry(item).State = EntityState.Modified;

                //    Context.Entry(category).State = EntityState.Modified;
                //var entry = Context.Entry(category);
                //Context.Categories.Attach(category);
                //entry.State = EntityState.Modified;
                Context.SaveChanges();
            }
            public bool DeleteByID(int id)
            {
                bool isDeleted = false;
                T dbItem = Context.Set<T>().Find(id);
                if (dbItem != null)
                {
                    Context.Set<T>().Remove(dbItem);
                    int recordsChanged = Context.SaveChanges();
                    isDeleted = recordsChanged > 0;
                }
                return isDeleted;
            }
        }
    }
}
