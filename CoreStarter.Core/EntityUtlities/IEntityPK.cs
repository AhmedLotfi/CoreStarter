namespace CoreStarter.Core.EntityUtlities
{
    public interface IEntityPK<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
