using Piasp3WebApiEf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Piasp3WebApiEf.Controllers
{
    public class ShowController : ApiController
    {
        private IDetail idetail = null;
        public ShowController( IDetail Idetail )
        {
            idetail = Idetail;
        }
        [HttpGet]
        public string GetValue()
        {
            return idetail.FullName;
        }
    }
}
