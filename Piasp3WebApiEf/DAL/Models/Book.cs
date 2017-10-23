using Piasp3WebApiEf.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piasp3WebApiEf.DAL.Models
{
    public class Book : EntityWithId
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
    }
}