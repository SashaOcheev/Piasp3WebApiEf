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
            //return Books
            //  .Distinct( new EqualityComparer() )
            //.ToList();

            return Books.ToList();
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
    }
}