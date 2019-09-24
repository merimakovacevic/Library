using Library.dal;
using OfficeOpenXml;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace LibrarySeed
{
    public class Program
    {
        private static ExcelWorksheet rowPublishers;
        private static ExcelWorksheet rowBooks;
        private static ExcelWorksheet rowAuthors;
        private static ExcelWorksheet rowAuthBooks;

        static Dictionary<int, int> dicAuthors = new Dictionary<int, int>();
        static Dictionary<int, int> dicBooks = new Dictionary<int, int>();
        static Dictionary<int, int> dicPublishers = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"C:\Users\merimako\Downloads\Library.xlsx");
            using(ExcelPackage package=new ExcelPackage(file))
            {
                ExcelWorkbook book = package.Workbook;
                rowPublishers = book.Worksheets["Publishers"];
                rowBooks = book.Worksheets["Books"];
                rowAuthors = book.Worksheets["Authors"];
                rowAuthBooks = book.Worksheets["AuthBooks"];

                Console.WriteLine($"Publishers: {rowPublishers.Dimension.Rows} rows: ");
                Console.WriteLine($"Books: {rowBooks.Dimension.Rows} rows: ");
                Console.WriteLine($"Authors: {rowAuthors.Dimension.Rows} rows: ");
                Console.WriteLine($"AuthBooks: {rowAuthBooks.Dimension.Rows} rows: ");

                using (UnitOfWork unit=new UnitOfWork())
                {
                    // IRepository<Publisher> publishers = new Repository<Publisher>(context);
                    /*
                     for (int row = 2; row <= rowPublishers.Dimension.Rows; row++) //indeksiranje tabele u excelu ide od 1 i sve kolone od 1
                     {
                         int oldId = rowPublishers.readInteger(row, 1);
                         Publisher p = new Publisher
                         {
                             Name = rowPublishers.readString(row, 2),
                             Road = rowPublishers.readString(row, 3),
                             ZipCode = rowPublishers.readString(row, 4),
                             City = rowPublishers.readString(row, 5),
                             Country = rowPublishers.readString(row, 6)
                         };
                         unit.Publishers.Insert(p);
                         unit.Save(); //save changes mora između da bi sačuvao novi p.Id u rječnik
                         dicPublishers.Add(oldId, p.Id);

                     }

                     for (int row = 2; row <= rowAuthors.Dimension.Rows; row++)
                     {
                         int oldId = rowAuthors.readInteger(row, 1);
                         Author a = new Author
                         {
                             Name = rowAuthors.readString(row, 2),
                             Image = rowAuthors.readString(row, 3),
                             Biography = rowAuthors.readString(row, 4),
                             Birthday = rowAuthors.readDate(row, 5),
                             Email = rowAuthors.readString(row, 6),
                         };
                         unit.Authors.Insert(a);
                         unit.Save();
                         dicAuthors.Add(oldId, a.Id);
                     }
                     for (int row = 2; row <= rowBooks.Dimension.Rows; row++)
                     {
                         int oldId = rowBooks.readInteger(row, 1);
                         Book b = new Book
                         {
                             Title = rowBooks.readString(row, 2),
                             Description = rowBooks.readString(row, 3),
                             Image = rowBooks.readString(row, 4),
                             Pages = rowBooks.readInteger(row, 5),
                             Price = rowBooks.readDecimal(row, 6),
                         };
                         int oldPubl = rowBooks.readInteger(row, 7);
                         int newPubl = dicPublishers[oldPubl];
                         b.Publisher = unit.Publishers.Get(newPubl);
                         unit.Books.Insert(b);
                         unit.Save();
                         dicBooks.Add(oldId, b.Id);
                     }

                     for (int row = 2; row <= rowAuthBooks.Dimension.Rows; row++)
                     {
                         int oldAuthor = rowAuthBooks.readInteger(row, 2);
                         int oldBook = rowAuthBooks.readInteger(row, 1);
                         AuthBooks ab = new AuthBooks
                         {
                             Book = unit.Books.Get(dicBooks[oldBook]),
                             Author = unit.Authors.Get(dicAuthors[oldAuthor])
                         };
                         unit.AuthBooks.Insert(ab);
                         unit.Save();
                     }
                         */
                    Book b = unit.Books.Get(6);
                    if (b == null)
                    {
                        Console.WriteLine("Podatak ne postoji");
                    }
                    else
                    {
                        unit.Books.Delete(6);
                        unit.Save();
                        Console.WriteLine("Podatak obrisan");
                    }
                }
            }



            Console.WriteLine("Hello World!");
        }
    }
}
