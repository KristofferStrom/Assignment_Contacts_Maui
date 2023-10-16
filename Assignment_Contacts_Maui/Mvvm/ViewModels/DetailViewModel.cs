using Assignment_Contacts_Maui.Interfaces;
using Assignment_Contacts_Maui.Mvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Assignment_Contacts_Maui.Mvvm.ViewModels;

public partial class DetailViewModel : ObservableObject
{
  
    private IContactService _contactService;

    [ObservableProperty] ContactModel contact;

    public DetailViewModel(string email, IContactService contactService)
    {
        _contactService = contactService;

        Contact = _contactService.Get(c => c.Email == email);
    }

    [RelayCommand]
    public async Task Remove(string email)
    {
        try
        {
           var isRemoved = _contactService.Remove(c => c.Email == email);

            if(isRemoved)
                await Shell.Current.GoToAsync("..");
        }
        catch { }
    }
}
