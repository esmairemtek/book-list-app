﻿using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Requests.Genre
{
    public class AddGenreRequest : IDto
    {
        public string Name { get; set; }
    }
}
