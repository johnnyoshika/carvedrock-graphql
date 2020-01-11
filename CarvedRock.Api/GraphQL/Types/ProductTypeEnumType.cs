using CarvedRock.Api.Data;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductTypeEnumType : EnumerationGraphType<ProductTypeEnum>
    {
        public ProductTypeEnumType()
        {
            Name = "ProductTypeEnum";
            Description = "Type of product";
        }
    }
}
