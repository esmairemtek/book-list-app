using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookList> BookLists { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Library;Trusted_Connection=true");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BookAuthor>()
        //        .HasKey(ba => new { ba.BookId, ba.AuthorId });

        //    modelBuilder.Entity<BookAuthor>()
        //        .HasOne(ba => ba.Book)
        //        .WithMany(b => b.BookAuthors)
        //        .HasForeignKey(ba => ba.BookId);

        //    modelBuilder.Entity<BookAuthor>()
        //        .HasOne(ba => ba.Author)
        //        .WithMany(a => a.BookAuthors)
        //        .HasForeignKey(ba => ba.AuthorId);

        //    modelBuilder.Entity<Book>()
        //        .HasOne(b => b.Genre)
        //        .WithMany(g => g.Books)
        //        .HasForeignKey(b => b.GenreId);

        //    modelBuilder.Entity<BorrowingRecord>()
        //        .HasOne(br => br.User)
        //        .WithMany(u => u.BorrowingRecords)
        //        .HasForeignKey(br => br.UserId);

        //    modelBuilder.Entity<BorrowingRecord>()
        //        .HasOne(br => br.Book)
        //        .WithMany(b => b.BorrowingRecords)
        //        .HasForeignKey(br => br.BookId);
        //}

    }
}
