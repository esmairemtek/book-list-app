﻿using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Entity.DTOs.Details;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAuthorDal : EfEntityRepositoryBase<Author, LibraryContext>, IAuthorDal
    {
        public EfAuthorDal(LibraryContext context) : base (context)
        {
        }

        public override Author Get(Expression<Func<Author, bool>> filter)
        {
            return _context.Authors
                .Include(a => a.Books)
                .SingleOrDefault(filter);
        }

        public override List<Author> GetAll(Expression<Func<Author, bool>> filter)
        {
            IQueryable<Author> query = _context.Authors
                                        .Include(a => a.Books);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public List<AuthorDetailDto> GetAuthorDetails(Expression<Func<Author, bool>> filter = null)
        {
            var query = _context.Authors.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return  query.Select(author => new AuthorDetailDto
            {
                AuthorId = author.Id,
                Name = author.Name,
                BirthDate = author.BirthDate,
                Biography = author.Biography,
                BookNames = author.Books.Select(b => b.Title).ToArray()
            }).ToList();
        }
    }
}
