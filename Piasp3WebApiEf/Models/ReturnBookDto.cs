﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Piasp3WebApiEf.Models
{
    [DataContract]
    public class ReturnBookDto : TakeBookDto
    {
        [DataMember( Name = "SubscriptionId" )]
        public int SubscriptionId { get; set; }
    }
}