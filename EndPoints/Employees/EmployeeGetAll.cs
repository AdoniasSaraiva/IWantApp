using IWantApp.EndPoints.Employees.Response;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.EndPoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(UserManager<IdentityUser> userManager)
    {
        var users = userManager.Users.ToList();
        var employees = users.Select(u => new EmployeeResponse(u.Email, "teste"));
        return Results.Ok(employees);
    }
}
