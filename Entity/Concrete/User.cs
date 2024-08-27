using Core.Entity.Abstract;
using Entity.Concrete;

namespace Entity.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }

        // navigation prop
        public ICollection<BookList> BookLists { get; set; }
    }
}
