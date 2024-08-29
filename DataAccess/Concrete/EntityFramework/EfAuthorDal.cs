using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Entity.DTOs.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAuthorDal : EfEntityRepositoryBase<Author, LibraryContext>, IAuthorDal
    {
        public EfAuthorDal(LibraryContext context) : base (context)
        {
        }
        public List<AuthorDetailDto> GetAuthorDetails()
        {
            return  _context.Authors
                .Select(author => new AuthorDetailDto
                {
                    AuthorId = author.Id,
                    Name = author.Name,
                    BirthDate = author.BirthDate,
                    Biography = author.Biography,
                    BookNames = author.Books.Select(b => b.Title).ToArray()
                }).ToList();
        }
    }
}
