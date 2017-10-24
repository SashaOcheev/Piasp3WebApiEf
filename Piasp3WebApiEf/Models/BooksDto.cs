using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Piasp3WebApiEf.Models
{
    [DataContract]
    public class BooksDto
    {
        [DataMember( Name = "books" )]
        public List<BookDto> Books { get; set; }
    }
}