using Microsoft.AspNetCore.Mvc;
using Veiculo.Helper;
using Veiculo.Models;
using Veiculo.Repositorio;
using Veiculo.Enums;
namespace Veiculo.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoRepositorio _repositorio;
        private readonly ISessao _sessao;
        public VeiculoController( IVeiculoRepositorio repositorio, ISessao sessao)
        {
            _repositorio = repositorio;
            _sessao = sessao;
        }

        // View principal
        public IActionResult Index()
        {
            UsuarioModel user = _sessao.BuscarUsuario();
            if ( user != null )
            {
                List<VeiculoModel> veiculos = _repositorio.ListarTodos();
                return View(veiculos);
            }
            else
            {
                return RedirectToAction("IndexDeslogado", "Veiculo");
            }
            
        }
        public IActionResult IndexDeslogado()
        {
            if (_sessao.BuscarUsuario() == null)
            {
                List<VeiculoModel> veiculos = _repositorio.ListarTodos();
                return View(veiculos);
            }
            else
            {
                return RedirectToAction("Index", "Veiculo");
            }
        }
        // View e ação de adicionar 
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(VeiculoModel veiculo)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(veiculo);
                return RedirectToAction("Index");

            }
            else
            {
                return View(veiculo);
            }
        }

        // View e ação de editar
        public IActionResult Editar(int id)
        {
            VeiculoModel veiculo = _repositorio.AttVeiculo(id);
            return View(veiculo);
        }
        [HttpPost]
        public IActionResult Atualizar(VeiculoModel veiculo)
        {
            if ( ModelState.IsValid )
            {
                _repositorio.Atualizar(veiculo);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Editar");
            }
        }

        // View e ação de apagar
        public IActionResult Apagar(int id)
        {
            VeiculoModel veiculo = _repositorio.Apagar(id);
            return View(veiculo);
        }
        public IActionResult ApagarVeiculo(VeiculoModel veiculo)
        {
            _repositorio.ApagarVeiculo(veiculo);
            return RedirectToAction("Index");
        }

    }
}
