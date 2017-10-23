namespace Piasp3WebApiEf.DAL.Common
{
    public interface IPerson : EntityWithId
    {
        string FirstName { get; set; }
        string LastName { get; set; }       
    }
}