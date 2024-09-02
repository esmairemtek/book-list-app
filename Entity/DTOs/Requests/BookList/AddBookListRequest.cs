using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Requests.BookList
{
    public class AddBookListRequest
    {
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}
