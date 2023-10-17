namespace Assignment_Contacts_Maui.Mvvm.Models;

public class ContactModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public AddressModel Address { get; set; } = new AddressModel();

    public string FullName => $"{FirstName} {LastName}";
}
