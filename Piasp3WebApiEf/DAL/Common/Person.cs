namespace Piasp3WebApiEf.DAL.Common
{
    public interface Person : EntityWithId
    {
        string FirstName { get; set; }
        string LastName { get; set; }       
    }
}