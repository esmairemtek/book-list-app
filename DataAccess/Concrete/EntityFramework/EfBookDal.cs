using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Entity.DTOs.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryContext>, IBookDal
    {
        public EfBookDal(LibraryContext context) : base(context)
        {
        }
        public List<BookDetailDto> GetBookDetails(Expression<Func<Book, bool>> filter = null)
        {
            var query = _context.Books.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            
            return query.Select(book => new BookDetailDto
            {
                BookId = book.Id,
                Title = book.Title,
                GenreNames = book.Genres.Select(g => g.Name).ToArray(),
                AuthorNames = book.Authors.Select(a => a.Name).ToArray(),
                PublishDate = book.PublishDate
            }).ToList();
        }
    }
}
