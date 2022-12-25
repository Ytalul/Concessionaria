using Veiculo.Data;
using Veiculo.Models;

namespace Veiculo.Repositorio
{
    public class MotoRepositorio : IMotoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public MotoRepositorio( BancoContext contexto) 
        { 
            _bancoContext = contexto;
        }

        public MotoModel Adicionar(MotoModel moto)
        {
            _bancoContext.Motos.Add(moto);
            _bancoContext.SaveChanges();
            return moto;
        }
        public MotoModel Editar(int id)
        {
            return _bancoContext.Motos.FirstOrDefault(moto => moto.Id ==id);
        }

        public List<MotoModel> Listar()
        {
            return _bancoContext.Motos.ToList();
        }

        public MotoModel Atualizar(MotoModel moto)
        {
            MotoModel motodb =  _bancoContext.Motos.FirstOrDefault(a => a.Id == moto.Id);
            if (motodb == null) throw new System.Exception("Erro, moto não encontrada.");
            motodb.Nome = moto.Nome;
            motodb.Ano = moto.Ano;
            motodb.MaxVel = moto.MaxVel;
            motodb.Preço = moto.Preço;
            motodb.Cilindradas = moto.Cilindradas;
            _bancoContext.Update(motodb);
            _bancoContext.SaveChanges();
            return motodb;
        }

        public MotoModel Apagar(int id)
        {
            MotoModel moto = Editar(id);
            return moto;
        }

        public bool ApagarMoto(MotoModel moto)
        {
            _bancoContext.Motos.Remove(moto);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
