using CoreStarter.EFCore.EntityUtlities;

namespace CoreStarter.Services._Employee.dto
{
    public class EmployeeEditDto : EntityPKDto<long>
    {
        public string Name { get; set; }
    }
}
