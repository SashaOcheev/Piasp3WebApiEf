using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Piasp3WebApiEf.Models
{
    [DataContract]
    public class PersonDto
    {
        [DataMember( Name = "firstName" )]
        public string FirstName { get; set; }

        [DataMember( Name = "lastName" )]
        public string LastName { get; set; }
    }
}