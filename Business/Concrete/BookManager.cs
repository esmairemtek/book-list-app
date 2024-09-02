using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Details;
using Entity.DTOs.Requests.Book;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal  _bookDal;
        IMapper _mapper;
        IAuthorService _authorService;
        IGenreService _genreService;

        public BookManager(IBookDal bookDal, IAuthorService authorService, IGenreService genreService, IMapper mapper)
        {
            _bookDal = bookDal;
            _mapper = mapper;
            _authorService = authorService;
            _genreService = genreService;
        }

        public IResult Add(AddBookRequest request)
        {
            IResult result = BusinessRules.Run(CheckIfBookAlreadyExists(request.Title, request.AuthorIds),
            CheckIfAuthorsExist(request.AuthorIds));
            //CheckIfGenresExist(request.GenreIds));

            if (result != null)
            {
                return result;
            }

            var book = new Book
            {
                Title = request.Title,
                PublishDate = request.PublishDate,
                Authors = request.AuthorIds.Select(id => _authorService.GetById(id).Data).ToList(),
                Genres = request.GenreIds.Select(id => _genreService.GetById(id).Data).ToList()
            };
            _bookDal.Add(book);

            return new SuccessResult(Messages.BookAdded);
        }

        public IResult Update(UpdateBookRequest request)
        {
            IResult result = BusinessRules.Run(CheckIfBookExists(request.Id));
            
            if (result != null)
            {
                return result;
            }

            var book = _bookDal.Get(b => b.Id == request.Id);
            
            book.Title = request.Title ?? book.Title;
            book.PublishDate = request.PublishDate ?? book.PublishDate;
            book.Authors = request.AuthorIds.Select(id => _authorService.GetById(id).Data).ToList() ?? book.Authors;
            book.Genres = request.GenreIds.Select(id => _genreService.GetById(id).Data).ToList() ?? book.Genres;

            _bookDal.Update(book);

            return new SuccessResult(Messages.BookUpdated);
        }

        public IResult Delete(int id)
        {
            IResult result = BusinessRules.Run(CheckIfBookExists(id));
            
            if (result != null)
            {
                return result;
            }
            _bookDal.Delete(GetById(id).Data);
            return new SuccessResult(Messages.BookDeleted);
        }

        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        public IDataResult<List<BookDetailDto>> GetAllDto()
        {
            List<BookDetailDto> bookdetails = new List<BookDetailDto>();
            foreach (Book book in GetAll().Data)
            {
                bookdetails.Add(_mapper.Map<BookDetailDto>(book));
            }
            return new SuccessDataResult<List<BookDetailDto>>(bookdetails);
        }

        public IDataResult<Book> GetById(int id)
        {
            IResult result = BusinessRules.Run(CheckIfBookExists(id));

            if (result != null)
            {
                return new ErrorDataResult<Book>(result.Message);
            }

            return new SuccessDataResult<Book>(_bookDal.Get(b => b.Id == id));
        }

        public IDataResult<BookDetailDto> GetDtoById(int id)
        {
            IDataResult<Book> result = GetById(id);
            BookDetailDto bookDetail = _mapper.Map<BookDetailDto>(result.Data);

            if (result.Success)
            {
                return new SuccessDataResult<BookDetailDto>(bookDetail);
            }

            return new ErrorDataResult<BookDetailDto>(result.Message);
        }
         
        public IDataResult<List<Book>> GetByAuthorId(int id)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.Authors.Any(a => a.Id == id)));
        }

        public IDataResult<List<BookDetailDto>> GetDtoByAuthorId(int id)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_mapper.Map<List<BookDetailDto>>(GetByAuthorId(id)));
        }

        public IDataResult<List<Book>> GetByGenreId(int id)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.Genres.Any(g => g.Id == id)));
        }

        public IDataResult<List<BookDetailDto>> GetDtoByGenreId(int id)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_mapper.Map<List<BookDetailDto>>(GetByGenreId(id)));
        }

        private IResult CheckIfBookAlreadyExists(string title, int[] authorIds)
        {
            var result = _bookDal.GetAll(b => 
            b.Title == title &&
            b.Authors.Count == authorIds.Length &&
            b.Authors.All(a => authorIds.Any(id => id == a.Id))).Any();
            
            if (result)
            {
                return new ErrorResult(Messages.BookAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfBookExists(int id)
        {
            var result = _bookDal.Get(b => b.Id == id);
            if (result == null)
            {
                return new ErrorResult(Messages.BookNotFound);
            }
            return new SuccessResult();
        }

        private IResult CheckIfAuthorsExist(int[] authorIds)
        {
            foreach (int authorId in authorIds)
            {
                var author = _authorService.GetById(authorId).Data;
                if (author == null)
                {
                    return new ErrorResult(Messages.AuthorNotFound);
                }
            }
            return new SuccessResult();
        }
    }
}
