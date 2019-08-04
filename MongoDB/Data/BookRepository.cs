using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Interfaces;
using MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly NoteContext _context = null;
        public BookRepository(NoteContext context)
        {
            _context = context;
        }
        public async Task Create(Book book)
        {
            try
            {
                await _context.Books.InsertOneAsync(book);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Book> Get(string id)
        {
            try
            {
                return await _context.Books
                        .Find(book => book.Id == id)
                        .FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            try
            {
                return await _context.Books.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task Remove(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Books.DeleteOneAsync(
                    Builders<Book>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(string id, Book book)
        {
            var filter = Builders<Book>.Filter.Eq(s => s.Id, id);
            var update = Builders<Book>.Update
                            .Set(s => s.Author, book.Author)
                            .Set(s => s.BookName, book.BookName)
                            .Set(s => s.Category, book.Category)
                            .Set(s => s.Price, book.Price);

            try
            {
                UpdateResult actionResult = await _context.Books.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
