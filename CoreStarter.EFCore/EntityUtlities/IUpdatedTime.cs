using System;

namespace CoreStarter.EFCore.EntityUtlities
{
    public interface IUpdatedTime
    {
        Nullable<DateTime> UpdateTime { get; set; }
    }
}
