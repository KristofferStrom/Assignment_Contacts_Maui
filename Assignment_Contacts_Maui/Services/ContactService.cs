using Assignment_Contacts_Maui.Interfaces;
using Assignment_Contacts_Maui.Mvvm.Models;
using System.Collections.ObjectModel;

namespace Assignment_Contacts_Maui.Services;

public class ContactService : IContactService
{
    public ContactModel Create(ContactModel contact)
    {
        throw new NotImplementedException();
    }

    public ContactModel Get(Func<ContactModel, bool> expression)
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<ContactModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Remove(Func<ContactModel, bool> expression)
    {
        throw new NotImplementedException();
    }
}
