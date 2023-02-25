namespace IWantApp.EndPoints.Categories.Request;

public record CategoryRequest(string Name, bool? Active = true);