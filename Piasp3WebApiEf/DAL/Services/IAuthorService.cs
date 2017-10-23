using Piasp3WebApiEf.DAL.Common;
using Piasp3WebApiEf.DAL.Models;
using System.Collections.Generic;

namespace Piasp3WebApiEf.DAL.Services
{
    public interface IAuthorService : IEntityService<Author>
    {
        List<Author> GetAll();
        List<Author> Get( List<int> ids );
    }
}
