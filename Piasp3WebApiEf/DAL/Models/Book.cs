using Piasp3WebApiEf.DAL.Common;

namespace Piasp3WebApiEf.DAL.Models
{
    public class Book : EntityWithId
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
    }
}