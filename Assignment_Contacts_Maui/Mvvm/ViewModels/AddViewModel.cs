using Assignment_Contacts_Maui.Interfaces;
using Assignment_Contacts_Maui.Mvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Assignment_Contacts_Maui.Mvvm.ViewModels;

public partial class AddViewModel : ObservableObject
{
    private readonly IContactService _contactService;
    [ObservableProperty] ContactModel contact = new ContactModel();

    public AddViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    [RelayCommand]
    public async Task Save()
    {
		try
		{
           var contact = _contactService.Create(Contact);
            if (contact != null)
            {
                Contact = new ContactModel();
                await Shell.Current.GoToAsync("..");
            }
                
		}
		catch { }
		
    }
}
