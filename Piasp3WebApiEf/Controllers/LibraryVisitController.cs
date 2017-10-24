using Piasp3WebApiEf.DAL.Models;
using Piasp3WebApiEf.DAL.Services;
using Piasp3WebApiEf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Piasp3WebApiEf.Controllers
{
    public class LibraryVisitController : ApiController
    {
        readonly IReaderService _readerService;
        readonly IBookService _booksService;
        readonly IAuthorService _authorService;

        public LibraryVisitController( 
            IReaderService readerService,
            IBookService bookService,
            IAuthorService authorService )
        {
            _readerService = readerService;
            _booksService = bookService;
            _authorService = authorService;
        }

        [HttpGet]
        [ResponseType( typeof( BooksDto ) )]
        public IHttpActionResult Choose()
        {
            var books = _booksService.GetAll()
                .Distinct( new BooksEqualityComparer() )
                .ToList();

            var authorIds = books.Select( b => b.AuthorId ).ToList();
            var authors = _authorService.Get( authorIds );

            var bookDtoList = books
                .Select( x => new BookDto
                {
                    Author = CreateAuthorDto( authors, x.AuthorId ),
                    Id = x.Id,
                    Title = x.Title
                } )
                .ToList();

            var response = new BooksDto
            {
                Books = bookDtoList
            };

            return Ok( response );
        }

        private PersonDto CreateAuthorDto( List<Author> authors, int authorId )
        {
            var author = authors.Single( x => x.Id == authorId );

            return new PersonDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };
        }

        class BooksEqualityComparer : IEqualityComparer<Book>
        {
            public bool Equals( Book x, Book y )
            {
                return x.AuthorId == y.AuthorId
                    && x.Title == y.Title;
            }

            public int GetHashCode( Book obj )
            {
                unchecked
                {
                    return obj.AuthorId ^ obj.Title.GetHashCode();
                }
            }
        }
    }
}
