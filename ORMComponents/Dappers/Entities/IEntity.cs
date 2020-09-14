namespace Entities
{
    /// <summary>
    ///  Defines interface for base entity type. All entities in the system must implement
    ///  this interface.
    /// </summary>
    public interface IEntity
    {

    }

    public interface ISoftDelete : IEntity
    {
        bool IsDeleted { get; set; }
    }

    public class Entity : IEntity
    {
    }

    public class SoftDeleteEntity : IEntity, ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }


}
