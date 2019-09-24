using Library.dal;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndPublishers
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unit = new UnitOfWork();
            var books = unit.Books.Get().Include(x => x.Publisher);
            foreach(var b in books)
            {
                Console.WriteLine(b.Title + " published by " + b.Publisher.Name);
            }
            //promijeniti gore kod, tj napisati novi, jer imamo novi bookrepository 
        }
    }
}
