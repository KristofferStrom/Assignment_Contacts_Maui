using Assignment_Contacts_Maui.Mvvm.ViewModels;
using CommunityToolkit.Maui.Markup;

namespace Assignment_Contacts_Maui.Mvvm.Views;

public partial class AddPage : ContentPage
{
	public AddPage(AddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

       
    }
}