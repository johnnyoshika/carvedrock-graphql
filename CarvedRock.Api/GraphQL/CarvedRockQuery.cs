﻿using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockQuery : ObjectGraphType
    {
        public CarvedRockQuery(ProductRepository productRepository)
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetAllAsync() 
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var user = (ClaimsPrincipal)context.UserContext;
                    if (user.Identity.Name == "Johnny")
                        context.Errors.Add(new ExecutionError("User Johnny error"));

                    int id = context.GetArgument<int>("id");
                    if (id < 1)
                        context.Errors.Add(new ExecutionError("id out of range"));

                    return productRepository.GetOneAsync(id);
                });
        }
    }
}
