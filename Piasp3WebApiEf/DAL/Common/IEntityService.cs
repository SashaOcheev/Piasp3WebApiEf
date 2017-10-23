namespace Piasp3WebApiEf.DAL.Common
{
    public interface IEntityService<EntityType> where EntityType : EntityWithId
    {
        EntityType Get( int Id );
        void Save( EntityType author );
    }
}
