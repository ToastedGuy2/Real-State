using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Helpers
{
    public static class ICollectionExtensions
    {
        public static SelectList GetSelectList(ICollection<Province> provinces)
        {
            return new SelectList(provinces, "ProvinceId", "Name");
        }
    }
}