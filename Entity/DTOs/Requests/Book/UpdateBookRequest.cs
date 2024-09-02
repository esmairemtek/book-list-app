using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Requests.Book
{
    public class UpdateBookRequest : IDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateOnly? PublishDate { get; set; }
        public int[]? AuthorIds { get; set; }
        public int[]? GenreIds { get; set; }
    }
}
