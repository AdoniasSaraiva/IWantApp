using IWantApp.Infra.Data.Query;
using Microsoft.AspNetCore.Authorization;

namespace IWantApp.EndPoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action(int? page, int? rows)
    {
        var result = await QueryAllUsersWithClaimName.Execute(page, rows);
        return Results.Ok(result);
    }
}
