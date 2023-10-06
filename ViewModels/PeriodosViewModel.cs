// using Android.App;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace PocketOne.ViewModels;

public partial class PeriodosViewModel : BaseViewModel
{
    private readonly IPeriodo periodo_service;
    

    public ObservableCollection<Periodo> Periodos { get; set; } = new();

    [ObservableProperty]
    Periodo periodoSeleccionado;

    public PeriodosViewModel()
    {
        periodo_service = App.Current.Services.GetService<IPeriodo>();
        Task.Run(async () => await ListarPeriodos());
    }

    [RelayCommand]
    public async Task ListarPeriodos()
    {
        IsLoading = true;
        Periodos.Clear();
        var lista = await periodo_service.GetAll();
        foreach (var item in lista) Periodos.Add(item);
        IsLoading = false;
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task EditarPeriodo(Periodo periodo)
    {
        var navparam = new Dictionary<string, object>
        {
            { "PeriodoDetails", periodo }
        };

        await Shell.Current.GoToAsync(nameof(PeriodoView), navparam);

    }

    [RelayCommand]
    public async Task EliminarPeriodo(Periodo periodo)
    {
        IsLoading = true;
        var res = await _dialog.ShowAlertAsync("Eliminar", $"Desea eliminiar el periodo {periodo.FechaPeriodo}", "Aceptar", "Cancelar");
        if (!res) return;
        var delresponse = await periodo_service.Delete(periodo);
        if (delresponse > 0)
        {
            await ListarPeriodos();
        }
    }

    [RelayCommand]
    public async Task AddNew()
    {
        await Shell.Current.Navigation.PushAsync(new PeriodoView(), false);
    }
}
