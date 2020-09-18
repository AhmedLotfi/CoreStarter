using System;

namespace CoreStarter.Core.EntityUtlities
{
    public interface IUpdatedTime
    {
        Nullable<DateTime> UpdateTime { get; set; }
    }
}
