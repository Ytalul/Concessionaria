using Microsoft.AspNetCore.Mvc;
using Veiculo.Helper;
using Veiculo.Models;
using Veiculo.Repositorio;

namespace Veiculo.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio repositorio, ISessao sessao)
        {
            _repositorio = repositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // antes de mandar ele logar , verificar se tem algo na sessão de usuário com o método BuscarUsuario

            if (_sessao.BuscarUsuario() != null) return RedirectToAction("Index", "Home");    
            return View();
            
        }
        [HttpPost]
        public IActionResult Logar(LoginModel User)
        {
            if ( ModelState.IsValid )
            {
                UsuarioModel usuarioDB =  _repositorio.BuscarPorLogin(User.Login);
                if ( usuarioDB != null )
                {
                    if ( usuarioDB.SenhaValida(User.Senha) == true)
                    {
                        _sessao.CriarSessaoUsuario(usuarioDB);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Ok(new MensagemErro(401, "Senha inválida"));
                    }
                }
                else
                {
                    return Ok(new MensagemErro(402, "Login de usuário não encontrado"));
                }
            }
            else
            {
                return Ok(new MensagemErro(403, "Usuário inválido"));
            }
        }

        public IActionResult Deslogar()
        {
            _sessao.EncerrarSessao();
            return RedirectToAction("Index", "Login");
        }

    }
}
