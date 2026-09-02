using Microsoft.AspNetCore.Mvc;
using DemoPartialPages.Models.ViewModels;
using DemoPartialPages.Repositories;

namespace DemoPartialPages.Controllers;

public class VehiculosAjaxController : Controller
{
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly ILogger<VehiculosAjaxController> _logger;

    public VehiculosAjaxController(
        IVehiculoRepository vehiculoRepository, 
        ILogger<VehiculosAjaxController> logger)
    {
        _vehiculoRepository = vehiculoRepository;
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation(">>> [MODO AJAX] Petición inicial a Index. Se renderiza la estructura principal de la página (solo 1 vez).");

        var vehiculos = _vehiculoRepository.ObtenerTodos();

        var viewModel = new VehiculosIndexViewModel
        {
            Vehiculos = vehiculos,
            VehiculoSeleccionado = null
        };

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Detalle(int id)
    {
        _logger.LogInformation(">>> [MODO AJAX -> PARTIAL VIEW] Petición asíncrona a Detalle con Id = {Id}. El servidor devuelve ÚNICAMENTE el fragmento HTML de la vista parcial '_DetalleVehiculo'.", id);

        var vehiculo = _vehiculoRepository.ObtenerPorId(id);

        if (vehiculo == null)
        {
            _logger.LogWarning(">>> [MODO AJAX] Vehículo con Id = {Id} no encontrado.", id);
            return NotFound("Vehículo no encontrado.");
        }

        //como uso PartialView, el servidor devuelve solo el fragmento HTML de la vista parcial "_DetalleVehiculo.cshtml"
        //de lo contrario, si usara View(), devolvería toda la página completa con layout y todo
        return PartialView("_DetalleVehiculo", vehiculo);
    }
}
