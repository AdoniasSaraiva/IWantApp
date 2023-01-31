using Dapper;
using IWantApp.EndPoints.Employees.Response;
using IWantApp.Helpers;
using IWantApp.Infra.Data.Query;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace IWantApp.EndPoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(int? page, int? rows)
    {
        return Results.Ok(QueryAllUsersWithClaimName.Execute(page, rows));
    }
}
