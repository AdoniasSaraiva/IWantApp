using IWantApp.Domain.Products;
using IWantApp.EndPoints.Categories.Request;
using IWantApp.Infra.Data;
using IWantApp.Utils;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace IWantApp.EndPoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    [Authorize]
    public static async Task<IResult> Action(CategoryRequest categoryRequest,HttpContext httpContext, ApplicationDbContext context)
    {
        var userId = httpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var category = new Category(categoryRequest.Name, userId, userId);  

        if (!category.IsValid)
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());

        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();

        return Results.Created($"{Template}/{category.Id}", category.Id);
    }
}
