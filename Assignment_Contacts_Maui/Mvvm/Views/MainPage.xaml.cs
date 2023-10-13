using Assignment_Contacts_Maui.Mvvm.ViewModels;

namespace Assignment_Contacts_Maui.Mvvm.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}