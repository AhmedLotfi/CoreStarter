using CoreStarter.EFCore.EntityUtlities;

namespace CoreStarter.EFCore.Entites
{
    public class Employee : AuditedEntity<long>
    {
        public string Name { get; protected set; }
    }
}
