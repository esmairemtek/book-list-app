using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Details
{
    public class BookDetailDto : IDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string[] GenreNames { get; set; }
        public string[] AuthorNames { get; set; }
        public DateOnly PublishDate { get; set; }
    }
}
