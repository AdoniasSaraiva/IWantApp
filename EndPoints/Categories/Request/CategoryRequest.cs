namespace IWantApp.EndPoints.Categories.Request;

public class CategoryRequest
{
    public string Name { get; set; }
    public bool? Active { get; set; } = true;
}