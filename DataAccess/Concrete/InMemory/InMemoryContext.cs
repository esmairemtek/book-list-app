using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryContext
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }

        public InMemoryContext()
        {
            Genres = new List<Genre>
        {
            new Genre { Id = 1, Name = "Science Fiction" },
            new Genre { Id = 2, Name = "Fantasy" },
            new Genre { Id = 3, Name = "Mystery" },
            new Genre { Id = 4, Name = "Historical Fiction" },
            new Genre { Id = 5, Name = "Thriller" }
        };

            Authors = new List<Author>
        {
            new Author { Id = 1, Name = "Isaac Asimov" },
            new Author { Id = 2, Name = "J.R.R. Tolkien" },
            new Author { Id = 3, Name = "Agatha Christie" },
            new Author { Id = 4, Name = "Arthur C. Clarke" },
            new Author { Id = 5, Name = "H.G. Wells" },
            new Author { Id = 6, Name = "George Orwell" }
        };

            Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Foundation",
                GenreId = 1,
                AuthorIds = new int[] { 1 }
            },
            new Book
            {
                Id = 2,
                Title = "The Hobbit",
                GenreId = 2,
                AuthorIds = new int[] { 2 }
            },
            new Book
            {
                Id = 3,
                Title = "Murder on the Orient Express",
                GenreId = 3,
                AuthorIds = new int[] { 3 }
            },
            new Book
            {
                Id = 4,
                Title = "2001: A Space Odyssey",
                GenreId = 1,
                AuthorIds = new int[] { 4 }
            },
            new Book
            {
                Id = 5,
                Title = "The Time Machine",
                GenreId = 1,
                AuthorIds = new int[] { 5 }
            },
            new Book
            {
                Id = 6,
                Title = "Good Omens",
                GenreId = 2,
                AuthorIds = new int[] { 2, 6 } 
            },
            new Book
            {
                Id = 7,
                Title = "1984",
                GenreId = 5,
                AuthorIds = new int[] { 6 }
            },
            new Book
            {
                Id = 8,
                Title = "The Lord of the Rings",
                GenreId = 2,
                AuthorIds = new int[] { 2 }
            }
        };
        }
    }
}
