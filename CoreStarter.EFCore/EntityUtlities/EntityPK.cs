namespace CoreStarter.EFCore.EntityUtlities
{
    public abstract class EntityPK<TPrimaryKey> : IEntityPK<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
