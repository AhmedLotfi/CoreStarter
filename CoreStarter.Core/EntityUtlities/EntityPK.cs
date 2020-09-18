namespace CoreStarter.Core.EntityUtlities
{
    public class EntityPK<TPrimaryKey> : IEntityPK<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
