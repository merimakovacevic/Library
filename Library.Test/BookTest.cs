//using Library.dal;
//using System;
//using System.Linq;
//using Xunit;

//namespace Library.Test
//{
//    public class BookTest
//    {
//        static LibContext context;
//        static IRepository<Book> books;

//        [Fact(DisplayName ="Before all tests")]
//        public void Before()
//        {
//            context = new TestContext();
//            books = new Repository<Book>(context);

//            //context.Database.EnsureDeleted();
//            //context.Database.EnsureCreated();

//            books.Insert(new Book { Title="Book 1"});
//            books.Insert(new Book { Title = "Book 2" });
//            context.SaveChanges();
//        }

//        [Fact(DisplayName ="Count Test")]
//        public void TestBookCount() {
//            context = new TestContext();
//            books = new Repository<Book>(context);
//            //context = new TestContext(); //mora se i ovdje jer su ove dvije metode nezavisne
//            //books = new Repository<Book>(context);

//            int N = books.Get().Count();
//            Assert.Equal(8, N);
//        }

//        [Theory (DisplayName ="Testing Get(id) method")]
//        [InlineData(1, "Book 1")]
//        [InlineData(2, "Book 2")] //test se izvršava onoliko puta koliko smo mu dali indline data
//        public void TestId(int id, string bookTitle)
//        {
//            context = new TestContext();
//            books = new Repository<Book>(context);
//            //Act
//            Book book = books.Get(id);
//            //Assert
//            Assert.Equal(bookTitle, book.Title);
//        }

//        [Fact(Skip="Test insert")]
//        public void TestInsert()
//        {
//            context = new TestContext();
//            books = new Repository<Book>(context);
//            books.Insert(new Book { Title = "My new book" });
//            context.SaveChanges();
//            Assert.Equal(3, books.Get().Count());
//        }

//        //[Fact(DisplayName = "Test delete")]
//        //public void TestDelete()
//        //{
//        //    context = new TestContext();
//        //    books = new Repository<Book>(context);
//        //    books.Delete(3);
//        //    context.SaveChanges();
//        //    Assert.Equal(2, books.Get().Count());
//        //}
//    }
//}
