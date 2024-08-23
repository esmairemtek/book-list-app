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
    public class InMemoryGenreDal : InMemoryRepositoryBase<Genre>, IGenreDal
    {
        protected override List<Genre> _entities => _context.Genres;
        public InMemoryGenreDal(InMemoryContext context) : base(context)
        {
        }
    }
}
