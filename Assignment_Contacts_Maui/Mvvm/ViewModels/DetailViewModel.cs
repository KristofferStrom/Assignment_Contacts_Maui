using Assignment_Contacts_Maui.Interfaces;
using Assignment_Contacts_Maui.Mvvm.Models;
using Assignment_Contacts_Maui.Mvvm.Views;
using Assignment_Contacts_Maui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Assignment_Contacts_Maui.Mvvm.ViewModels;

public partial class DetailViewModel : ObservableObject
{
  
    private readonly IContactService _contactService;
    private readonly string _email;

    [ObservableProperty] ContactModel contact;

    public DetailViewModel(string email, IContactService contactService)
    {
        _contactService = contactService;
        _email = email;
        Contact = _contactService.Get(c => c.Email == _email);
    }

    //Tar bort kontakt. Om kontakten är borttagen så skickas man tillbaka till mainpage.
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

    //Skapar upp en editviewmodel (vet att inte det är optimalt) med aktuell email och navigerar till editpage
    [RelayCommand]
    public async Task GoToEdit(string email)
    {
        try
        {
            var viewModel = new EditViewModel(email, _contactService);
            var editPage = new EditPage(viewModel);

            await Shell.Current.Navigation.PushAsync(editPage);
        }
        catch { }
    }

    [RelayCommand]
    public async Task GoBack()
    {
        try
        {
            await Shell.Current.GoToAsync("..");
        }
        catch { }
    }
}
