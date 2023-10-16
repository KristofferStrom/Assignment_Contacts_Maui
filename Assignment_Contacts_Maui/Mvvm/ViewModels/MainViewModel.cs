using Assignment_Contacts_Maui.Interfaces;
using Assignment_Contacts_Maui.Mvvm.Models;
using Assignment_Contacts_Maui.Mvvm.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

    [RelayCommand]
    public async Task GoToDetail(string email)
    {
        var viewModel = new DetailViewModel(email, _contactService);
        var detailPage = new DetailPage(viewModel);

        await Shell.Current.Navigation.PushAsync(detailPage);
    }

    [RelayCommand]
    public async Task GoToAdd()
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(AddPage));
        }
        catch { }
    }
}