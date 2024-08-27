using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class BookListBook : IEntity
    {
        public int BookListId { get; set; }
        public int BookId { get; set; }

        // navigation props
        public BookList BookList { get; set; }
        public Book Book { get; set; }
    }
}