using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category : IEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
