using Flunt.Validations;
using IWantApp.Utils.Language;
namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Category(string name, string createdBy, string editedBy)
    {

        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Category>()
                       .IsNotNullOrEmpty(Name, "Name", ServiceMsg.MSG0001)
                       .IsGreaterOrEqualsThan(Name, 3, "name", string.Format(ServiceMsg.MSG0004, "name", 3.ToString()))
                       .IsNotNullOrEmpty(CreatedBy, "CreatedBy", ServiceMsg.MSG0002)
                       .IsNotNullOrEmpty(EditedBy, "EditedBy", ServiceMsg.MSG0003);

        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active, string editedBy)
    {
        Name = name;
        Active = active;
        EditedBy = editedBy;
        EditedOn = DateTime.Now;

        Validate();
    }
}
