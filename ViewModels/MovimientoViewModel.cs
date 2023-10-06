using CommunityToolkit.Mvvm.Input;
using PocketOne.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PocketOne.ViewModels;

[QueryProperty(nameof(MovimientoDetails), nameof(MovimientoDetails))]
public partial class MovimientoViewModel : BaseViewModel
{
    private readonly IMovimiento movimiento_service;
    private readonly ISubCategoria subcategoria_service;

    public List<string> SubCategorias { get; set; } = new();

    public MovimientoViewModel()
    {
        movimiento_service = App.Current.Services.GetRequiredService<IMovimiento>();
        subcategoria_service = App.Current.Services.GetService<ISubCategoria>();

    }

    [ObservableProperty]
    public Movimiento movimientoDetails;

    [ObservableProperty]
    public int idSeleccionado;

    [ObservableProperty]
    public List<string> tipos = new() { "Ingreso", "Egreso" };

    public ObservableCollection<string> Errores { get; set; } = new();

    private string resultado;
    public string Resultado
    {
        get => resultado;
        set => SetProperty(ref resultado, value, "true");
    }


    [RelayCommand]
    public async Task Save()
    {
        IsLoading = true;
        IsVisible = false;

        int id = MovimientoDetails.Id;
        if (id == 0)
        {
            var response = await movimiento_service.Insert(MovimientoDetails);
        }
        else
        {
            var response = await movimiento_service.Update(MovimientoDetails);
        }

        IsLoading = false;
        IsVisible = true;

        await Shell.Current.Navigation.PopToRootAsync();
    }

    [RelayCommand]
    public async Task ListarSubCategorias()
    {
        IsLoading = true;
        SubCategorias.Clear();

        var listaSubCategorias = await subcategoria_service.GetAll();
        foreach (var item in listaSubCategorias) SubCategorias.Add(item.NombreSubCategoria);

        // Titulo = PeriodoDetails.FechaPeriodo.ToString("MMMM");
        Titulo = $"Lista de subcategorias";

        IsLoading = false;
        IsRefreshing = false;
    }


}
