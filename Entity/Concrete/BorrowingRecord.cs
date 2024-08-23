using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class BorrowingRecord : IEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}