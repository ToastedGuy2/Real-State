using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Helpers
{
    public static class IEnumerableExtensions
    {
        public static SelectList ToSelectList(this IEnumerable<Category> categories)
        {
            return new SelectList(categories, "CategoryId", "Name");
        }
        public static SelectList ToSelectList(this IEnumerable<Brand> brands)
        {
            return new SelectList(brands, "BrandId", "Name");
        }

    }
}