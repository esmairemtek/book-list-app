using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class BookAuthor : IEntity
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        // navigation props
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}