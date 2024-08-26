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
    public class EfAuthorDal : EfEntityRepositoryBase<Author, LibraryContext>, IAuthorDal
    {
        public List<AuthorDetailDto> GetAuthorDetails()
        {
            using (LibraryContext context = new LibraryContext())
            {
                var result = from author in context.Authors
                             select new AuthorDetailDto
                             {
                                 AuthorId = author.Id,
                                 Name = author.Name,
                                 BirthDate = author.BirthDate,
                                 Biography = author.Biography,
                                 BookNames = (from book in context.Books
                                              where book.AuthorIds.Contains(author.Id)
                                              select book.Title).ToArray()
                             };
                return result.ToList();
            }
        }
    }
}
