﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Piasp3WebApiEf.Models
{
    [DataContract]
    public class Reader : Person
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }
    }
}