using System;

namespace ppedv.ElenasUwe.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
