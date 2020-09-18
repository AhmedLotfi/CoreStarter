namespace CoreStarter.EFCore.EntityUtlities
{
    public interface IEntityPK<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
