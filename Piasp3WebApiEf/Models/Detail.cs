using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Piasp3WebApiEf.Models
{
    public class Detail : IDetail
    {
        public string FullName
        {
            get
            {
                return "Kamya Nehwal";
            }
            set
            {
                this.FullName = value;
            }
        }
    }
}