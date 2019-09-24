using Library.dal;
using System.Linq;
using Xunit;

namespace Library.Test
{
    public class TestPublishers
    {
        static LibContext context;
        static IRepository<Publisher> publishers;

        // initialize database
        public TestPublishers()
        {
            context = new TestContext();
            context.Seed();
            publishers = new Repository<Publisher>(context);
        }

        [Fact(DisplayName = "Get all publishers")]
        public void GetAll()
        {
            var collection = publishers.Get();
            Assert.Equal(2, collection.Count());
        }

        [Theory(DisplayName = "Get publisher by id")]
        [InlineData(1)]
        [InlineData(2)]
        public void GetById(int id)
        {
            Publisher publisher = publishers.Get(id);
            Assert.False(publisher == null);
        }

        [Fact(DisplayName = "Get publisher by wrong id")]
        public void WrongId()
        {
            Publisher publisher = publishers.Get(11);
            Assert.True(publisher == null);
        }

        [Fact(DisplayName = "Insert new publisher")]
        public void InsertPublisher()
        {
            Publisher p = new Publisher
            {
                Name = "New publisher"
            };
            publishers.Insert(p);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
            Assert.Equal(3, p.Id);
        }

        [Fact(DisplayName = "Update publisher by id=2")]
        public void UpdatePublisher()
        {
            int id = 2;
            Publisher p = new Publisher
            {
                Id = id,
                Name = "Updated!"
            };
            publishers.Update(p, id);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
            Assert.Equal("Updated!", p.Name);
        }

        [Fact(DisplayName = "Update publisher with wrong id")]
        public void WrongUpdate()
        {
            int id = 2;
            Publisher p = new Publisher
            {
                Id = 2,
                Name = "Updated!"
            };
            publishers.Update(p, id + 1);
            int N = context.SaveChanges();
            Assert.Equal(0, N);
        }

        [Fact(DisplayName = "Delete publisher by id=2")]
        public void DeletePublisher()
        {
            publishers.Delete(2);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
        }

        [Fact(DisplayName = "Delete publisher with wrong id")]
        public void WrongDelete()
        {
            publishers.Delete(22);
            int N = context.SaveChanges();
            Assert.Equal(0, N);
        }
    }
}
