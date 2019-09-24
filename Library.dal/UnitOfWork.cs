using System;
using System.Collections.Generic;
using System.Text;

namespace Library.dal
{
    public class UnitOfWork : IDisposable //zato što imamo interfejs mi moramo odradili ovu metodu dispose
    {
        private LibContext _context = new LibContext();
        private IRepository<Author> _authors;
        private BookRepository _books;
        private IRepository<Publisher> _publishers;
        private IRepository<AuthBooks> _authbooks;

        public LibContext Context { get { return _context; } }

        public IRepository<Author> Authors {
            get {
                if (_authors == null) {
                    _authors = new Repository<Author>(_context);
                }
                return _authors;
            }
        }
        public BookRepository Books
        {
            
            //get
            //{
            //    if (_books == null)
            //    {
            //        _books = new Repository<Book>(_context);
            //    }
            //    return _books;
            //}
            get{
                return _books ?? (_books= new BookRepository(_context));
            }
        }

        public IRepository<Publisher> Publishers
        {
            get
            {
                return _publishers ?? (_publishers = new Repository<Publisher>(_context));
            }
        }

        public Boolean Save()
        {
            return (_context.SaveChanges()>0);
        }

        public IRepository<AuthBooks> AuthBooks
        {
            get
            {
                return _authbooks ?? (_authbooks = new Repository<AuthBooks>(_context));
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
