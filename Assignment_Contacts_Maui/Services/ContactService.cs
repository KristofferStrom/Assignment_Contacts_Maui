using Assignment_Contacts_Maui.Interfaces;
using Assignment_Contacts_Maui.Mvvm.Models;
using System.Collections.ObjectModel;

namespace Assignment_Contacts_Maui.Services;

public class ContactService : IContactService
{
    private readonly ObservableCollection<ContactModel> _contacts;

    public ContactService()
    {
        _contacts = new ObservableCollection<ContactModel> { new ContactModel { FirstName = "Kristoffer", LastName = "Ström", PhoneNumber = "0763233430", Email = "kristoffer.strom@hotmail.se", Address = new AddressModel {StreetAddress = "Gubbängsvägen 90", PostalCode = "12245", City = "Enskede" } },
                                                             new ContactModel { FirstName = "Kalle", LastName = "Ström", PhoneNumber = "0763256430", Email = "kalle.strom@gmail.com", Address = new AddressModel {StreetAddress = "Gebersvägen 24", PostalCode = "12235", City = "Sköndal" } }};
    }

    public ContactModel Create(ContactModel contact)
    {
        if (!IsCorrectFieldInputs(contact))
            return null!;

        _contacts.Add(contact);
        return contact;
    }

    private bool IsCorrectFieldInputs(ContactModel contact)
    {
        if(contact == null || contact.Email == null || contact.FirstName == null || contact.LastName == null || _contacts.Any(c => c.Email == contact.Email)) 
            return false;

        return true;
    }

    public ContactModel Get(Func<ContactModel, bool> expression)
    {
        return _contacts.FirstOrDefault(expression);
    }

    public ObservableCollection<ContactModel> GetAll()
    {
        if(_contacts.Count == 0)
            return null!;

        return _contacts;
    }

    public bool Remove(Func<ContactModel, bool> expression)
    {
        var contactToRemove = _contacts.FirstOrDefault(expression);

        return _contacts.Remove(contactToRemove);
    }
}
