using Piasp3WebApiEf.DAL.Common;
using Piasp3WebApiEf.DAL.Models;
using System.Collections.Generic;

namespace Piasp3WebApiEf.DAL.Services
{
    public interface IBookService : IEntityService<Book>
    {
        List<Book> GetAll();
    }
}
