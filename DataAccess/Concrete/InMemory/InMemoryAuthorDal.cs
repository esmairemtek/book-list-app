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
    public class InMemoryAuthorDal : InMemoryRepositoryBase<Author>, IAuthorDal
    {
        protected override List<Author> _entities => _context.Authors;
        public InMemoryAuthorDal(InMemoryContext context) : base(context)
        {
            
        }

        public List<AuthorDetailDto> GetAuthorDetails()
        {
            var result = from author in _context.Authors
                        select new AuthorDetailDto
                        {
                            AuthorId = author.Id,
                            Name = author.Name,
                            BirthDate = author.BirthDate,
                            Biography = author.Biography,
                            BookNames = (from book in _context.Books
                                         where book.AuthorIds.Contains(author.Id)
                                         select book.Title).ToArray()
                        };
            return result.ToList();
        }
    }
}
