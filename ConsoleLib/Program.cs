using Library.dal;
using System;
using System.Linq;

namespace ConsoleLib
{
    public class Program
    {
        static void Main(string[] args)
        {
            //uz pomoć ovog ubacujemo slogove u bazu podataka
            //uz pomoc using ogranicavamo zivotni vijek context bjekta, on je oslobodio mem prostor nakon vit zagrade na kraju
            using (LibContext context = new LibContext())
            {



                Publisher p = new Publisher();
                Console.Write("Publisher name: ");
                p.Name = Console.ReadLine();
                Console.Write("Adress: ");
                p.Road = Console.ReadLine();
                Console.Write("Zip code ");
                p.ZipCode = Console.ReadLine();
                Console.Write("City ");
                p.City = Console.ReadLine();
                Console.Write("Country: ");
                p.Country = Console.ReadLine();
                context.Publishers.Add(p);

                context.SaveChanges(); //moramo sačuvati promjene da bi se knjiga koju unosimo mogla vezati za ovog publishera

                Book b = new Book();
                Console.Write("Title: ");
                b.Title = Console.ReadLine();
                Console.Write("Image: ");
                b.Image = Console.ReadLine();
                Console.Write("Pages: ");
                b.Pages = int.Parse(Console.ReadLine());
                Console.Write("Price: ");
                b.Price = decimal.Parse(Console.ReadLine());

                Console.Write("Publisher:");
                string pname = Console.ReadLine();
                //Publisher pnew=context.Publishers.Where(x => x.Name == pname).FirstOrDefault(); //vraća kolekciju pa moramo prvi, morali uključiti system linq da bi koristili where
                Publisher pnew = context.Publishers.FirstOrDefault(x => x.Name == pname); //isto znaenje kao prethodna linija
                Console.WriteLine(pname + " " + pnew.Name);
                b.Publisher = pnew;
                context.Books.Add(b);

                //vraća broj uspješnih transakcija
                int n = context.SaveChanges();
                Console.WriteLine("Transactions commited: " + n);
            }
            Console.ReadKey();
        }
    }
}
