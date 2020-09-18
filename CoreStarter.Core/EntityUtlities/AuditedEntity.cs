using System;

namespace CoreStarter.Core.EntityUtlities
{
    public abstract class AuditedEntity<TPrimaryKey> : IEntityPK<TPrimaryKey>, ICreationTime, ICreatorUser, IUpdatedBy, IUpdatedTime
    {
        public TPrimaryKey Id { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string UpdatedBy { get; set; }

        public string CreatedBy { get; set; }
    }
}
