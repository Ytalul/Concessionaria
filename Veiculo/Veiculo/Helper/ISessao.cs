using Veiculo.Models;

namespace Veiculo.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario( UsuarioModel usuario );
        void EncerrarSessao();
        UsuarioModel BuscarUsuario();
    }
}
