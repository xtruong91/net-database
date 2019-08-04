using Microsoft.AspNetCore.Mvc;
using MongoDB.Interfaces;
using MongoDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookRepository.GetAll();
        }

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public async Task<Book> Get(string id)
        {
            var book =  await _bookRepository.Get(id);
            return book;
        }

        [HttpPost]
        public Task Create(Book book)
        {
           return  _bookRepository.Create(book);           
        }

        [HttpPut("{id:length(24)}")]
        public Task<bool> Update(string id, Book bookIn)
        {
            var book = _bookRepository.Get(id);
            return _bookRepository.Update(id, bookIn);
        }

        [HttpDelete("{id:length(24)}")]
        public Task<bool> Delete(string id)
        {
            return _bookRepository.Remove(id);
        }
    }
}
