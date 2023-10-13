using Assignment_Contacts_Maui.Mvvm.ViewModels;

namespace Assignment_Contacts_Maui.Mvvm.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}