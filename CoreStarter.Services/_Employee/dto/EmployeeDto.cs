using CoreStarter.EFCore.EntityUtlities;

namespace CoreStarter.Services._Employee.dto
{
    public class EmployeeDto : AuditedEntityDto<long>
    {
        public string Name { get; set; }

        public string Age { get; set; }
    }
}
