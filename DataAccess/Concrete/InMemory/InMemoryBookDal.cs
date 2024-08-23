using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBookDal : InMemoryRepositoryBase<Book>, IBookDal
    {
        protected override List<Book> _entities => _context.Books;

        public InMemoryBookDal(InMemoryContext context) : base(context)
        {
        }
        
        public List<BookDetailDto> GetBookDetails()
        {
            var bookDetails = from book in _context.Books
                              join genre in _context.Genres
                              on book.GenreId equals genre.Id
                              select new BookDetailDto
                              {
                                  BookId = book.Id,
                                  Title = book.Title,
                                  GenreName = genre.Name,
                                  AuthorNames = (from author in _context.Authors
                                                 where book.AuthorIds.Contains(author.Id)
                                                 select author.Name).ToArray()
                              };
            return bookDetails.ToList();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
