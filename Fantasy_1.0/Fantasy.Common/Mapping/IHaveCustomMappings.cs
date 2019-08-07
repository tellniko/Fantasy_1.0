using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Fantasy.Common.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
