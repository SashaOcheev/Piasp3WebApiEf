using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Piasp3WebApiEf.Models
{
    [DataContract]
    public class Book
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "author" )]
        public Person Author { get; set; }

        [DataMember( Name = "title" )]
        public string Title { get; set; }
    }
}