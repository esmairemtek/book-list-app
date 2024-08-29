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
        //public DbSet<BookGenre> BookGenres { get; set; }
        //public DbSet<BookAuthor> BookAuthors { get; set; }
        //public DbSet<BookListBook> BookListBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Library;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity<Dictionary<string, object>>(
                "BookAuthors",
                j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"));

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books)
                .UsingEntity<Dictionary<string, object>>(
                "BookGenres",
                j => j.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"));

            modelBuilder.Entity<BookList>()
                .HasMany(bl => bl.Books)
                .WithMany(b => b.BookLists)
                .UsingEntity<Dictionary<string, object>> (
                "BookListBooks",
                j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                j => j.HasOne<BookList>().WithMany().HasForeignKey("BookListId"));

            //// many-to-many relationship between Book and Genre
            //modelBuilder.Entity<BookGenre>()
            //    .HasKey(bg => new { bg.BookId, bg.GenreId });

            //modelBuilder.Entity<BookGenre>()
            //    .HasOne(bg => bg.Book)
            //    .WithMany(b => b.BookGenres)
            //    .HasForeignKey(bg => bg.BookId);
            //modelBuilder.Entity<BookGenre>()
            //    .HasOne(bg => bg.Genre)
            //    .WithMany(g => g.BookGenres)
            //    .HasForeignKey(bg => bg.GenreId);

            //// many-to-many relationship between Book and Author
            //modelBuilder.Entity<BookAuthor>()
            //    .HasKey(ba => new { ba.BookId, ba.AuthorId });

            //modelBuilder.Entity<BookAuthor>()
            //    .HasOne(ba => ba.Book)
            //    .WithMany(b => b.BookAuthors)
            //    .HasForeignKey(ba => ba.BookId);

            //modelBuilder.Entity<BookAuthor>()
            //    .HasOne(ba => ba.Author)
            //    .WithMany(a => a.BookAuthors)
            //    .HasForeignKey(ba => ba.AuthorId);

            //// many-to-many relationship between BookList and Book
            //modelBuilder.Entity<BookListBook>()
            //    .HasKey(blb => new { blb.BookListId, blb.BookId });

            //modelBuilder.Entity<BookListBook>()
            //    .HasOne(blb => blb.BookList)
            //    .WithMany(bl => bl.BookListBooks)
            //    .HasForeignKey(blb => blb.BookListId);

            //modelBuilder.Entity<BookListBook>()
            //    .HasOne(blb => blb.Book)
            //    .WithMany(b => b.BookListBooks)
            //    .HasForeignKey(blb => blb.BookId);
        }
    }
}
