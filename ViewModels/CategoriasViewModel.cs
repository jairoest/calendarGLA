using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
namespace PocketOne.ViewModels;


public partial class CategoriasViewModel: BaseViewModel
{
    private readonly ICategoria categoria_service;

    public ObservableCollection<Categoria> Categorias { get; set; } = new();

    [ObservableProperty]
    Categoria categoriaSeleccionada;

    public CategoriasViewModel()
    {
        categoria_service = App.Current.Services.GetService<ICategoria>();
        Task.Run(async () => await ListarCategorias());
    }

    [RelayCommand]
    public async Task ListarCategorias()
    {
        IsLoading = true;
        Categorias.Clear();
        var lista = await categoria_service.GetAll();
        if (lista.Count == 0)
        {
            categoria_service.LlenarCategoriasBase();
            lista = await categoria_service.GetAll();
        }

        foreach (var item in lista) Categorias.Add(item);

        IsLoading = false;
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task EditarCategoria(Categoria categoria)
    {
        var navparam = new Dictionary<string, object>
        {
            { "CategoriaDetails", categoria }
        };

        await Shell.Current.GoToAsync(nameof(CategoriaView), navparam);

    }

    [RelayCommand]
    public async Task EliminarCategoria(Categoria categoria)
    {
        IsLoading = true;
        var res = await _dialog.ShowAlertAsync("Eliminar", $"Desea eliminiar la categoria {categoria.NombreCategoria}", "Aceptar", "Cancelar");
        if (!res) return;
        var delresponse = await categoria_service.Delete(categoria);
        if (delresponse > 0)
        {
            await ListarCategorias();
        }
    }

    [RelayCommand]
    public async Task AddNew()
    {
        await Shell.Current.Navigation.PushAsync(new CategoriaView(), false);
    }

}
