using Microsoft.AspNetCore.Mvc;
using Veiculo.Helper;
using Veiculo.Models;
using Veiculo.Repositorio;

namespace Veiculo.Controllers
{
    public class MotoController : Controller
    {
        private readonly IMotoRepositorio _repositorio;
        private readonly ISessao _sessao;
        public MotoController( IMotoRepositorio repositorio, ISessao sessao ) 
        {
            _repositorio = repositorio;
            _sessao = sessao;
        }

        // View inicial
        public IActionResult Index()
        {
            if ( _sessao.BuscarUsuario() != null )
            {
                List<MotoModel> moto = _repositorio.Listar();
                return View(moto);
            }
            else
            {
                return RedirectToAction("IndexDeslogado", "Moto");
            }
            
        }
        public IActionResult IndexDeslogado()
        {
            if (_sessao.BuscarUsuario() == null)
            {
                List<MotoModel> moto = _repositorio.Listar();
                return View(moto);
            }
            else
            {
                return RedirectToAction("Index", "Moto");
            }
        }

        // View e ação de adicionar
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(MotoModel moto)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(moto);
                return RedirectToAction("Index");
            }
            else
            {
                return View(moto);
            }
            
        }

        // View e ação de editar
        public IActionResult Editar(int id)
        {
            MotoModel moto = _repositorio.Editar(id);
            return View(moto);
        }
        [HttpPost]
        public IActionResult Atualizar(MotoModel moto)
        {
            if ( ModelState.IsValid )
            {
                _repositorio.Atualizar(moto);
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
            MotoModel moto = _repositorio.Apagar(id);
            return View(moto);
        }
        [HttpPost]
        public IActionResult ApagarMoto(MotoModel moto)
        {
            _repositorio.ApagarMoto(moto);
            return RedirectToAction("Index");
        }
    }
}
