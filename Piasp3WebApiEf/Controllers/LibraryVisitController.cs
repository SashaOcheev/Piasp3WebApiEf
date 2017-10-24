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
    [RoutePrefix( "api/LibraryVisit" )]
    public class LibraryVisitController : ApiController
    {
        readonly IReaderService _readerService;
        readonly IBookService _booksService;
        readonly IAuthorService _authorService;
        readonly ISubscriptionService _subscriptionService;

        public LibraryVisitController(
            IReaderService readerService,
            IBookService bookService,
            IAuthorService authorService,
            ISubscriptionService subscriptionService )
        {
            _readerService = readerService;
            _booksService = bookService;
            _authorService = authorService;
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        [Route( "TakeBook" )]
        public IHttpActionResult TakeBook( int bookId, int readerId )
        {
            var subscription = new Subscription
            {
                BookId = bookId,
                ReaderId = readerId,
                TakeDate = DateTime.UtcNow,
                ReturnDate = null
            };

            _subscriptionService.Save( subscription );

            return Ok();
        }

        [HttpGet]
        [Route( "ReturnBook" )]
        public IHttpActionResult ReturnBook( int subscriptionId )
        {
            var subscription = _subscriptionService.Get( subscriptionId );
            subscription.ReturnDate = DateTime.UtcNow;

            _subscriptionService.Save( subscription );

            return Ok();
        }

        [HttpGet]
        [Route( "Enroll" )]
        public IHttpActionResult Enroll( string firstName, string lastName )
        {
            var reader = new Reader
            {
                FirstName = firstName,
                LastName = lastName
            };

            _readerService.Save( reader );

            return Ok();
        }

        [HttpGet]
        [Route( "Choose" )]
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
