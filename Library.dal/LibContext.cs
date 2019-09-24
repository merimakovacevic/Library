using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace Library.dal
{
    public class LibContext: DbContext
    {
        public LibContext() : base() { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<AuthBooks> AuthBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseNpgsql(
                "User ID=postgres;Password=meri2a;" +
                "Server=localhost;Port=5432;Database=library;" +
                "Integrated Security=true;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //ova metoda je overrideana jer hoćemo da nam prikaze u upitima podatke iz baze koji nisu deleted
            builder.Entity<Author>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<Publisher>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<Book>().HasQueryFilter(x => !x.Deleted); //auth books nema jer nije naslijedila atribute od base klase(tj nema deleted flag)

        }

        public override int SaveChanges()
        {
            //da nema ovog dijela koda onda bi podatak bio obrisan,a ovako se postavlja na modified, a u bazi se pise da je deleted=true
            foreach(var entry in ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted && x.Entity is BaseClass)){
                entry.State = EntityState.Modified;
                entry.CurrentValues["Deleted"] = true;
            }
            return base.SaveChanges();
        }


    }
}
