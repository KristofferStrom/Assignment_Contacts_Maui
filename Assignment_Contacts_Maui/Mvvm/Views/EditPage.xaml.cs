using Assignment_Contacts_Maui.Mvvm.ViewModels;

namespace Assignment_Contacts_Maui.Mvvm.Views;

public partial class EditPage : ContentPage
{
	public EditPage(EditViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}