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
        public DateOnly PublishDate { get; set; }
        
        // navigation properties
        public ICollection<Genre> Genres { get; set; } 
        public ICollection<Author> Authors { get; set; }
        public ICollection<BookList> BookLists { get; set; }
    }
}
