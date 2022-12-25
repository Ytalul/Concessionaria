using Veiculo.Data;
using Veiculo.Models;

namespace Veiculo.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext contexto)
        {
            _bancoContext = contexto;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuários.FirstOrDefault(x => x.Login == login);
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCriação = DateTime.Now;
            _bancoContext.Usuários.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }
        public UsuarioModel Editar(int id)
        {
            return _bancoContext.Usuários.FirstOrDefault(usuario => usuario.Id == id);
        }

        public List<UsuarioModel> Listar()
        {
            return _bancoContext.Usuários.ToList();
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuariodb = _bancoContext.Usuários.FirstOrDefault(a => a.Id == usuario.Id);
            if (usuariodb == null) throw new System.Exception("Erro, usuário não encontrada.");
            usuariodb.Nome = usuario.Nome;
            usuariodb.Login = usuario.Login;
            usuariodb.Email = usuario.Email;
            usuariodb.Perfil = usuario.Perfil;
            usuariodb.DataAtualização = DateTime.Now;

            _bancoContext.SaveChanges();
            return usuariodb;
        }

        public UsuarioModel Apagar(int id)
        {
            UsuarioModel usuario = Editar(id);
            return usuario;
        }

        public bool ApagarMoto(UsuarioModel usuario)
        {
            _bancoContext.Usuários.Remove(usuario);
            _bancoContext.SaveChanges();
            return true;
        }


    }
}
