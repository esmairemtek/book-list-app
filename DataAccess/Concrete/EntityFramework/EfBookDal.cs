using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryContext>, IBookDal
    {
        public List<BookDetailDto> GetBookDetails()
        {
            using (LibraryContext context = new LibraryContext())
            {
                var result = from book in context.Books
                             join genre in context.Genres
                             on book.GenreId equals genre.Id
                             select new BookDetailDto
                             {
                                 BookId = book.Id,
                                 Title = book.Title,
                                 GenreName = genre.Name,
                                 AuthorNames = (from author in context.Authors
                                                where book.AuthorIds.Contains(author.Id)
                                                select author.Name).ToArray()
                             };
                return result.ToList();
            }
        }
    }
}
