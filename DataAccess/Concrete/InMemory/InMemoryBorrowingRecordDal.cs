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
    public class InMemoryBorrowingRecordDal
        : InMemoryRepositoryBase<BorrowingRecord>, IBorrowingRecordDal
    {
        public InMemoryBorrowingRecordDal(InMemoryContext context) : base(context)
        {
        }

        protected override List<BorrowingRecord> _entities => throw new NotImplementedException();
    }
}
