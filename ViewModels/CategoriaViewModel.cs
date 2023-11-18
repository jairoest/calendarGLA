using CommunityToolkit.Mvvm.Input;
using PocketOne.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PocketOne.ViewModels;

[QueryProperty(nameof(CategoriaDetails), nameof(CategoriaDetails))]
public partial class CategoriaViewModel : BaseViewModel
{
    private readonly ICategoria categoria_service;

    public CategoriaViewModel()
    {
        categoria_service = App.Current.Services.GetRequiredService<ICategoria>();
    }

    [ObservableProperty]
    public Categoria categoriaDetails;

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

        int id = CategoriaDetails.Id;
        if (id == 0)
        {
            var response = await categoria_service.Insert(CategoriaDetails);
        }
        else
        {
            var response = await categoria_service.Update(CategoriaDetails);
        }

        IsLoading = false;
        IsVisible = true;

        await Shell.Current.Navigation.PopToRootAsync();
    }

}
