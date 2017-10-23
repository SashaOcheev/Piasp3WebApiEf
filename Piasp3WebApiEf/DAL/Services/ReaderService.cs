using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Piasp3WebApiEf.DAL.Models;
using System.Data.Entity;

namespace Piasp3WebApiEf.DAL.Services
{
    public class ReaderService : DbContext, IReaderService
    {
        public ReaderService()
            : base( "DbConnection" )
        { }

        public DbSet<Reader> Readers { get; set; }

        public Reader Get( int Id )
        {
            return Readers.SingleOrDefault( x => x.Id == Id );
        }

        public void Save( Reader reader )
        {
            var existReader = Get( reader.Id );
            if ( existReader != null )
            {
                existReader.Id = reader.Id;
            }
            else
            {
                Readers.Add( reader );
            }
            SaveChanges();
        }
    }
}