using Dapper;
using IWantApp.EndPoints.Employees.Response;
using IWantApp.Helpers;
using Microsoft.Data.SqlClient;

namespace IWantApp.Infra.Data.Query;

public static class QueryAllUsersWithClaimName
{

    public static IEnumerable<EmployeeResponse> Execute(int? page, int? rows)
    {
        if (!page.HasValue || !rows.HasValue)
        {
            page = 1;
            rows = 10;
        }

        var db = new SqlConnection(ConfigHelper.ConnectionString());
        string query =
               @"select 
                   AU.Email, 
                   AUC.ClaimValue AS Name
               FROM AspNetUsers AU
                   INNER JOIN AspNetUserClaims AUC (NOLOCK) ON (AU.Id = AUC.UserId) 
               WHERE 
                   AUC.ClaimType = 'Name'
               ORDER BY Name
               OFFSET(@page - 1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

        return db.Query<EmployeeResponse>(query, new { page, rows });
    }
}
