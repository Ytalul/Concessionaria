using Veiculo.Models;

namespace Veiculo.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        List<UsuarioModel> Listar();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Editar(int id);
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel Apagar(int id);
        bool ApagarMoto(UsuarioModel moto);
        
    }
}

