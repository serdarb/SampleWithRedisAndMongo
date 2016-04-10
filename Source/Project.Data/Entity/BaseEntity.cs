using System;

using MongoDB.Bson;

namespace Project.Data.Entity
{
    public abstract class BaseEntity
    {
        public ObjectId Id { get; set; }
        public string UId { get; set; }
        public DateTime CreatedAt { get; set; }

        public BaseEntity()
        {
            Id = ObjectId.GenerateNewId();
            UId = Id.ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
