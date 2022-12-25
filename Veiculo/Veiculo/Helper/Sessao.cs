using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Veiculo.Models;

namespace Veiculo.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao( IHttpContextAccessor httpContext )
        {
            _httpContext = httpContext;
        }

        public UsuarioModel BuscarUsuario()
        {
            string usuariologado = _httpContext.HttpContext.Session.GetString("usuarioLogado");
            if ( string.IsNullOrEmpty(usuariologado))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<UsuarioModel>(usuariologado);
            }
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("usuarioLogado", valor);
        }

        public void EncerrarSessao()
        {
            _httpContext.HttpContext.Session.Remove("usuarioLogado");
        }
    }
}
