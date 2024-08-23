using DataAccess.Abstract;
using Entity.Concrete;
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
    }
}
