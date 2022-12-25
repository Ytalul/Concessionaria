using Veiculo.Data;
using Veiculo.Models;

namespace Veiculo.Repositorio
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public VeiculoRepositorio ( BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }

        public List<VeiculoModel> ListarTodos()
        {
            return _bancoContext.Veiculos.ToList();
        }

        public VeiculoModel Adicionar(VeiculoModel veiculo)
        {
            _bancoContext.Veiculos.Add(veiculo);
            _bancoContext.SaveChanges();
            return veiculo;
        }

        public VeiculoModel AttVeiculo(int id)
        {
            return _bancoContext.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        }

        public VeiculoModel Atualizar(VeiculoModel veiculo)
        {
            VeiculoModel veiculodb = AttVeiculo(veiculo.Id);
            if (veiculodb == null) throw new System.Exception("Veículo não encontrado.");
            veiculodb.Nome = veiculo.Nome;
            veiculodb.Ano = veiculo.Ano;
            veiculodb.Descrição = veiculo.Descrição;
            veiculodb.Preço = veiculo.Preço;
            veiculodb.Motor = veiculo.Motor;

            _bancoContext.Update(veiculodb);
            _bancoContext.SaveChanges();
            return veiculodb;
        }

        public VeiculoModel Apagar(int id)
        {
            return _bancoContext.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        }

        public bool ApagarVeiculo(VeiculoModel veiculo)
        {
            if (veiculo == null) throw new System.Exception("Veículo não encontrado.");
            _bancoContext.Veiculos.Remove(veiculo);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
