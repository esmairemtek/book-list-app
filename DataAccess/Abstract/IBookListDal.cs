using Entity.Concrete;
using Entity.DTOs.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBookListDal : IEntityRepository<BookList>
    {
        List<BookListDetailDto> GetBookListDetails(Expression<Func<BookList, bool>> filter = null);
    }
}
