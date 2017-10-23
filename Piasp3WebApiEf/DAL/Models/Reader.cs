using Piasp3WebApiEf.DAL.Common;

namespace Piasp3WebApiEf.DAL.Models
{
    public class Reader : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}