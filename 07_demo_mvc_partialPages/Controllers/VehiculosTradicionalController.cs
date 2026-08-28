using Microsoft.AspNetCore.Mvc;
using DemoPartialPages.Models.ViewModels;
using DemoPartialPages.Repositories;

namespace DemoPartialPages.Controllers;

public class VehiculosTradicionalController : Controller
{
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly ILogger<VehiculosTradicionalController> _logger;

    public VehiculosTradicionalController(
        IVehiculoRepository vehiculoRepository, 
        ILogger<VehiculosTradicionalController> logger)
    {
        _vehiculoRepository = vehiculoRepository;
        _logger = logger;
    }

    public IActionResult Index(int? id)
    {
        if (id.HasValue)
        {
            _logger.LogInformation(">>> [MODO TRADICIONAL] Petición GET a Index con Id = {Id}. Se procesa y renderiza TODA LA PÁGINA COMPLETA en el servidor.", id.Value);
        }
        else
        {
            _logger.LogInformation(">>> [MODO TRADICIONAL] Petición inicial GET a Index. Se renderiza la página completa con la grilla y sin selección.");
        }

        var vehiculos = _vehiculoRepository.ObtenerTodos();

        var vehiculoSeleccionado = id.HasValue 
            ? _vehiculoRepository.ObtenerPorId(id.Value) 
            : null;

        var viewModel = new VehiculosIndexViewModel
        {
            Vehiculos = vehiculos,
            VehiculoSeleccionado = vehiculoSeleccionado
        };

        return View(viewModel);
    }
}
