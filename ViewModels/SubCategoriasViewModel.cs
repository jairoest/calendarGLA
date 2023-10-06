using CommunityToolkit.Mvvm.Input;
using PocketOne.Services;
using System.Collections.ObjectModel;
namespace PocketOne.ViewModels;

public partial class SubCategoriasViewModel: BaseViewModel
{
    private readonly ISubCategoria subcategoria_service;

    public ObservableCollection<SubCategoria> SubCategorias { get; set; } = new();

    [ObservableProperty]
    SubCategoria subCategoriaSeleccionada;

    public SubCategoriasViewModel()
    {
        subcategoria_service = App.Current.Services.GetService<ISubCategoria>();
        Task.Run(async () => await ListarSubCategorias());
    }

    [RelayCommand]
    public async Task ListarSubCategorias()
    {
        IsLoading = true;
        SubCategorias.Clear();
        var lista = await subcategoria_service.GetAll();
        if (lista.Count == 0)
        {
            subcategoria_service.LlenarSubCategoriasBase();
        }
        else
        {
            foreach (var item in lista) SubCategorias.Add(item);
        }
        
        IsLoading = false;
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task EditarSubCategoria(SubCategoria subcategoria)
    {
        var navparam = new Dictionary<string, object>
        {
            { "SubCategoriaDetails", subcategoria }
        };

        await Shell.Current.GoToAsync(nameof(SubCategoriaView), navparam);

    }

    [RelayCommand]
    public async Task EliminarSubCategoria(SubCategoria subcategoria)
    {
        IsLoading = true;
        var res = await _dialog.ShowAlertAsync("Eliminar", $"Desea eliminiar la subcategoria {subcategoria.NombreSubCategoria}", "Aceptar", "Cancelar");
        if (!res) return;
        var delresponse = await subcategoria_service.Delete(subcategoria);
        if (delresponse > 0)
        {
            await ListarSubCategorias();
        }
    }

    [RelayCommand]
    public async Task AddNew()
    {
        await Shell.Current.Navigation.PushAsync(new PeriodoView(), false);
    }

}
