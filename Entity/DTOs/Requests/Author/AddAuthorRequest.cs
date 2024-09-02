using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Requests.Author
{
    public class AddAuthorRequest : IDto
    {
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Biography { get; set; }
    }
}
