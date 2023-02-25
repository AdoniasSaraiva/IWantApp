using IWantApp.EndPoints.Categories.Request;
using IWantApp.Infra.Data;
using IWantApp.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IWantApp.EndPoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action([FromRoute] Guid id, CategoryRequest categoryRequest, ApplicationDbContext context, HttpContext httpContext)
    {
        var userId = httpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var category = context.Categories.Where(x => x.Id == id).FirstOrDefault();

        if (category == null)
            return Results.NotFound();

        category.EditInfo(categoryRequest.Name, categoryRequest.Active.Value, userId);

        if (!category.IsValid)
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());

        await context.SaveChangesAsync();

        return Results.NoContent();
    }
}
