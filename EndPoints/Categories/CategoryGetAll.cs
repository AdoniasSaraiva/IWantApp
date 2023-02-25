using IWantApp.EndPoints.Categories.Request;
using IWantApp.Infra.Data;

namespace IWantApp.EndPoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var response = context.Categories.ToList().Select(x => new CategoriesResponse(x.Id, x.Name, x.Active));
        return Results.Ok(response);
    }
}
