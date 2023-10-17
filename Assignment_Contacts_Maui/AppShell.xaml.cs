using Assignment_Contacts_Maui.Mvvm.Views;

namespace Assignment_Contacts_Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
        }
    }
}