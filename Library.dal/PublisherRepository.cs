using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.dal
{
    public class PublisherRepository : Repository<Publisher>
    {
        public PublisherRepository(LibContext context) : base(context)
        {
        }

        public override IQueryable<Publisher> Get()
        {
            return dbSet.Include(p => p.Books).ThenInclude(p => p.Authors).ThenInclude(p => p.Author);
        }
        public override Publisher Get(int id)
        {

            Publisher publisher = Get().FirstOrDefault(x => x.Id == id);
            return dbSet.Find(id);
            
        }
    }
}
