using System.Collections.Generic;

namespace Ecommerce.Common
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryDto ParentCategory { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
    }
}