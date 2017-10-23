using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Piasp3WebApiEf.DAL.Models;
using Piasp3WebApiEf.DAL.Common;
using System.Data.Entity;

namespace Piasp3WebApiEf.DAL.Services
{
    public class AuthorService : DbContext, IAuthorService
    {
        public AuthorService()
            :base("DbConnection")
        { }

        public DbSet<Author> Authors { get; set; }

        public Author Get( int Id )
        {
            return Authors.SingleOrDefault( x => x.Id == Id );
        }

        public void Save( Author author )
        {
            var existAuthor = Get( author.Id );
            if ( existAuthor != null )
            {
                existAuthor.Id = author.Id;
            }
            else
            {
                Authors.Add( author );
            }
            SaveChanges();
        }
    }
}