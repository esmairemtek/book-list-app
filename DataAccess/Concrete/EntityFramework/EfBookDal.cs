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
                var result = context.Books
                    .Select(book => new BookDetailDto
                    {
                        BookId = book.Id,
                        Title = book.Title,
                        GenreNames = book.BookGenres.Select(bg => bg.Genre.Name).ToArray(),
                        AuthorNames = book.BookAuthors.Select(ba => ba.Author.Name).ToArray(),
                        PublishDate = book.PublishDate
                    }).ToList();
                return result;
            }
        }
    }
}
