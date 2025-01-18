using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var persona = new Persona
            {
                Nombre = "Romulo Castro",
                Nacionalidad = "Español"
            };

            var proyectos = ObtenerProyectos().Take(3).ToList();

            var modelo = new HomeIndexViewModel()
            {
                Persona = persona,  
                Proyectos = proyectos
            };

            return View(modelo);
        }

        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {
                    Titulo = "E-commerce",
                    Descripcion = "HTML5 y CSS3",
                    Link = "https://github.com/romulofull/Restaurant",
                    ImagenURL = "/imagenes/Restaurante.png"
                },
                new Proyecto
                {
                    Titulo = "Animaciones",
                    Descripcion = "HTML5, CSS3, SASS, Animaciones-CSS",
                    Link = "https://github.com/romulofull/Naturaleza_Ecuador",
                    ImagenURL = "/imagenes/Animaciones.png"
                },
                new Proyecto
                {
                    Titulo = "Restaurante Latino",
                    Descripcion = "HTML5 Y CSS3",
                    Link = "https://github.com/romulofull/Restaurante-objectfitcover",
                    ImagenURL = "/imagenes/Pizzas.png"
                },
                new Proyecto
                {
                    Titulo = "E-commerce",
                    Descripcion = "E-commerce venta",
                    Link = "https://github.com/romulofull/Restaurante-objectfitcover",
                    ImagenURL = "/imagenes/OtroRestaurante.jpg"
                }
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
