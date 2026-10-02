using EntradasMVC.Models;
using Microsoft.AspNetCore.Mvc;
using EntradasMVC.ViewModels;

namespace EntradasMVC.Controllers
{
    public class EntradasController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new CotizacionInputViewModel();

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calcular(CotizacionInputViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            var cotizacion = new Cotizacion
            {
                Cliente = viewModel.Cliente,
                Cantidad = viewModel.Cantidad
            };

            var resultadoViewModel = new ResultadoCotizacionViewModel
            {
                Cotizacion = cotizacion,
                Evento = "Concierto Web III",
                FechaEvento = new DateTime(2026, 11, 15),
                TipoEntrada = viewModel.TipoEntrada,
                Mensaje = "Gracias por realizar su cotización."
            };

            return View("Resultado", resultadoViewModel);
        }
    }
}
