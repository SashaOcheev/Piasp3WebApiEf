using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Piasp3WebApiEf.DAL.Models;
using System.Data.Entity;

namespace Piasp3WebApiEf.DAL.Services
{
    public class BookService : DbContext, IBookService
    {
        public BookService()
            : base( "DbConnection" )
        { }

        public DbSet<Book> Books { get; set; }

        public Book Get( int Id )
        {
            return Books.SingleOrDefault( x => x.Id == Id );
        }

        public List<Book> GetAll()
        {
            return Books
                .Distinct( new EqualityComparer() )
                .ToList();
        }

        public void Save( Book book )
        {
            var existBook = Get( book.Id );
            if ( existBook != null )
            {
                existBook.Id = book.Id;
            }
            else
            {
                Books.Add( book );
            }
            SaveChanges();
        }

        class EqualityComparer : IEqualityComparer<Book>
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