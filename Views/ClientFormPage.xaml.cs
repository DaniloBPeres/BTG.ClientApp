using BTG.ClientApp.ViewModels;

namespace BTG.ClientApp.Views;

public partial class ClientFormPage : ContentPage
{
    private readonly ClientFormViewModel _viewModel;

    public ClientFormPage()
	{
		InitializeComponent();
        _viewModel = App.Services.GetRequiredService<ClientFormViewModel>();
        BindingContext = _viewModel;
        _viewModel.RequestClose += () => Close();
    }

    public void SetClientId(Guid id)
    {
        _viewModel.LoadClientById(id);
    }

    private void Close()
    {
        Application.Current.CloseWindow(GetParentWindow());
    }
}