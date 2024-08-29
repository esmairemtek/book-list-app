using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Details
{
    public class BookListDetailDto : IDto
    {
        public int BookListId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public BookDetailDto[] BookDetails { get; set; }
    }
}
