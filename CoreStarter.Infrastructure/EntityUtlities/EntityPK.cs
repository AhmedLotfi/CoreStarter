namespace CoreStarter.Infrastructure.EntityUtlities
{
    public class EntityPK<TPrimaryKey> : IEntityPK<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }

    public interface IEntityPK<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
