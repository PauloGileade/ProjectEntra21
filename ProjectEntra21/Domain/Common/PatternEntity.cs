using System;

namespace ProjectEntra21.Domain.Common
{
    public class PatternEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime LastModifiedAt { get; set; }

        protected PatternEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
