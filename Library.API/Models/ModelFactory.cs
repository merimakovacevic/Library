using Library.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class ModelFactory
    {
        public PublisherModel Create(Publisher publisher)
        {
            return new PublisherModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
                City = publisher.City,
                Country = publisher.Country,
                ZipCode = publisher.ZipCode,
                Road = publisher.Road,
                Books = publisher.Books.Select(x => new MasterModel { Id = x.Id , Name = x.Title }).ToList()  //uzima iz publishera listu knjiga i za svakog od tih objekata selektuje samo id i title i od toga pravi listu
            };
        }
    }
}
