using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Entity.DTOs.Details;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookListDal : EfEntityRepositoryBase<BookList, LibraryContext>, IBookListDal
    {
        IBookDal _bookdal;
        public EfBookListDal(IBookDal bookdal, LibraryContext context) : base(context)
        {
            _bookdal = bookdal;
        }

        public override BookList Get(Expression<Func<BookList, bool>> filter)
        {
            return _context.BookLists
                .Include(bl => bl.User)
                .Include(bl => bl.Books)
                .SingleOrDefault(filter);
        }

        public override List<BookList> GetAll(Expression<Func<BookList, bool>> filter)
        {
            IQueryable<BookList> query = _context.BookLists
                                        .Include(bl => bl.User)
                                        .Include(bl => bl.Books);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public List<BookListDetailDto> GetBookListDetails(Expression<Func<BookList, bool>> filter = null)
        {
                var query = _context.BookLists.AsQueryable();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                return query.Select(booklist => new BookListDetailDto
                {
                    BookListId = booklist.Id,
                    Title = booklist.Title,
                    UserName = $"{booklist.User.FirstName} {booklist.User.LastName}",
                    BookDetails = _bookdal.GetBookDetails(b => booklist.Books.Select(blb => blb.Id).Contains(b.Id)).ToArray()
                }).ToList();
        }
    }
}
