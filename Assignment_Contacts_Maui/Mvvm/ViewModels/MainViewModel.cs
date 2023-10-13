using Assignment_Contacts_Maui.Interfaces;
using Assignment_Contacts_Maui.Mvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Assignment_Contacts_Maui.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IContactService _contactService;
    [ObservableProperty] ObservableCollection<ContactModel> contacts;

    public MainViewModel(IContactService contactService)
    {
        _contactService = contactService;
        Contacts = _contactService.GetAll();
    }
}