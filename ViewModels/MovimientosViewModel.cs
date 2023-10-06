using CommunityToolkit.Mvvm.Input;
using PocketOne.Services;
using System.Collections.ObjectModel;

namespace PocketOne.ViewModels;

[QueryProperty(nameof(PeriodoDetails), nameof(PeriodoDetails))]
public partial class MovimientosViewModel: BaseViewModel
{
    private readonly IMovimiento movimiento_service;
    private readonly ISubCategoria subcategoria_service;
    private readonly IPeriodo periodo_service;

    public ObservableCollection<Movimiento> Movimientos { get; set; } = new();

    [ObservableProperty]
    Movimiento movimientoSeleccionado;

    [ObservableProperty]
    Periodo periodoDetails;

    [ObservableProperty]
    public List<string> tipos = new() { "Ingreso", "Egreso" };

    public List<string> SubCategorias { get; set; } = new();

    public MovimientosViewModel()
    {
        movimiento_service = App.Current.Services.GetService<IMovimiento>();
        subcategoria_service = App.Current.Services.GetService<ISubCategoria>();
        periodo_service = App.Current.Services.GetService<IPeriodo>();

        // _dialog = App.Current.Services.GetService<IDialogService>();
        // Task.Run(async () => await ListarMovimientos());
    }

    [RelayCommand]
    public async Task ListarMovimientos()
    {
        IsLoading = true;
        Movimientos.Clear();
        var lista = await movimiento_service.GetAll();
        foreach (var item in lista) Movimientos.Add(item);
        IsLoading = false;
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task GuardarMovimientos()
    {
        IsLoading = true;
        // Actualizar los movimientos
        foreach (Movimiento movimiento in Movimientos) await movimiento_service.Update(movimiento);

        // Actualizar los totales del periodo
        // Actualizar totalIngresos y totalEgresos
        var totalPorTipoMovimiento = from movimiento in Movimientos
                                     where movimiento.FechaPeriodo == PeriodoDetails.FechaPeriodo
                                     group movimiento by movimiento.TipoMovimiento into grupo
                                     select new
                                     {
                                         TipoMovimiento = grupo.Key,
                                         Total = grupo.Sum(movimiento => movimiento.Valor)
                                     };

        foreach (var item in totalPorTipoMovimiento)
        {
            if (item.TipoMovimiento=="Ingreso") PeriodoDetails.TotalIngresos = item.Total;
            else PeriodoDetails.TotalEgresos = item.Total;
        }

        PeriodoDetails.Balance = PeriodoDetails.TotalIngresos - PeriodoDetails.TotalEgresos;

        // 2. Actualizar saldo
        var TotalPeriodo = from movimiento in Movimientos
                           where movimiento.FechaPeriodo == PeriodoDetails.FechaPeriodo
                           group movimiento by new { movimiento.TipoMovimiento, movimiento.Estado } into grupo
                           select new
                           {
                               grupo.Key.TipoMovimiento,
                               grupo.Key.Estado,
                               Total = grupo.Sum(movimiento => movimiento.Valor)
                           };

        // TotalIngresos pagado - TotalEgresosPagados
        var TotalEgresosPagados = (from movimiento in TotalPeriodo
                                     where movimiento.Estado == true && movimiento.TipoMovimiento == "Egreso"
                                     select movimiento.Total).FirstOrDefault();

        var TotalIngresosPagados = (from movimiento in TotalPeriodo
                                     where movimiento.Estado == true && movimiento.TipoMovimiento == "Ingreso"
                                     select movimiento.Total).FirstOrDefault();

        var saldo = TotalIngresosPagados - TotalEgresosPagados;

        PeriodoDetails.Saldo = saldo;

        // Actualizar la BD
        await periodo_service.Update(PeriodoDetails);

        // Refresh lista de movimientos
        await ListarMovimientosPeriodo();
        IsLoading = false;

    }


    [RelayCommand]
    public async Task EditarMovimiento(Movimiento movimiento)
    {
        var navparam = new Dictionary<string, object>
        {
            { "MovimientoDetails", movimiento }
        };

        await Shell.Current.GoToAsync(nameof(MovimientoView), navparam);

    }

    [RelayCommand]
    public async Task EliminarMovimiento(Movimiento movimiento)
    {
        IsLoading = true;
        var res = await _dialog.ShowAlertAsync("Eliminar", $"Desea eliminiar el registo{movimiento.NomSubCategoria}", "Aceptar", "Cancelar");
        if (!res) return;
        var delresponse = await movimiento_service.Delete(movimiento);
        if (delresponse > 0)
        {
            await ListarMovimientosPeriodo();
        }
    }

    [RelayCommand]
    public async Task AddNew()
    {
        await Shell.Current.Navigation.PushAsync(new MovimientoView(), false);
    }

    [RelayCommand]
    public async Task ListarMovimientosPeriodo()
    {
        IsLoading = true;
        Movimientos.Clear();
        SubCategorias.Clear();

        var listaBase = await movimiento_service.GetAll();
        if (listaBase.Count == 0)
        {
            movimiento_service.LlenarMovimientosBase();            
        }
        var lista = await movimiento_service.GetbyPeriodo(PeriodoDetails.FechaPeriodo);
        // foreach (var item in lista) await movimiento_service.Delete(item);  // Borra todos los movimientos 
        foreach (var item in lista) Movimientos.Add(item);

        var listaSubCategorias = await subcategoria_service.GetAll();
        foreach (var item in listaSubCategorias) SubCategorias.Add(item.NombreSubCategoria);

        // Titulo = PeriodoDetails.FechaPeriodo.ToString("MMMM");
        Titulo = $"Movimientos de {PeriodoDetails.FechaPeriodo:MMMM}";

        IsLoading = false;
        IsRefreshing = false;
    }

}
