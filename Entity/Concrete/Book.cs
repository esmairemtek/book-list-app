using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int[] AuthorIds { get; set; }
    }
}
