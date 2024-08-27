using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class BookGenre : IEntity
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
       
        // navigation props
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}