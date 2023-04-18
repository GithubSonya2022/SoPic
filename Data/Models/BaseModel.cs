using System;

namespace SoPic.Data.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public BaseModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
