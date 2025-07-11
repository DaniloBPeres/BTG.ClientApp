using BTG.ClientApp.ViewModels;

namespace BTG.ClientApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = App.Services.GetRequiredService<ClientViewModel>();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as ClientViewModel)?.LoadClientsCommand.Execute(null);
    }
}