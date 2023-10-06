
namespace PocketOne.ViewModels;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isLoading;
    
    public bool IsReady => !IsLoading;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    private bool isVisible;

    public bool IsEnabled => !IsVisible;

    [ObservableProperty]
    string titulo;

    public readonly IDialogService _dialog;

    public BaseViewModel()
    {
        _dialog = App.Current.Services.GetService<IDialogService>();
    }

}
