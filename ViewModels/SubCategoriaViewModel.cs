using CommunityToolkit.Mvvm.Input;
using PocketOne.Interfaces;
using PocketOne.Services;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PocketOne.ViewModels;

[QueryProperty(nameof(SubCategoriaDetails), nameof(SubCategoriaDetails))]
public partial class SubCategoriaViewModel : BaseViewModel
{
    private readonly ISubCategoria subcategoria_service;
    private readonly ICategoria categoria_service;

    public SubCategoriaViewModel()
    {
        subcategoria_service = App.Current.Services.GetRequiredService<ISubCategoria>();
        categoria_service = App.Current.Services.GetRequiredService<ICategoria>();
    }

    [ObservableProperty]
    public SubCategoria subCategoriaDetails;

    [ObservableProperty]
    public int idSeleccionado;

    public ObservableCollection<string> Errores { get; set; } = new();
    
    public List<string> Categorias { get; set; } = new();

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

        int id = SubCategoriaDetails.Id;
        if (id == 0)
        {
            var response = await subcategoria_service.Insert(SubCategoriaDetails);
        }
        else
        {
            var response = await subcategoria_service.Update(SubCategoriaDetails);
        }

        IsLoading = false;
        IsVisible = true;

        await Shell.Current.Navigation.PopToRootAsync();
    }

    [RelayCommand]
    public async Task ListarCategorias()
    {
        IsLoading = true;
        Categorias.Clear();

        var listaCategorias = await categoria_service.GetAll();
        foreach (var item in listaCategorias) Categorias.Add(item.NombreCategoria);

        IsLoading = false;
        IsRefreshing = false;
    }
}
