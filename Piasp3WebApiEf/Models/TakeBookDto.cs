using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Piasp3WebApiEf.Models
{
    [DataContract]
    public class TakeBookDto
    {
        [DataMember( Name = "readerId" )]
        public int ReaderId { get; set; }

        [DataMember( Name = "bookId" )]
        public int BookId { get; set; }
    }
}