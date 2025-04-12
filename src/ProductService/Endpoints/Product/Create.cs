﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using ProductService.Contracts.Requests;
using ProductService.Database;
using ProductService.Mappers;
using ProtobufSpec;

namespace ProductService.Endpoints.Product;

public static class Create
{
    internal static async Task<Results<StatusCodeHttpResult, Created<ProductDto>>> HandleAsync(
        [FromBody] CreateProductReq req,
        [FromServices] AppDbContext context)
    {
        var productEntity = req.ToProductEntity();
        
        context.Products.Add(productEntity);
        await context.SaveChangesAsync();

        return TypedResults.Created($"{ApiRoutes.Product.Path}/{productEntity.Id}", productEntity.ToProductDto());
    }

    [ExcludeFromCodeCoverage]
    internal static OpenApiOperation OpenApi(OpenApiOperation operation)
    {
        operation.Summary = "Create product";

        return operation;
    }
}