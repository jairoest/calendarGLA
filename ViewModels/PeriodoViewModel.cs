using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.Input;
using PocketOne.Interfaces;
using PocketOne.Models;
using PocketOne.Services;

namespace PocketOne.ViewModels;

[QueryProperty(nameof(PeriodoDetails), nameof(PeriodoDetails))]
public partial class PeriodoViewModel : BaseViewModel
{
    private readonly IPeriodo periodo_service;
    private readonly IMovimiento movimiento_service;

    public PeriodoViewModel()
    {
        periodo_service = App.Current.Services.GetRequiredService<IPeriodo>();
        movimiento_service = App.Current.Services.GetRequiredService<IMovimiento>();
    }

    [ObservableProperty]
    public Periodo periodoDetails;

    [ObservableProperty]
    public int idSeleccionado;

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

        int id = PeriodoDetails.Id;
        if (id == 0)
        {
            var response = await periodo_service.Insert(PeriodoDetails);
        }
        else
        {
            var response = await periodo_service.Update(PeriodoDetails);
        }

        IsLoading = false;
        IsVisible = true;


        await Shell.Current.Navigation.PopToRootAsync();
    }

    [RelayCommand]
    public async Task<Periodo> GetPeriodoActivo()
    {
        IsLoading = true;
        IsVisible = false;

        PeriodoDetails = await periodo_service.GetByEstado(true);

        if(PeriodoDetails == null)
        {
            var res = await _dialog.ShowAlertAsync("Iniciar", $"No hay información de periodos. Desea iniciar los datos iniciales?", "Aceptar", "Cancelar");
            if (res)
            {
                periodo_service.LlenarPeriodosBase();
                PeriodoDetails = await periodo_service.GetByEstado(true);
            }
        }

        Titulo = PeriodoDetails.FechaPeriodo.ToString("MMMM");

        IsLoading = false;
        IsVisible = true;

        return PeriodoDetails;

    }

    [RelayCommand]
    public async Task DetalleMovimientos()
    {
        var navparam = new Dictionary<string, object>
        {
            { "PeriodoDetails", PeriodoDetails }
        };

        await Shell.Current.GoToAsync(nameof(ListaMovimientos), navparam);

    }

    [RelayCommand]
    public async Task Clonar()
    {
        IsLoading = true;
        IsVisible = false;

        DateTime reference = PeriodoDetails.FechaPeriodo;
        DateTime firstDayThisMonth = new DateTime(reference.Year, reference.Month, 1);
        DateTime firstDayPlusTwoMonths = firstDayThisMonth.AddMonths(2);
        DateTime fechanuevoperiodo = firstDayPlusTwoMonths.AddDays(-1);

        Periodo periodonuevo = new()
        {
            FechaPeriodo = fechanuevoperiodo,
            ProcesoActual = false,
            Estado = false
        };

        try
        {

            // Validar si el PeriodoNuevo existe
            Periodo periodovalidar = await periodo_service.GetByFecha(periodonuevo.FechaPeriodo);
            if(periodovalidar == null) 
            {
                await periodo_service.Insert(periodonuevo);
            }
            else
            {
                // El periodo ya existe, preguntar si se desea borrar
                var res = await _dialog.ShowAlertAsync("Eliminar", $"El periodo a crear ya existe: {periodonuevo.FechaPeriodo}. Desea borrar los datos existente?", "Aceptar", "Cancelar");
                if (res)
                {
                    var delresponse = await periodo_service.Delete(periodonuevo);
                }
            }


            // Al periodo nuevo, agregarle los movimientos del periodo clonado. Cambia la fecha mas 1 mes
            var lista = await movimiento_service.GetbyPeriodo(PeriodoDetails.FechaPeriodo);
            // foreach (var item in lista)  // Copiar todos los movimientos 
            foreach (var item in lista)
            {
                Movimiento movimientonuevo = new()
                {
                    FechaPeriodo = periodonuevo.FechaPeriodo,
                    FechaLimite = periodonuevo.FechaPeriodo,
                    FechaReal = periodonuevo.FechaPeriodo,
                    NomSubCategoria = item.NomSubCategoria,
                    Estado = false, // Valor default false (Presupuestado)
                    TipoMovimiento = item.TipoMovimiento,
                    Valor = item.Valor
                };

                await movimiento_service.Insert(movimientonuevo);

            }

        }
        catch(Exception ex)
        {
            string message = ex.Message;
            await _dialog.ShowAlertAsync("Clonar periodo", $"Error al clonar el periodo: {periodonuevo.FechaPeriodo}.", "Aceptar", "Cancelar");
        }

        IsLoading = false;
        IsVisible = true;

    }

}

