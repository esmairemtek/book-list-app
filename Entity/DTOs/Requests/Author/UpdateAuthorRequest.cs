using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Requests.Author
{
    public class UpdateAuthorRequest : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? Biography { get; set; }
    }
}
