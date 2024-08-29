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
    public interface IAuthorDal : IEntityRepository<Author>
    {
        public List<AuthorDetailDto> GetAuthorDetails(Expression<Func<Author, bool>> filter = null);
    }
}
