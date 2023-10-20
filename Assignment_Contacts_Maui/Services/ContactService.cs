using Assignment_Contacts_Maui.Interfaces;
using Assignment_Contacts_Maui.Mvvm.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Assignment_Contacts_Maui.Services;

public class ContactService : IContactService
{
    private ObservableCollection<ContactModel> _contacts;
    private readonly IFileService _fileService;
    private readonly string _filePath = @"C:\CMS23\C-sharp\Contacts.json";

   
    public ContactService(IFileService fileService)
    {
        _contacts = new ObservableCollection<ContactModel>();

        _fileService = fileService;

        GetInitialContactsFromFile();
    }

    //Fyller _contacts med kontakter från en json-fil
    private void GetInitialContactsFromFile()
    {
        try
        {
            var contactListJSON = _fileService.ReadFromFile(_filePath);

            if(contactListJSON != null )
                _contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(contactListJSON);
        }
        catch { }
    }

    //Om fälten (email) är ifyllda så läggs den kontakten i listan och listan sparas i filen.
    public ContactModel Create(ContactModel contact)
    {
        try
        {
            if (IsCorrectFieldInputs(contact))
            {
                _contacts.Add(contact);

                Task.Run(() => _fileService.SaveToFileAsync(_filePath, JsonConvert.SerializeObject(_contacts)));

                return contact;
            }
        }
        catch { }

        return null!;
    }

    //returnerar true/false beroende på om kontakten är null, om email är null eller om emailadressen redan finns i listan.
    private bool IsCorrectFieldInputs(ContactModel contact)
    {
        if(contact == null || contact.Email == null || _contacts.Any(c => c.Email == contact.Email)) 
            return false;

        return true;
    }

    //Hämtar en kontakt från listan
    public ContactModel Get(Func<ContactModel, bool> expression)
    {
        try
        {
            var contact = _contacts.FirstOrDefault(expression);

            if (contact != null)
                return contact;
        }
        catch { }
    
        return null!;
    }

    //Hämtar hela listan. Valde att inte hämta från fil varje gång, utan bara vid uppstart. Såg i det här fallet inte att det skulle vara fördelaktigt (men kan ha fel).
    public ObservableCollection<ContactModel> GetAll()
    {
        try
        {
            if(_contacts.Count > 0)
            return _contacts;
        }
        catch { }

        return null!;
    }

    //Tar bort en kontakt från listan (om kontakten finns). Sparar sedan listan i fil.
    public bool Remove(Func<ContactModel, bool> expression)
    {
        try
        {
            var contactToRemove = _contacts.FirstOrDefault(expression);

            if (contactToRemove == null)
                return false;

            _contacts.Remove(contactToRemove);

            Task.Run(() => _fileService.SaveToFileAsync(_filePath, JsonConvert.SerializeObject(_contacts)));

            return true;
        }
        catch { }

        return false;
    }

    //Hämtar kontakt som ska uppdateras. Mappar in alla properties med uppdaterade värden. Valde att inte kolla för varje property om värdet är ändrat.
    public bool Update(ContactModel contact)
    {
        try
        {
            var contactToUpdate = _contacts.FirstOrDefault(c => c.Email == contact.Email);

            if (contactToUpdate != null)
            {
                contactToUpdate.FirstName = contact.FirstName;
                contactToUpdate.LastName = contact.LastName;
                contactToUpdate.PhoneNumber = contact.PhoneNumber;
                contactToUpdate.Address.StreetAddress = contact.Address.StreetAddress;
                contactToUpdate.Address.PostalCode = contact.Address.PostalCode;
                contactToUpdate.Address.City = contact.Address.City;

                Task.Run(() => _fileService.SaveToFileAsync(_filePath, JsonConvert.SerializeObject(_contacts)));

                return true;
            }
        }
        catch { }

        return false;
    }
}
