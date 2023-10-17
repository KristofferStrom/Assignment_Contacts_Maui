using Assignment_Contacts_Maui.Interfaces;
using Assignment_Contacts_Maui.Mvvm.Models;
using Assignment_Contacts_Maui.Mvvm.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Assignment_Contacts_Maui.Mvvm.ViewModels;

public partial class EditViewModel : ObservableObject
{
    [ObservableProperty] ContactModel contact;

    private IContactService _contactService;
 
   

    public EditViewModel(string email, IContactService contactService)
    {
        _contactService = contactService;

        Contact = _contactService.Get(c => c.Email == email);
    }

    [RelayCommand]
    public async Task SaveChanges()
    {
        try
        {
            bool isUpdated = _contactService.Update(Contact);

            if(isUpdated)
            {
                var viewModel = new MainViewModel(_contactService);
                await Shell.Current.Navigation.PushAsync(new MainPage(viewModel));
            }
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
