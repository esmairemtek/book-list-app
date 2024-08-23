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
    public class InMemoryUserDal : InMemoryRepositoryBase<User>, IUserDal
    {
        public InMemoryUserDal(InMemoryContext context) : base(context)
        {
        }

        protected override List<User> _entities => throw new NotImplementedException();
    }
}
