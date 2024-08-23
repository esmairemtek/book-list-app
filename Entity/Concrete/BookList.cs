using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class BookList : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public int[] BookIds { get; set; }
    }
}
