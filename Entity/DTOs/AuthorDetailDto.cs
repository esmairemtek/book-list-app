using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class AuthorDetailDto : IDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Biography { get; set; }
        public string[] BookNames { get; set; }
    }
}
