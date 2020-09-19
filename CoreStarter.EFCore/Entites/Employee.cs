using CoreStarter.EFCore.EntityUtlities;
using System.ComponentModel.DataAnnotations;

namespace CoreStarter.EFCore.Entites
{
    public class Employee : AuditedEntity<long>
    {
        [Required]
        public string Name { get; protected set; }

        public string Age { get; protected set; }
    }
}
