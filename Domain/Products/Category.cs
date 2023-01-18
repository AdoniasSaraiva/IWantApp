using Flunt.Validations;
using IWantApp.Utils;
namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; }

    public Category(string name, string createdBy, string editedBy)
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name", ServiceMsg.MSG0001)
            .IsNotNullOrEmpty(CreatedBy, "CreatedBy", ServiceMsg.MSG0002)
            .IsNotNullOrEmpty(EditedBy, "EditedBy", ServiceMsg.MSG0003);


        AddNotifications(contract);
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;
    }
}
