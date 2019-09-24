using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Library.dal
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        protected LibContext _context;
        protected DbSet<Entity> dbSet;

        public Repository(LibContext context) //dependency injection
        {
            _context = context;
            dbSet = _context.Set<Entity>();
        }



        public virtual IQueryable<Entity> Get()
        {
            return dbSet;
        }

        public IList<Entity> Get(Func<Entity, bool> where)
        {
            IList<Entity> list;
            IQueryable<Entity> dbQuery = Get();
            list = dbQuery.Where(where).ToList();
            return list;
        }

        public virtual Entity Get(int id)
        {
            Entity entity = dbSet.Find(id);
            return entity;

        }

        public virtual void Insert(Entity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(Entity entity, int id)
        {
            Entity old=Get(id);
            if (old != null) //onda uraid update
            {
                _context.Entry(id).CurrentValues.SetValues(entity);
            }
        }

        public void Delete(int id)
        {
            Entity old = Get(id);
            Delete(old);
        }

        public void Delete(Entity entity)
        {
            dbSet.Remove(entity);
        }
    }
       
}
