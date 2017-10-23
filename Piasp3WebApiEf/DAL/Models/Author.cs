using System;
using Piasp3WebApiEf.DAL.Common;

namespace Piasp3WebApiEf.DAL.Models
{
    public class Author : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}