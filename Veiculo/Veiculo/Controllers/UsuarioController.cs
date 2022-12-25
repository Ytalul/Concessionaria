using Microsoft.AspNetCore.Mvc;
using Veiculo.Models;
using Veiculo.Repositorio;

namespace Veiculo.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _repositorio;
        public UsuarioController(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        } 

        // View inicial
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios =  _repositorio.Listar();
            return View(usuarios);
        }

        // View e ação de adicionar
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }
        }

        // View e Ação de editar
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _repositorio.Editar(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Atualizar(UsuarioModel usuario)
        {
            if ( ModelState.IsValid )
            {
                _repositorio.Atualizar(usuario);
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
            UsuarioModel usuario = _repositorio.Apagar(id);
            return View(usuario);
        }
        
        public IActionResult ApagarMoto(UsuarioModel usuario)
        {
            _repositorio.ApagarMoto(usuario);
            return RedirectToAction("Index");
        }

    }
}
