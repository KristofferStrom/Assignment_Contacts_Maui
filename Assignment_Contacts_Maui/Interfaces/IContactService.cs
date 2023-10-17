using Assignment_Contacts_Maui.Mvvm.Models;
using System.Collections.ObjectModel;

namespace Assignment_Contacts_Maui.Interfaces;

public interface IContactService
{
    ObservableCollection<ContactModel> GetAll();
    ContactModel Get(Func<ContactModel, bool> expression);
    ContactModel Create(ContactModel contact);
    bool Remove(Func<ContactModel, bool> expression);
    bool Update(ContactModel contact);
    static event Action UpdatedContact;
}
