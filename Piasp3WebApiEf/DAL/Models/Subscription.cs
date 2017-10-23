using Piasp3WebApiEf.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piasp3WebApiEf.DAL.Models
{
    public class Subscription : EntityWithId
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool WasReturn
        {
            get
            {
                return ReturnDate.HasValue; 
            }
        }
    }
}