using System;

namespace DecaLib.Models
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}