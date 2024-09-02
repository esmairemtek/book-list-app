using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Details;
using Entity.DTOs.Requests.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<List<BookDetailDto>> GetAllDto();
        IDataResult<Book> GetById(int id);
        IDataResult<BookDetailDto> GetDtoById(int id);
        IDataResult<List<Book>> GetByGenreId(int id);
        IDataResult<List<BookDetailDto>> GetDtoByGenreId(int id);
        IDataResult<List<Book>> GetByAuthorId(int id);
        IDataResult<List<BookDetailDto>> GetDtoByAuthorId(int id);
        IResult Add(AddBookRequest addRequest);
        IResult Update(UpdateBookRequest updateRequest);
        IResult Delete(int id);

    }
}
