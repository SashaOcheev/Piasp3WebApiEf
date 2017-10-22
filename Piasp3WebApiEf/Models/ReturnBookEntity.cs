using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Piasp3WebApiEf.Models
{
    [DataContract]
    public class ReturnBookEntity : TakeBookEntity
    {
        [DataMember( Name = "bookCardId" )]
        public int BookCardId { get; set; }
    }
}