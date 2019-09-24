using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.dal
{
    //book repos da bi sam od sebe pri pozivu pozivu get knjiga uključili i publisheri i autori
    //ovo je polimorfizam, možemo sad nad unitom poziv get koji će povlačiti i publishere koji su FK kao i autore
    //ovo je samo za knjigu jer smo ukjučiti da je book tipa bookrepository
    public class BookRepository : Repository<Book>
    {
        public BookRepository(LibContext context) : base(context)
        {
        }

        public override void Update(Book entity, int id)
        {
            Book old = Get(id);
            if (old != null)
            {
                _context.Entry(old).CurrentValues.SetValues(entity); //svi primitivni tipovi podataka idu regularno, poslije zavrsenog entryja se primjenjuju pointeri u narednoj liniji navedeni


            }
        }

        //public override IQueryable<Book> Get()
        //{
        //    return dbSet.Include(x=>x.Publisher).Include(x=>x.Authors);
        //}
    }
}
