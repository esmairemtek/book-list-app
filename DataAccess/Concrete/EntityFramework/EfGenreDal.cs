using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGenreDal : EfEntityRepositoryBase<Genre, LibraryContext>, IGenreDal
    {
        public EfGenreDal(LibraryContext context) : base(context)
        {
        }

        public override Genre Get(Expression<Func<Genre, bool>> filter)
        {
            return _context.Genres
                .Include(g => g.Books)
                .SingleOrDefault(filter);
        }

        public override List<Genre> GetAll(Expression<Func<Genre, bool>> filter = null)
        {
            IQueryable<Genre> query = _context.Genres
                                        .Include(g => g.Books);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }
    }
}
