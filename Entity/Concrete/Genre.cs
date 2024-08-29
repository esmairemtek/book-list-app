﻿using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // navigation prop
        public ICollection<Book> Books { get; set; }
    }
}
