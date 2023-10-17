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

    private bool IsCorrectFieldInputs(ContactModel contact)
    {
        if(contact == null || contact.Email == null || contact.FirstName == null || contact.LastName == null || _contacts.Any(c => c.Email == contact.Email)) 
            return false;

        return true;
    }

    public ContactModel Get(Func<ContactModel, bool> expression)
    {
        var contact = _contacts.FirstOrDefault(expression);
        if (contact == null)
            return null!;

        return contact;
    }

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
