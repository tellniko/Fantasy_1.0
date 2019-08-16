﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fantasy.Web.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static List<PropertyInfo> GetProperties(this object obj, string startsWith)
        {
            return obj
                .GetType()
                .GetProperties()
                .Where(p => p.Name.StartsWith(startsWith))
                .ToList();
        }
    }
}
