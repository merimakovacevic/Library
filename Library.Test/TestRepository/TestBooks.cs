using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Library.dal;
using Xunit;

namespace Library.Test.TestRepository
{
    public class TestBooks
    {
        static LibContext context;
        static IRepository<Book> books;

        // initialize database
        public TestBooks()
        {
            context = new TestContext();
            context.Seed();
            books = new Repository<Book>(context);
        }

        [Fact(DisplayName = "Get all books")]
        public void GetAll()
        {
            var collection = books.Get();
            Assert.Equal(4, collection.Count());
        }

        [Theory(DisplayName = "Get book by id")]
        [InlineData(1)]
        [InlineData(2)]
        public void GetById(int id)
        {
            Book book= books.Get(id);
            Assert.False(book == null);
        }

        [Fact(DisplayName = "Get book by wrong id")]
        public void WrongId()
        {
            Book book = books.Get(10);
            Assert.True(book == null);
        }

        [Fact(DisplayName = "Insert new publisher")]
        public void InsertBook()
        {
            Book b=new Book
            {
                Title = "New book"
            };
            books.Insert(b);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
            Assert.Equal(5, b.Id);
        }

        [Fact(DisplayName = "Update book by id=2")]
        public void UpdateBook()
        {
            int id = 2;
            Book b = new Book
            {
                Id = id,
                Title = "Updated!"
            };
            books.Update(b, id);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
            Assert.Equal("Updated!", b.Title);
        }

        [Fact(DisplayName = "Update book with wrong id")]
        public void WrongUpdate()
        {
            int id = 2;
            Book b = new Book
            {
                Id = 2,
                Title = "Updated!"
            };
            books.Update(b, id + 1);
            int N = context.SaveChanges();
            Assert.Equal(0, N);
        }

        [Fact(DisplayName = "Delete book by id=2")]
        public void DeleteBook()
        {
            books.Delete(2);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
        }

        [Fact(DisplayName = "Delete book with wrong id")]
        public void WrongDelete()
        {
            books.Delete(22);
            int N = context.SaveChanges();
            Assert.Equal(0, N);
        }
    }
}
