using IWantApp.Domain.Products;
using IWantApp.EndPoints.Categories.Request;
using IWantApp.Infra.Data;
using IWantApp.Utils;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.EndPoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = context.Categories.Where(x => x.Id == id).FirstOrDefault();

        if (category == null)
            return Results.NotFound();

        category.EditInfo(categoryRequest.Name, categoryRequest.Active.Value);

        if (!category.IsValid)
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());

        context.SaveChanges();

        return Results.NoContent();
    }
}
