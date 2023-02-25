namespace IWantApp.EndPoints.Employees.Request;

public record EmployeeRequest(string Email, string Password, string Name, string EmployeeCode);
