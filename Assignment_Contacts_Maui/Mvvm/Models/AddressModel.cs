namespace Assignment_Contacts_Maui.Mvvm.Models;

public class AddressModel
{
    public string StreetAddress { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string FullAddress => $"{StreetAddress}, {PostalCode}, {City.ToUpper()}";
}
