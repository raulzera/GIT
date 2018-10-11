using System;

namespace CC.SAD.Cobranca.Domain.Core.Entities
{
    public class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; protected set; }
    }
}
