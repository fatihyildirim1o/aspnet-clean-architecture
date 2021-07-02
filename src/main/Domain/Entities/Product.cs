using Domain.Common;

namespace Domain.Entities
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}   