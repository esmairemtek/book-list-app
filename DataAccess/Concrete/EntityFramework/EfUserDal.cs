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
    public class EfUserDal : EfEntityRepositoryBase<User, LibraryContext>, IUserDal
    {
        public EfUserDal(LibraryContext context) : base(context)
        {
        }

        public override User Get(Expression<Func<User, bool>> filter)
        {
            return _context.Users
                .Include(u => u.BookLists)
                .SingleOrDefault(filter);
        }

        public override List<User> GetAll(Expression<Func<User, bool>> filter)
        {
            IQueryable<User> query = _context.Users
                                        .Include(u => u.BookLists);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }
    }
}
