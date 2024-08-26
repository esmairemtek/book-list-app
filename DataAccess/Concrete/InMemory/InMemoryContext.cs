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
            new Author
            {
                Id = 1,
                Name = "Isaac Asimov",
                BirthDate = new DateTime(1920, 1, 2),
                Biography = "Isaac Asimov was an American writer and professor of biochemistry, known for his works of science fiction and popular science books. He was a prolific author and is best known for the 'Foundation' and 'Robot' series."
            },
            new Author
            {
                Id = 2,
                Name = "J.R.R. Tolkien",
                BirthDate = new DateTime(1892, 1, 3),
                Biography = "J.R.R. Tolkien was an English writer, poet, philologist, and academic. He is best known for his high fantasy works 'The Hobbit' and 'The Lord of the Rings'."
            },
            new Author
            {
                Id = 3,
                Name = "Agatha Christie",
                BirthDate = new DateTime(1890, 9, 15),
                Biography = "Agatha Christie was an English writer known for her 66 detective novels and 14 short story collections, particularly those revolving around fictional detectives Hercule Poirot and Miss Marple."
            },
            new Author
            {
                Id = 4,
                Name = "Arthur C. Clarke",
                BirthDate = new DateTime(1917, 12, 16),
                Biography = "Arthur C. Clarke was a British science fiction writer, futurist, and inventor. He is best known for his novel '2001: A Space Odyssey', which was developed concurrently with the Stanley Kubrick film."
            },
            new Author
            {
                Id = 5,
                Name = "H.G. Wells",
                BirthDate = new DateTime(1866, 9, 21),
                Biography = "H.G. Wells was an English writer best known for his works of science fiction, including 'The War of the Worlds', 'The Time Machine', and 'The Invisible Man'."
            },
            new Author
            {
                Id = 6,
                Name = "George Orwell",
                BirthDate = new DateTime(1903, 6, 25),
                Biography = "George Orwell was an English novelist, essayist, and critic. He is best known for his dystopian novels '1984' and 'Animal Farm'."
            },

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
