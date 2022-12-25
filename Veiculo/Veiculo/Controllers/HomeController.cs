using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Veiculo.Helper;
using Veiculo.Models;

namespace Veiculo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessao _sessao;
        public HomeController(ISessao sessao)
        {
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            if (_sessao.BuscarUsuario() == null) return RedirectToAction("IndexDeslogado", "Home");
            return View();
        }
        public IActionResult IndexDeslogado()
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