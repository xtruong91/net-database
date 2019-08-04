using MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> Get(string id);

        Task Create(Book books);

        Task<bool> Update(string id, Book book);

        Task Remove(Book book);
        Task<bool> Remove(string id);

    }
}
